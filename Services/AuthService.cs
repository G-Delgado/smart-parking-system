using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    private readonly JwtSettings _jwtSettings;

    public AuthService(IUserRepository userRepository, IConfiguration configuration, JwtSettings jwtSettings)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _jwtSettings = jwtSettings;
    }

    public string Authenticate(string username, string password)
    {
        // Buscar usuario en la base de datos
        var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == username);

        // Verificar usuario y contraseña
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return string.Empty; // Retorna vacío si la autenticación falla

        // Crear claims para el token
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.ActualRole.ToString())
        };

        // Obtener clave secreta del archivo de configuración
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Crear el token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
