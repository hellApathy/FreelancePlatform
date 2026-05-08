using FreelancePlatform.DAL;
using FreelancePlatform.DAL.Repositories;
using FreelancePlatform.Domain.Interfaces;
using FreelancePlatform.BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Добавляем поддержку контроллеров (важно для п.8 вашего задания)
builder.Services.AddControllers();

// 2. Настройка БД (SQLite для простоты разработки)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=freelance.db"));

// 3. Настройка IoC (Dependency Injection) - это п.5 вашего задания!
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();

// 4. Оставляем OpenAPI для удобного тестирования в браузере
builder.Services.AddOpenApi();

var app = builder.Build();

// Настройка HTTP конвейера
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Подключаем маршрутизацию к нашим контроллерам
app.MapControllers();

app.Run();