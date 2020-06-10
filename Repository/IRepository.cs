using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Learning.DesignPatterns.Infrastructure.Repository
{
    /// <summary>
    /// This is a contract for repositoy setup.
    /// </summary>
    /// <typeparam name="T">Repository type.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Context add method.
        /// </summary>
        /// <param name="entity">A sigle entity type.</param>
        /// <returns>Entity added value.</returns>
        T Add(T entity);

        /// <summary>
        /// Context update method.
        /// </summary>
        /// <param name="entity">Entity needing updated.</param>
        /// <returns>Entity of type inherited class.</returns>
        T Update(T entity);

        /// <summary>
        /// Context get method.
        /// </summary>
        /// <param name="id">Guid required.</param>
        /// <returns>Found entity.</returns>
        T Get(Guid id);

        /// <summary>
        /// Context all method.
        /// </summary>
        /// <returns>Enumberable of inherited class type.</returns>
        IEnumerable<T> All();

        /// <summary>
        /// Context find method.
        /// </summary>
        /// <param name="predicate">Method that defines a set of criteria and determines whether the specified object meets those criteria.</param>
        /// <returns>Enumberable of inherited class type.</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Context save method.
        /// </summary>
        void SaveChanges();
    }
}
