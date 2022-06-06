using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi;
using WebApi.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
});
builder.Services.AddDbContext<BookStoreDbContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "BookStore");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var host = CreateHostBuilder(args).Build();



using (var scope = host.Services.CreateScope())
{
    var Services = scope.ServiceProvider;
    DataGenerator.Initialize(Services);
}

IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Program>();
        });

app.Run();
