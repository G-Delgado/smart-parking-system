public interface IUserRepository
{
    List<User> GetAll();
    User? GetById(string userId);
    void Add(User user);
    void Remove(Guid id);
    void Update(User user);
}