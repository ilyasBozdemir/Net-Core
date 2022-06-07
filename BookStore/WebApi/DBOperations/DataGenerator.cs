using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

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
                context.Authors.AddRange(EntityInitialize.GetAuthors());
                context.Genres.AddRange(EntityInitialize.GetGenres());
                context.Books.AddRange(EntityInitialize.GetBooks());
                context.SaveChanges();
            }
        }
    }
}
