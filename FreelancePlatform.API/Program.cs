using FreelancePlatform.DAL;
using FreelancePlatform.DAL.Repositories;
using FreelancePlatform.Domain.Interfaces;
using FreelancePlatform.BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Подключаем контроллеры
builder.Services.AddControllers();

// Настройка БД
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=freelance.db"));

// Настройка Dependency Injection
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();

// Включаем генерацию Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем визуальный интерфейс SwaggerUI в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();