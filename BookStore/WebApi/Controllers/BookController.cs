using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetById;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("controllerjs")]
    [ApiController]
    public class BookController : Controller
    {


        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            return Ok(query.Handle());
        }
        [HttpGet("{id}")]
        public BookModel GetById(int id)
        {
            GetByIdCommand command = new GetByIdCommand(_context);
            return command.Handle(id);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel model)
        {
            CreateBookCommand createBook = new CreateBookCommand(_context);
            try
            {
                createBook.Model = model;
                createBook.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromBody] UpdateBookModel model)
        {
            UpdateBookCommand updateBook = new UpdateBookCommand(_context);
            try
            {
                updateBook.Model = model;
                updateBook.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();

        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromBody] int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
                return BadRequest();
            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
