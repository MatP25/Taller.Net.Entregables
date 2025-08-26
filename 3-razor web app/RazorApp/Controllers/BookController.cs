using Microsoft.AspNetCore.Mvc;

public class BookController : Controller
{
    private readonly IRepository repository;
    private readonly ILogger<BookController> logger;
    public BookController(IRepository repository, ILogger<BookController> logger)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet("/books")]
    public IActionResult GetAllBooks()
    {
        logger.LogInformation("Fetching all books");
        var books = repository.GetAllBooks();
        return View("BookList", books);
    }

    [HttpGet("/books/{isbn}")]
    public IActionResult GetBookByIsbn(string isbn)
    {
        logger.LogInformation($"Fetching book with ISBN: {isbn}");
        var book = repository.GetBookByIsbn(isbn);
        if (book == null)
        {
            return NotFound("Book not found");
        }
        return View("BookDetails", book);
    }

    [HttpPost("/books/delete/{isbn}")]
    public IActionResult DeleteBook(string isbn)
    {
        logger.LogInformation($"Deleting book with ISBN: {isbn}");
        var success = repository.DeleteBook(isbn);
        if (!success)
        {
            return NotFound("Book not found");
        }
        return RedirectToAction("GetAllBooks");
    }

    [HttpPost("/books/add")]
    public IActionResult AddBook(string isbn, string title, string author, DateTime publishedDate)
    {
        logger.LogInformation($"Adding book with ISBN: {isbn}, Title: {title}, Author: {author}, PublishedDate: {publishedDate}");
        if (!ModelState.IsValid)
        {
            return View("AddBookForm");
        }
        repository.AddBook(isbn, title, author, publishedDate);
        return RedirectToAction("GetAllBooks");
    }

    [HttpGet("/books/add")]
    public IActionResult AddBookForm()
    {
        return View("AddBookForm");
    }
}