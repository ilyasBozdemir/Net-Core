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
 * Bazý metotlar pipeline içerisinde kýsa devreye neden olur.
 * Yani kendisinden sonraki iþlemler gerçekleþmez.
 * Bu tip meotlarý kullanýrken dikkatli olmak gerekir. Run bunlardan biridir.
 */

//app.Run(async context => Console.WriteLine("Middleware 1."));
//app.Run(async context => Console.WriteLine("Middleware 2."));

// Use Metodu

/*
 * Devreye girdikten sonra kendinden sonraki middleware'i tetikleyebilir 
 * ve iþi bittikten sonra kaldýðý yerden devam edilebilir bir yapý sunar
 */

//Map Metodu

/*
 * Middleware lerin path bazýndan çalýþmasýný istediðimiz durumlarda kullanýrýz.
 * Use() yada Run() metodunu if () statement ile yöneterekte bunu yapabiliriz. 
 * Ama Map metodu bize bunu kolayca yönetme olanaðý saðlýyor.
*/

//MapWhen Metodu

/*
 * 
Map metodu ile sadece path'e bazýnda middleware yönetebilirken
MapWhen ile request'e baðlý olarak her türlü yönlendirmeyi yapabiliriz.
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
