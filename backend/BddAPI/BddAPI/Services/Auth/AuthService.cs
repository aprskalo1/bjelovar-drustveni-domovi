using AutoMapper;
using BddAPI.DTOs.Request;
using BddAPI.DTOs.Response;
using BddAPI.Models;
using BddAPI.Repositories;

namespace BddAPI.Services.Auth;

public interface IAuthService
{
    Task<UserResponseDto> RegisterAsync(UserRequestDto userRequestDto);
}

public class AuthService(IUserRepository userRepository, IMapper mapper) : IAuthService
{
    public async Task<UserResponseDto> RegisterAsync(UserRequestDto userRequestDto)
    {
        var existingUser = await userRepository.GetUserByUsernameAsync(userRequestDto.Username);

        if (existingUser != null)
            throw new Exception("User already exists");

        var user = mapper.Map<User>(userRequestDto);
        await userRepository.CreateUserAsync(user);
        await userRepository.SaveChangesAsync();

        return mapper.Map<UserResponseDto>(user);
    }
}