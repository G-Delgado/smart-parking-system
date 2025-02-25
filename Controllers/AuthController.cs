using Microsoft.AspNetCore.Mvc;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserDTO request)
    {
        var token = _authService.Authenticate(request.Username, request.Password);

        if (string.IsNullOrEmpty(token))
            return Unauthorized(new { message = "Invalid credentials" });

        return Ok(new UserDTO { Username = request.Username, Token = token });
    }
}