using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Learning.DesignPatterns.Domain.Models;
using Learning.DesignPatterns.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Learning.DesignPatterns.Infrastructure.Repository.Implementation
{
    /// <summary>
    /// Order repository to get orders.
    /// </summary>
    class OrderRepository : BaseRepository<Order>
    {
        public SQLServerContext SqlServerContext
        {
            get { return context as SQLServerContext; }
        }

        public OrderRepository(SQLServerContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="predicate">Method that defines a set of criteria and determines whether the specified object meets those criteria.</param>
        /// <returns>Found entity.</returns>
        public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return this.SqlServerContext.Orders
                .Include(order => order.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Where(predicate).ToList();
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="entity">Order entity.</param>
        /// <returns>Saved order entity.</returns>
        public override Order Update(Order entity)
        {
            var order = this.SqlServerContext.Orders
                .Include(o => o.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Single(o => o.OrderId == entity.OrderId);

            order.OrderDate = entity.OrderDate;
            order.LineItems = entity.LineItems;

            return base.Update(order);
        }
    }
}
