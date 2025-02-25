public class User {
    private Guid Id { get; set; } = Guid.NewGuid();
    private string Username { get; set; } = string.Empty;
    private string PasswordHash { get; set; } = string.Empty;

    // By default, User
    private Role UserRole { get; set; } = Role.User;
}