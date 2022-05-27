using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.DBOperations;

namespace WebApi
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "BookStore");
            });
        }
    }
}
