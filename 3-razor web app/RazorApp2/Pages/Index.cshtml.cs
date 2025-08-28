using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp2.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Data.RazorAppBookContext _context;


    public IndexModel(ILogger<IndexModel> logger, Data.RazorAppBookContext context)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        ViewData["BooksCount"] = _context.Book.Count();
    }
}
