using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        public BookStoreDbContext _dbContext { get; set; }
        private IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("kitap zaten mevcut");
            }
            else
            {
                book = _mapper.Map<Book>(Model);/*new Book();*/
                //book.Title = Model.Title;
                //book.PublishDate = Model.PublishDate;
                //book.PageCount = Model.PageCount;
                //book.GenreId = Model.GenreId;
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
        }
    }
    public class CreateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
