using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IRepository repository;

    public HomeController(IRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {

        int bookCount = repository.GetAllBooks().Count;
        ViewData["BookCount"] = bookCount;
        return View("Home");
    }
}