using FreelancePlatform.DAL;
using FreelancePlatform.DAL.Repositories;
using FreelancePlatform.Domain.Interfaces;
using FreelancePlatform.BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Додаємо підтримку MVC (контролери + представлення)
builder.Services.AddControllersWithViews();

// Налаштовуємо підключення до БД
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=freelance.db"));

// Налаштовуємо IoC (Dependency Injection) для наших шарів
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Налаштування HTTP-конвеєра
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Папка wwwroot для стилів (CSS, JS)
app.MapStaticAssets(); 

// Маршрутизація за замовчуванням
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Автоматичне створення бази даних (якщо її ще немає) та додавання тестових даних
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
    
    // Додаємо тестове замовлення, щоб було що відображати
    if (!context.Orders.Any())
    {
        context.Orders.Add(new FreelancePlatform.Domain.Entities.Order 
        { 
            Title = "Розробити лендінг", 
            Description = "Потрібен сайт-візитка на React", 
            Budget = 500 
        });
        context.Orders.Add(new FreelancePlatform.Domain.Entities.Order 
        { 
            Title = "Написати парсер", 
            Description = "Парсер товарів з інтернет-магазину на Python", 
            Budget = 150 
        });
        context.SaveChanges();
    }
}

app.Run();