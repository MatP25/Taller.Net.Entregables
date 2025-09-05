public class LoginCredentials
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginCredentials(string email, string password)
    {
        Email = email;
        Password = password;
    }
}