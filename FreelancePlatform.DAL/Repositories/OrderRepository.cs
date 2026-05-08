using FreelancePlatform.Domain.Entities;
using FreelancePlatform.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FreelancePlatform.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll() => _context.Orders.ToList();
        
        public Order GetById(int id) => _context.Orders.Find(id);
        
        public void Create(Order order) => _context.Orders.Add(order);
        
        public void Update(Order order) => _context.Entry(order).State = EntityState.Modified;
        
        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null) _context.Orders.Remove(order);
        }

        public void Save() => _context.SaveChanges();
    }
}