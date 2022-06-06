using WebApplication1.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();




// Run Metodu
/*
 * Baz� metotlar pipeline i�erisinde k�sa devreye neden olur.
 * Yani kendisinden sonraki i�lemler ger�ekle�mez.
 * Bu tip meotlar� kullan�rken dikkatli olmak gerekir. Run bunlardan biridir.
 */

//app.Run(async context => Console.WriteLine("Middleware 1."));
//app.Run(async context => Console.WriteLine("Middleware 2."));

// Use Metodu

/*
 * Devreye girdikten sonra kendinden sonraki middleware'i tetikleyebilir 
 * ve i�i bittikten sonra kald��� yerden devam edilebilir bir yap� sunar
 */

//Map Metodu

/*
 * Middleware lerin path baz�ndan �al��mas�n� istedi�imiz durumlarda kullan�r�z.
 * Use() yada Run() metodunu if () statement ile y�neterekte bunu yapabiliriz. 
 * Ama Map metodu bize bunu kolayca y�netme olana�� sa�l�yor.
*/

//MapWhen Metodu

/*
 * 
Map metodu ile sadece path'e baz�nda middleware y�netebilirken
MapWhen ile request'e ba�l� olarak her t�rl� y�nlendirmeyi yapabiliriz.
 */
//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 1 tetiklendi.");
//    await next.Invoke();
//});

//app.MapWhen(x => x.Request.Method == "GET", internalApp =>
//{
//    internalApp.Run(async context => await Console.WriteLine("MapWhen ile Middleware Tetiklendi."));
//});




//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.UseHelloWorld();

app.Run();
