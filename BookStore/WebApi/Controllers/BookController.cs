using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("controllerjs")]
    [ApiController]
    public class BookController : Controller
    {
        public static List<Book> BookList = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "Lean Startup",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2001,6,12)
            },
            new Book()
            {
                Id = 2,
                Title = "Merland",
                GenreId = 2,
                PageCount = 250,
                PublishDate = new DateTime(2010,5,23)
            },
            new Book()
            {
                Id = 3,
                Title = "Dune",
                GenreId = 2,
                PageCount = 540,
                PublishDate = new DateTime(2001,12,21)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(b => b.Id).ToList();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(b => b.Id == id).SingleOrDefault();

            return book;
        }

        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{
        //    var book = BookList.Where(b => b.Id == Convert.ToInt32(id)).SingleOrDefault();

        //    return book;
        //}

        //Post
        
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.FirstOrDefault(b => b.Title == newBook.Title);
            if (book != null)
                return BadRequest();
            else
            {
                BookList.Add(newBook);
                return Ok();
            }
        }
        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromBody] Book updateBook)
        {
            var book = BookList.SingleOrDefault(b => b.Id == updateBook.Id);
            
            if (book == null)
            {
                book.GenreId = updateBook.GenreId != default ?
                    updateBook.GenreId :
                    book.GenreId;

                book.PageCount = updateBook.PageCount != default ?
                                 updateBook.PageCount :
                                 book.PageCount;

                book.PublishDate = updateBook.PublishDate != default ?
                                   updateBook.PublishDate :
                                   book.PublishDate;

                book.Title = updateBook.Title != default ?
                                   updateBook.Title :
                                   book.Title;

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromBody] int id)
        {
            var book = BookList.FirstOrDefault(b => b.Id == id);
            if (book != null)
                return BadRequest();
            else
            {
                BookList.Remove(book);
                return Ok();
            }
        }


    }
}
