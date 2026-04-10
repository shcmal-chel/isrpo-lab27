var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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