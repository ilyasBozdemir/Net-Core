using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
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
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
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
            CreateBookCommand createBook = new CreateBookCommand(_context,_mapper);
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
            DeleteBookCommand updateBook = new DeleteBookCommand(_context);
            try
            {
                updateBook.Handle(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
