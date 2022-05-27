using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                
                if (context.Books.Any())
                {
                    return;   
                }

                context.Books.AddRange(
                   new Book()
                   {
                       Id = 1,
                       Title = "Lean Startup",
                       GenreId = 1,
                       PageCount = 200,
                       PublishDate = new DateTime(2001, 6, 12)
                   });
                context.Books.AddRange(
                   new Book()
                   {
                       Id = 2,
                       Title = "Merland",
                       GenreId = 2,
                       PageCount = 250,
                       PublishDate = new DateTime(2010, 5, 23)
                   });
                context.SaveChanges();
            }
        }
    }
}
