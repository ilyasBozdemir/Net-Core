using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        public BookStoreDbContext _dbContext { get; set; }
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(b => b.Id).ToList();
            List<BooksViewModel> vb = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vb.Add(new BooksViewModel
                {
                    Title = book.Title,

                    // Genre=((GenreEnum)book.GenreId).ToString(),

                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
                });
            }
            return vb;
        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
