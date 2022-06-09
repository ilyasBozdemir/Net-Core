using MovieStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using MovieStore.Services;
using MovieStore.Application.Middlewares;

#region builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

//dependency injection

builder.Services.AddDbContext<MovieStoreDbContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "MovieStoreDb");
});

builder.Services.AddScoped<IMovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>());

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
#endregion

//
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine();
Console.WriteLine($"Application Name : {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name : {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path : {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath : {builder.Environment.WebRootPath}");
Console.WriteLine(); 
Console.ForegroundColor = ConsoleColor.White;

//

#region app

WebApplication app = builder.Build();

DataGenerator.Initialize(app.Services.CreateScope().ServiceProvider);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseLogAndError();//custom middleware

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

#endregion