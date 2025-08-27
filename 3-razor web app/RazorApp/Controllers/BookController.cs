using Microsoft.AspNetCore.Mvc;

[Route("books")]
public class BookController : Controller
{
    private readonly IRepository repository;
    private readonly ILogger<BookController> logger;
    public BookController(IRepository repository, ILogger<BookController> logger)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        logger.LogInformation("Fetching all books");
        var books = repository.GetAllBooks();
        return View("BookList", books);
    }

    [HttpGet("/{isbn}")]
    public IActionResult GetBookByIsbn(string isbn)
    {
        logger.LogInformation($"Fetching book with ISBN: {isbn}");
        var book = repository.GetBookByIsbn(isbn);
        if (book == null)
        {
            logger.LogWarning($"Book with ISBN: {isbn} not found");
            return NotFound("Book not found");
        }
        return View("BookDetails", book);
    }

    [HttpPost("/delete")]
    public IActionResult DeleteBook(string isbn)
    {
        var success = repository.DeleteBook(isbn);
        if (!success)
        {
            logger.LogWarning($"Attempted to delete non-existent book with ISBN: {isbn}");
            return NotFound("Book not found");
        }
        logger.LogInformation($"Deleted book with ISBN: {isbn}");
        return RedirectToAction("GetAllBooks");
    }

    [HttpPost("/add")]
    public IActionResult AddBook([FromForm] Book book)
    {
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Invalid model state while adding a book");
            return View("AddBookForm");
        }

        logger.LogInformation($"Adding book with ISBN: {book.Isbn}, Title: {book.Title}, Author: {book.Author}, PublishedDate: {book.PublishedDate}");
        repository.AddBook(book.Isbn, book.Title, book.Author, book.PublishedDate);
        return RedirectToAction("GetAllBooks");
    }

    [HttpGet("/add")]
    public IActionResult AddBookForm()
    {
        return View("AddBookForm");
    }
}