using BddAPI.DTOs.Request;
using BddAPI.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BddAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRequestDto userRequestDto)
    {
        var userResponseDto = await authService.RegisterAsync(userRequestDto);
        return Ok(userResponseDto);
    }
}