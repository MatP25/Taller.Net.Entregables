using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Home");
    }
}