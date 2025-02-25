
using System.ComponentModel.DataAnnotations;

public class CreateUserDTO
{
    [Required]
    public required string Username { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }

    public string Role { get; set; } = "User"; // Default Admin
}