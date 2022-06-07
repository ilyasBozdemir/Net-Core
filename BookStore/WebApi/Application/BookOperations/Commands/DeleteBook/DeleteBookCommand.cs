using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public BookStoreDbContext _dbContext { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if (book != null)
                throw new InvalidOperationException("kitap zaten mevcut");
            else
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }
    }
}
