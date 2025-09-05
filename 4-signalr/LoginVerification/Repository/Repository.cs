public class Repository : IRepository
{

    private readonly IDictionary<string, User> _users;

    public Repository()
    {
        _users = new Dictionary<string, User>
        {
            { "pepe@mail.com", new User(1, "pepe", "1234", "pepe@mail.com") },
            { "matias@mail.com", new User(2, "matias", "2345", "matias@mail.com") },
            { "neko@mail.com", new User(3, "neko", "3456", "neko@mail.com") }
        };
    }

    public User? GetUserById(long id)
    {
        return _users.FirstOrDefault(user => user.Value.Id == id).Value;
    }

    public User? GetUserByEmail(string email)
    {
        if (_users.TryGetValue(email, out var user))
        {
            return user;
        }
        return null;
    }

    public List<User> GetAllUsers()
    {
        return _users.Values.ToList();
    }

    public void CreateUser(string username, string password, string email)
    {
        long newId = 1;

        foreach (User user in _users.Values)
        {
            if (user.Id > newId)
            {
                newId = user.Id++;
            }
        }
        _users.Add(email, new User(newId, username, password, email));
    }
}