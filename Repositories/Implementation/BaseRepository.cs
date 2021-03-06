﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Learning.DesignPatterns.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Learning.DesignPatterns.Infrastructure.Repository.Implementation
{
    /// <summary>
    /// Generic repository.
    /// </summary>
    /// <typeparam name="T">Repository type.</typeparam>
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// The generic contexts used for all who inherit.
        /// </summary>
        protected DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">Entity framework default context.</param>
        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Virtual add method to be overidden by repsoitory that inherits this class.
        /// </summary>
        /// <param name="entity">Any entity type.</param>
        /// <returns>Entity added value.</returns>
        public virtual T Add(T entity)
        {
            return this.context.Add(entity).Entity;
        }

        /// <summary>
        /// Virtual Find method to be overidden by repsoitory that inherits this class.
        /// </summary>
        /// <param name="predicate">Method that defines a set of criteria and determines whether the specified object meets those criteria.</param>
        /// <returns>Found entity.</returns>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        /// <summary>
        /// Virtual get method to be overidden by repsoitory that inherits this class.
        /// </summary>
        /// <param name="id">Guid of the entity.</param>
        /// <returns>Entity found by guid.</returns>
        public virtual T Get(Guid id)
        {
            return this.context.Find<T>(id);
        }

        /// <summary>
        /// Virtual all method to be overidden by repsoitory that inherits this class.
        /// </summary>
        /// <returns>Set of entities found.</returns>
        public virtual IEnumerable<T> All()
        {
            return this.context.Set<T>().ToList();
        }

        /// <summary>
        /// Virtual update method to be overidden by repsoitory that inherits this class.
        /// </summary>
        /// <param name="entity">Entity needing updated.</param>
        /// <returns>Updated entity.</returns>
        public virtual T Update(T entity)
        {
            return this.context.Update(entity).Entity;
        }

        /// <summary>
        /// Virtual save method to be overidden by repsoitory that inherits this class.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
