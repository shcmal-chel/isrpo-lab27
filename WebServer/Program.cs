var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Привет от ИСП-232! Автор: Шма!");

app.MapGet("/about", () => "Это мой первый ASP.NET Core сервер");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Привет , {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"Сумма: {a + b}");

app.Run();
