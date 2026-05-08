using FreelancePlatform.Domain.Entities;
using System.Collections.Generic;

namespace FreelancePlatform.Domain.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
        void Save();
    }
}