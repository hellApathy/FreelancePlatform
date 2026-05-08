using FreelancePlatform.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        // Отримуємо бізнес-логіку через конструктор (DI)
        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // Дія для відображення списку замовлень (GET: /Orders)
        public IActionResult Index()
        {
            // Отримуємо дані з шару BLL
            var orders = _orderService.GetAllOrders();
            
            // Передаємо дані у Представлення (View)
            return View(orders);
        }
    }
}