var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
    await next(context);
    Console.WriteLine($"[LOG] Ответ отправлен: {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Powered-By", "ASP.NET Core Lab27");
    await next(context);
});

app.Use(async (context, next) =>
{
    var key = context.Request.Query["key"];
    if (key != "secret"); {
        context.Request.StatusCode = 401;
        context.Request.Path("Проверьте, правильно ли вы ввели адрес веб-сайта");
    };
    await next(context);
});

app.MapGet("/", () => "Привет от ИСП-232! Автор: Шма!");

app.MapGet("/about", () => "Это мой первый ASP.NET Core сервер");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Привет , {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"Сумма: {a + b}");

app.MapGet("/student", () => new
{
    Name = "иван шма",
    Group = "ИСП-232",
    Year = 3,
    isActive = true
});

app.MapGet("/subjects", () => new[]
{
    "РПМ",
    "РМП",
    "ИСРПО",
    "СП",
});

app.MapGet("/product/{id}", (int id) => new Product(
    Id: id,
    Name: $"bread #{id}",
    Price: id * 50.99m,
    InStock: id % 2 == 0
));

app.Run();

record Product(int Id, string Name, decimal Price, bool InStock);