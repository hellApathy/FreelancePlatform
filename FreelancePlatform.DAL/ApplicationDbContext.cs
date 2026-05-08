using FreelancePlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore; // <-- Вот эта строка обязательна!

namespace FreelancePlatform.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
    }
}