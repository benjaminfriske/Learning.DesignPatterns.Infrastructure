namespace Learning.DesignPatterns.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// This is a contract for repositoy setup.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IRepository<T>
    {
        /// <summary>
        /// Context add method.
        /// </summary>
        /// <param name="entity">A sigle entity type.</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> All();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        void SaveChanges();
    }
}
