using Learning.DesignPatterns.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.DesignPatterns.Infrastructure.Contexts
{
    /// <summary>
    /// Database benjamin friske context.
    /// </summary>
    public class BenjaminFriskeContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=orders.db");
        }
    }
}
