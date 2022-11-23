using GHGHGym.Infrastructure.Abstractions.Contracts;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GHGHGym.Infrastructure.Data.Common.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {

        public Repository(ApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }
        protected ApplicationDbContext Context { get; set; }

        public void Add(TEntity entity)
            => DbSet.Add(entity);

        public async Task AddAsync(TEntity entity)
            => await DbSet.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
            => await DbSet.AddRangeAsync(entities);
        public IQueryable<TEntity> All()
            => DbSet
            .Where(x => !x.IsDeleted)
            .AsQueryable();

        public IQueryable<TEntity> AllExpression(Expression<Func<TEntity, bool>> search)
            => DbSet.Where(search);

        public IQueryable<TEntity> AllReadonly()
            => DbSet
            .Where(x => !x.IsDeleted)
            .AsNoTracking();

        public IQueryable<TEntity> AllReadonlyExpression<T>(Expression<Func<TEntity, bool>> search)
            => DbSet
            .Where(search)
            .AsNoTracking();

        public IQueryable<TEntity> AllReadonlyWithDeleted()
            => DbSet.AsNoTracking();

        public IQueryable<TEntity> AllWithDeleted()
            => DbSet.AsQueryable();

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> GetByIdAsync(object id)
            => await DbSet.FindAsync(id) ?? throw new ArgumentNullException();

        public async Task<TEntity> GetByIdsAsync(params object[] id)
            => await DbSet.FindAsync(id) ?? throw new ArgumentNullException();

        public void HardDelete(TEntity entity)
            => DbSet.Remove(entity);

        public void HardDeleteRange(IEnumerable<TEntity> entities)
            => DbSet.RemoveRange(entities);

        public int SaveChanges()
            => Context.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await Context.SaveChangesAsync();

        public void SetDeleted(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            Update(entity);
        }

        public async Task SetDeletedByIdAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            Update(entity);
        }

        public void SetDeletedRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.UtcNow;
            }
            UpdateRange(entities);
        }

        public void SetDeletedRangeExpression(Expression<Func<TEntity, bool>> deleteWhereClause)
        {
            var entities = DbSet.Where(deleteWhereClause);
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.UtcNow;
            }
            UpdateRange(entities);
        }

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            Update(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }
    }
}
