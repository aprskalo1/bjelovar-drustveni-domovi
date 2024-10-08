using Microsoft.AspNetCore.Mvc;

namespace BddAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("FirebaseAuth")]
    public IActionResult Index()
    {
        return Ok("Hello World");
    }
}