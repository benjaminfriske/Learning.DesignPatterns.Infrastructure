using Microsoft.EntityFrameworkCore;

namespace Learning.DesignPatterns.Infrastructure.Contexts
{
    /// <summary>
    /// Database benjamin friske context.
    /// </summary>
    public class BenjaminFriskeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=orders.db");
        }
    }
}
