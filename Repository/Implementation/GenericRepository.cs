using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Learning.DesignPatterns.Infrastructure.Contexts;

namespace Learning.DesignPatterns.Infrastructure.Repository.Implementation
{
    class GenericRepository<T>
        : IRepository<T> where T : class
    {
        protected BenjaminFriskeContext context;

        public GenericRepository(BenjaminFriskeContext context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            return context
                .Add(entity)
                .Entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public virtual T Get(Guid id)
        {
            return context.Find<T>(id);
        }

        public virtual IEnumerable<T> All()
        {
            return context.Set<T>()
                .ToList();
        }

        public virtual T Update(T entity)
        {
            return context.Update(entity)
                .Entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
