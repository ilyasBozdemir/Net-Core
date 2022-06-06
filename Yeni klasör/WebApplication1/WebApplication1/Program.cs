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

//.NET Core DI Container (Services)
/*
 * .NET Core kendi i�erisinde kullan�ma haz�r bir DI Container'� bar�nd�r�r. 
 *  Bu sayede herhangi bir farkl� k�t�phane kullanmam�za gerek kalmadan uygulamam�z i�erisinde 
 * .net core di container�n� rahatl�kla kullanabiliriz.

.Net Core i�erisinde haz�r bulunan container� Startup'daki ConfigureServices metodu i�erisinde kullan�r�z.
Bu methodun IServiceCollection tipinde services ad�yla ald��� parametre asl�nda container nesnesidir diye d���nebiliriz.
 
*.Net Core DI Container'a bir s�n�f kay�t ederken bu s�n�fa ait nesnenin ya�am s�resini de belirtmemiz gerekir.
*Bu ya�am s�resine g�re container kay�t s�ras�nda kullanaca��m�z method ismi de�i�mektedir.
Containerda nesnelerin ya�am s�resi 3 �e�ittir.

1 - Singleton Service : Bu ya�am s�resine sahip nesne, uygulaman�n �al��maya ba�lad��� andan duruncaya kadar ge�en t�m s�re boyunca yaln�zca bir kez olu�turulur ve her zaman ayn� nesne kullan�l�r. Singleton bir servis eklememiz i�in AddSingleton methodunu kullan�r�z. 
�rnek : services.AddSingleton<Foo>();



2 - Scoped Service : Bu ya�am s�resine sahip nesne, bir http requesti boyunca bir kez olu�turulur ve response olu�ana kadar her zaman ayn� nesne kullan�l�r. Scoped bir servis eklememiz i�in AddScoped methodunu kullan�r�z. �rnek : services.AddScoped<Bar>();


3 - Transient Service : Bu ya�am s�resine sahip nesne, container taraf�ndan her seferinde yeniden olu�turulur. Transient bir servis eklememiz i�in AddTransient methodunu kullan�r�z. �rnek : services.AddTransient<Baz>();

E�er kay�t edilecek servis bir interface implemente ediyor ve bu interface arac�l��� ile kullan�l�yor ise; kay�t s�ras�nda hem interface tipini hem de bu interface'i implemente eden s�n�f� belirtmemiz gerekir. Bu �ekilde yapt���m�z kay�tlarda da nesnenin ya�am s�resini belirtmemiz gereklidir.

�rnekler :



services.AddSingleton<IFoo, Foo>(); services.AddTransient<IBaz, Baz>(); services.AddScoped<IBar, Bar>();



Bu �ekilde ba��ml� olunan nesnenin s�n�f�n� bilmemize gerek kalmadan bir interface yard�m� ile ihtiya� duydu�umuz ileti�imi sa�lam�� oluruz. Ba��ml�l�klar�n interface ile y�netilmesi uygulamam�zdaki par�alar�n loosely coupled (gev�ek ba��ml�) kalmalar�na yard�mc� olan en b�y�k etmenlerden biridir. Loosely coupled uygulamalar daha esnek, kolay geni�letilebilir/de�i�tirilebilir ve test edilebilir olurlar.



A�a��daki �rnekte g�rebilebilece�imiz gibi, ba��ml�l�klar art�k direkt olarak s�n�f yerine bir interface �zerinden al�n�yor. B�ylece ihtiya� duyulan interface'i implemente eden herhangi bir s�n�fa ait nesne, ba��ml� olan s�n�f taraf�ndan kullan�labilir. �lgili interface i�in hangi s�n�f�n kullan�laca�� bilgisini ise container'a kaydetmi� olmam�z gereklidir.


.Net Core DI Container, ba��ml�l�klar� yap�c� method (Constructor) yada Method Injection y�ntemi ile sa�lar. Method Injection y�ntemini kullanmak i�in Controller s�n�f� i�erisindeki action method parametrelerine [FromServices] attribute ile ihtiya� duyulan ba��ml�l�k belirtilir. Yap�c� method y�ntemi i�in ise Controller s�n�f�n�n yap�c� methoduna ba��ml� olunan nesne belirtilmesi yeterlidir.

Veritaban� i�lemlerimiz i�in EntityFramework Core kullan�yorsak, kullan�lan DbContext'leri de Containera kaydedebilir ve DbContext'ler i�in de dependency injection uygulayabiliriz. DbContext'leri containera kaydetmek i�in AddDbContext methodunu kullan�r�z. �rnek : services.AddDbContext<MyDbContext>();



Containera kay�tl� servislerin kullan�m� i�in IServiceCollection'�n yada herhangi bir methodun kullan�m�na ihtiya� yoktur. ConfigureServices i�erisinde containera kay�t edilen t�m servisler, yukar�daki �rnekte oldu�u gibi Controller s�n�flar�n yap�c� methodlar�nda belirtilerek kullan�labilirler. Controller s�n�flar� �zel s�n�flar oldu�undan nesnelerinin yarat�lmas� s�ras�nda ba��ml�l�klar� container �zerinden otomatik olarak ��z�lerek yarat�l�rlar.

 
 */
