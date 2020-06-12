using Learning.DesignPatterns.Domain.Models;
using Learning.DesignPatterns.Infrastructure.Contexts;
using Learning.DesignPatterns.Infrastructure.Repository.Implementation;

namespace Learning.DesignPatterns.Infrastructure.Repositories.Implementation
{
    /// <summary>
    /// Customer Repository.
    /// </summary>
    public class CustomerRepository : BaseRepository<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">Benjamin Friske context.</param>
        public CustomerRepository(SQLServerContext context)
            : base(context)
        {
        }
    }
}
