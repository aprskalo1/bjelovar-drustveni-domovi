using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using BddAPI.Data;
using BddAPI.DTOs.Request;
using BddAPI.DTOs.Response;
using BddAPI.Exceptions;
using BddAPI.Models;
using BddAPI.Repositories;
using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BddAPI.Services.Auth;

public interface ITokenService
{
    Task<TokensResponse> GenerateAccessTokenWithFirebase(string firebaseToken);
    Task<TokensResponse> RefreshAccessToken(string refreshToken);
}

public class TokenService(
    IConfiguration configuration,
    IUserRepository userRepository,
    FirebaseAuth firebaseAuth,
    IUserService userService,
    IMapper mapper,
    BddDbContext dbContext)
    : ITokenService
{
    public async Task<TokensResponse> GenerateAccessTokenWithFirebase(string firebaseToken)
    {
        var decodedToken = await firebaseAuth.VerifyIdTokenAsync(firebaseToken);

        var userId = decodedToken.Claims["user_id"].ToString();
        var userEmail = decodedToken.Claims["email"].ToString();
        var username = decodedToken.Claims["name"].ToString();
        if (userId == null || userEmail == null || username == null)
        {
            throw new UserException("User ID, email or username not found in token");
        }

        var user = await userRepository.GetUserByFirebaseUid(userId);
        if (user == null)
        {
            await userRepository.CreateUserAsync(new User
            {
                FirebaseUid = userId,
                Username = username,
                Email = userEmail,
            });
            var userRequestDto = mapper.Map<UserRequestDto>(user);
            await userService.AssignDefaultRoleAsync(userRequestDto);
            await userRepository.SaveChangesAsync();
        }

        var accessToken = GenerateAccessToken();
        var refreshToken = GenerateRefreshToken();

        dbContext.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            Expires = DateTime.Now.AddDays(7),
            UserId = user!.Id
        });
        await dbContext.SaveChangesAsync();

        return new TokensResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<TokensResponse> RefreshAccessToken(string refreshToken)
    {
        var validRefreshToken = await dbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken) ??
                                throw new NotFoundException("Refresh token not found");

        if (validRefreshToken.Expires < DateTime.Now)
        {
            throw new UnauthorizedException("Refresh token expired");
        }

        var accessToken = GenerateAccessToken();

        return new TokensResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    private string GenerateAccessToken()
    {
        var jwtSettings = configuration.GetSection("JWT");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var accessToken = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["AccessTokenExpirationInMinutes"]!)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(accessToken);
    }

    private string GenerateRefreshToken()
    {
        var jwtSettings = configuration.GetSection("JWT");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var refreshToken = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            expires: DateTime.Now.AddDays(7),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(refreshToken);
    }
}