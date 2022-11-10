using System.Linq.Expressions;

namespace GHGHGym.Infrastructure.Data.Common
{
    /// <summary>
    /// Abstraction of repository access methods
    /// </summary>
    
    ////TODO: IMPLEMENT MY OWN REPOSITORY PATTERN USING NIKI'S TEMPLATE AND STAMO'S REPOSITORY
    public interface IRepository<T> : IDisposable
         where T : class
    {
        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All();

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All(Expression<Func<T, bool>> search);

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly();

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search);

        /// <summary>
        /// Gets specific record from database by primary key
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        Task<T> GetByIdAsync(object id);

        Task<T> GetByIdsAsync(object[] id);

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Ads collection of entities to the database
        /// </summary>
        /// <param name="entities">Enumerable list of entities</param>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Updates a record in database
        /// </summary>
        /// <param name="entity">Entity for record to be updated</param>
        void Update(T entity);

        /// <summary>
        /// Updates set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="id">Identificator of record to be deleted</param>
        Task DeleteByIdAsync(object id);

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="entity">Entity representing record to be deleted</param>
        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);
        void DeleteRange(Expression<Func<T, bool>> deleteWhereClause);


        /// <summary>
        /// Detaches given entity from the context
        /// </summary>
        /// <param name="entity">Entity to be detached</param>
        void Detach(T entity);

        /// <summary>
        /// Saves all made changes in trasaction
        /// </summary>
        /// <returns>Error code</returns>
        Task<int> SaveChangesAsync();
    }
}