using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public BookStoreDbContext _dbContext { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == Model.Id);
            if (book == null)
            {
                book.GenreId = Model.GenreId != default ?
                    Model.GenreId :
                    book.GenreId;

                book.PageCount = Model.PageCount != default ?
                                 Model.PageCount :
                                 book.PageCount;

                book.PublishDate = Model.PublishDate != default ?
                                   Model.PublishDate :
                                   book.PublishDate;

                book.Title = Model.Title != default ?
                                   Model.Title :
                                   book.Title;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("kitap zaten mevcut");
            }
        }
    }
    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
