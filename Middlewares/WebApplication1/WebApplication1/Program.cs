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

//.NET Core DI Container (Services)
/*
 * .NET Core kendi içerisinde kullanýma hazýr bir DI Container'ý barýndýrýr. 
 *  Bu sayede herhangi bir farklý kütüphane kullanmamýza gerek kalmadan uygulamamýz içerisinde 
 * .net core di containerýný rahatlýkla kullanabiliriz.

.Net Core içerisinde hazýr bulunan containerý Startup'daki ConfigureServices metodu içerisinde kullanýrýz.
Bu methodun IServiceCollection tipinde services adýyla aldýðý parametre aslýnda container nesnesidir diye düþünebiliriz.
 
*.Net Core DI Container'a bir sýnýf kayýt ederken bu sýnýfa ait nesnenin yaþam süresini de belirtmemiz gerekir.
*Bu yaþam süresine göre container kayýt sýrasýnda kullanacaðýmýz method ismi deðiþmektedir.
Containerda nesnelerin yaþam süresi 3 çeþittir.

1 - Singleton Service : Bu yaþam süresine sahip nesne, uygulamanýn çalýþmaya baþladýðý andan duruncaya kadar geçen tüm süre boyunca yalnýzca bir kez oluþturulur ve her zaman ayný nesne kullanýlýr. Singleton bir servis eklememiz için AddSingleton methodunu kullanýrýz. 
Örnek : services.AddSingleton<Foo>();



2 - Scoped Service : Bu yaþam süresine sahip nesne, bir http requesti boyunca bir kez oluþturulur ve response oluþana kadar her zaman ayný nesne kullanýlýr. Scoped bir servis eklememiz için AddScoped methodunu kullanýrýz. Örnek : services.AddScoped<Bar>();


3 - Transient Service : Bu yaþam süresine sahip nesne, container tarafýndan her seferinde yeniden oluþturulur. Transient bir servis eklememiz için AddTransient methodunu kullanýrýz. Örnek : services.AddTransient<Baz>();

Eðer kayýt edilecek servis bir interface implemente ediyor ve bu interface aracýlýðý ile kullanýlýyor ise; kayýt sýrasýnda hem interface tipini hem de bu interface'i implemente eden sýnýfý belirtmemiz gerekir. Bu þekilde yaptýðýmýz kayýtlarda da nesnenin yaþam süresini belirtmemiz gereklidir.

Örnekler :



services.AddSingleton<IFoo, Foo>(); services.AddTransient<IBaz, Baz>(); services.AddScoped<IBar, Bar>();



Bu þekilde baðýmlý olunan nesnenin sýnýfýný bilmemize gerek kalmadan bir interface yardýmý ile ihtiyaç duyduðumuz iletiþimi saðlamýþ oluruz. Baðýmlýlýklarýn interface ile yönetilmesi uygulamamýzdaki parçalarýn loosely coupled (gevþek baðýmlý) kalmalarýna yardýmcý olan en büyük etmenlerden biridir. Loosely coupled uygulamalar daha esnek, kolay geniþletilebilir/deðiþtirilebilir ve test edilebilir olurlar.



Aþaðýdaki örnekte görebilebileceðimiz gibi, baðýmlýlýklar artýk direkt olarak sýnýf yerine bir interface üzerinden alýnýyor. Böylece ihtiyaç duyulan interface'i implemente eden herhangi bir sýnýfa ait nesne, baðýmlý olan sýnýf tarafýndan kullanýlabilir. Ýlgili interface için hangi sýnýfýn kullanýlacaðý bilgisini ise container'a kaydetmiþ olmamýz gereklidir.


.Net Core DI Container, baðýmlýlýklarý yapýcý method (Constructor) yada Method Injection yöntemi ile saðlar. Method Injection yöntemini kullanmak için Controller sýnýfý içerisindeki action method parametrelerine [FromServices] attribute ile ihtiyaç duyulan baðýmlýlýk belirtilir. Yapýcý method yöntemi için ise Controller sýnýfýnýn yapýcý methoduna baðýmlý olunan nesne belirtilmesi yeterlidir.

Veritabaný iþlemlerimiz için EntityFramework Core kullanýyorsak, kullanýlan DbContext'leri de Containera kaydedebilir ve DbContext'ler için de dependency injection uygulayabiliriz. DbContext'leri containera kaydetmek için AddDbContext methodunu kullanýrýz. Örnek : services.AddDbContext<MyDbContext>();



Containera kayýtlý servislerin kullanýmý için IServiceCollection'ýn yada herhangi bir methodun kullanýmýna ihtiyaç yoktur. ConfigureServices içerisinde containera kayýt edilen tüm servisler, yukarýdaki örnekte olduðu gibi Controller sýnýflarýn yapýcý methodlarýnda belirtilerek kullanýlabilirler. Controller sýnýflarý özel sýnýflar olduðundan nesnelerinin yaratýlmasý sýrasýnda baðýmlýlýklarý container üzerinden otomatik olarak çözülerek yaratýlýrlar.

 
 */
