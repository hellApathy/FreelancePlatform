using FreelancePlatform.BLL.Services;
using FreelancePlatform.Domain.Entities;
using FreelancePlatform.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View(_orderService.GetAllOrders());
        }

        // ================= СТВОРЕННЯ (CREATE) =================

        // GET: Orders/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Повертає порожню форму
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Захист від CSRF-атак
        public IActionResult Create(OrderViewModel model)
        {
            // Перевірка server-side validation (Пункт 5)
            if (ModelState.IsValid) 
            {
                // Перекладаємо дані з ViewModel у Domain Entity
                var order = new Order
                {
                    Title = model.Title,
                    Description = model.Description,
                    Budget = model.Budget
                };

                _orderService.AddOrder(order);
                return RedirectToAction(nameof(Index)); // Повертаємось до списку
            }

            // Якщо дані не валідні, повертаємо ту саму форму з помилками
            return View(model);
        }

        // ================= РЕДАГУВАННЯ (EDIT) =================

        // GET: Orders/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null) return NotFound();

            var model = new OrderViewModel
            {
                Id = order.Id,
                Title = order.Title,
                Description = order.Description,
                Budget = order.Budget
            };

            return View(model);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderViewModel model)
        {
            if (id != model.Id) return BadRequest();

            // Перевірка server-side validation
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Budget = model.Budget
                };

                _orderService.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}