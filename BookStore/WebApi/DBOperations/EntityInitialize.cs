using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class EntityInitialize
    {
        public static IEnumerable<Author> GetAuthors()
        {
            Author author = new()
            {
                Name = "Joseph",
                Surname = "Hansen",
                DateOfBirth = new DateTime(1956, 04, 04),

            };
            var bookList = GetBooks().ToList().Select(x => x.AuthorId == author.Id) as List<Book>;
            foreach (var book in bookList)
                author.Books.Add(book);
            
            Author author2 = new()
            {
                Name = "Brooke",
                Surname = "Vega",
                DateOfBirth = new DateTime(1975, 04, 12)

            };
            var bookList2 = GetBooks().ToList().Select(x => x.AuthorId == author.Id) as List<Book>;
            foreach (var book2 in bookList2)
                author2.Books.Add(book2);

            List<Author> authors = new List<Author> 
            {
                author,
                author2
            };
            IEnumerable<Author> _authors_IE = authors as IEnumerable<Author>;
            return _authors_IE;
           // return authors as IEnumerable<Author>;
        }
        public static IEnumerable<Genre> GetGenres()
        {
            Genre genre = new Genre()
            {
                Name = "Persanal Growth",

            }, 
            genre2 = new Genre()
            {
                Name = "Science Fiction",
            };
            List<Genre> genres = new List<Genre>
            {
                genre,
                genre2
            };
            return genres as IEnumerable<Genre>;
        }
        public static IEnumerable<Book> GetBooks()
        {
            Book book = new()
            {
                Id = 1,
                Title = "Lean Startup",
                AuthorId = 1,
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2001, 6, 12)
            };

            Book book2 = new()
            {
                Id = 2,
                Title = "Merland",
                AuthorId = 2,
                GenreId = 2,
                PageCount = 250,
                PublishDate = new DateTime(2010, 5, 23)
            };
            List<Book> authors = new List<Book>
            {
                book,
                book2
            };
            return authors as IEnumerable<Book>;
        }
    }
}
