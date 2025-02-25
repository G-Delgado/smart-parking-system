public class User {
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }

    // By default, User
    public Role ActualRole { get; set; }
}