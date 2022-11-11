using GHGHGym.Infrastructure.Abstractions.Contracts;
using System.Linq.Expressions;

namespace GHGHGym.Infrastructure.Data.Common.Repositories.Contracts
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> AllExpression(Expression<Func<TEntity, bool>> search);
        IQueryable<TEntity> AllReadonly();
        IQueryable<TEntity> AllReadonlyExpression<T>(Expression<Func<TEntity, bool>> search);
        IQueryable<TEntity> AllWithDeleted();
        IQueryable<TEntity> AllReadonlyWithDeleted();

        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> GetByIdsAsync(object[] id);

        void HardDelete(TEntity entity);
        void SetDeleted(TEntity entity);
        Task SetDeletedByIdAsync(object id);
        void SetDeletedRange(IEnumerable<TEntity> entities);
        void SetDeletedRange(Expression<Func<TEntity, bool>> deleteWhereClause);
        void Undelete(TEntity entity);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        Task<int> SaveChangesAsync();
    }
}
