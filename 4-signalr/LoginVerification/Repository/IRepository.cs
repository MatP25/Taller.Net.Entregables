
public interface IRepository
{
    public User? GetUserById(long id);
    public User? GetUserByEmail(string email);
    public List<User> GetAllUsers();
    public void CreateUser(string username, string password, string email);
}