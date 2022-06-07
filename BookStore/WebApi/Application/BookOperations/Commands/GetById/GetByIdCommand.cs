using WebApi.DBOperations;

namespace WebApi.BookOperations.GetById
{
    public class GetByIdCommand
    {
        public BookStoreDbContext _dbContext { get; set; }
        public GetByIdCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookModel Handle(int id)
        {
            var book = _dbContext.Books.Where(b => b.Id == id).SingleOrDefault();

            BookModel bookModel = new BookModel();
            bookModel.Id = book.Id;
            bookModel.Title = book.Title;
            bookModel.PageCount = book.PageCount;
            bookModel.GenreId = book.GenreId;
            bookModel.PublishDate = book.PublishDate;
            return bookModel;
        }
    }
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
