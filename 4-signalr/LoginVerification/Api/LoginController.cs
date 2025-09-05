using Microsoft.AspNetCore.Mvc;

[Route("login")]
public class LoginController : Controller
{
    private readonly IRepository _repository;
    private readonly ILogger<LoginController> _logger;

    public LoginController(IRepository repository, ILogger<LoginController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Login([FromForm] string email, string password)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state while reading credentials");
            return View("LoginForm");
        }

        _logger.LogInformation($"{email} is attempting to log in");

        User? user = _repository.GetUserByEmail(email);

        if (user == null || user.Password != password)
        {
            ViewData["ErrorMessage"] = "Invalid credentials";
            return View("LoginForm");
        }

        //send link here

        return View("LoginVerification");
    }

    [HttpGet]
    public IActionResult LoginForm()
    {
        return View("LoginForm");
    }
}