using FreelancePlatform.Domain.Entities;
using FreelancePlatform.Domain.Interfaces;
using System.Collections.Generic;

namespace FreelancePlatform.BLL.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        // Dependency Injection (IoC) - мы не создаем репозиторий тут, а получаем его
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Order> GetAllOrders() => _repository.GetAll();
        
        public Order GetOrder(int id) => _repository.GetById(id);
        
        public void AddOrder(Order order)
        {
            // Здесь могла бы быть бизнес-логика (например, проверка бюджета)
            _repository.Create(order);
            _repository.Save();
        }

        public void UpdateOrder(Order order)
        {
            _repository.Update(order);
            _repository.Save();
        }

        public void DeleteOrder(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}