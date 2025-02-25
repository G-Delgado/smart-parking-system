public interface IUserRepository
{
    List<User> GetAll();
    User? GetById(Guid userId);
    void Add(User user);
    void Remove(Guid id);
    void Update(User user);
}