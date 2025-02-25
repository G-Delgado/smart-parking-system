public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public UserRepository()
    {
        _users.Add(new User
        {
            Id = Guid.NewGuid(),
            Username = "admin",
            ActualRole = Role.Admin,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin")
        });
    }

    public List<User> GetAll() => _users;
    public User? GetById(Guid id) => _users.FirstOrDefault(s => s.Id == id);
    public void Add(User user) => _users.Add(user);
    public void Remove(Guid id) => _users.RemoveAll(s => s.Id == id);
    public void Update(User user)
    {
        var existingUser = GetById(user.Id);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.ActualRole = user.ActualRole;
            existingUser.PasswordHash = user.PasswordHash;
        }
    }
}
