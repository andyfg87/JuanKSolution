using DeliveryApp.API.Interfaces;
using JuanK.Persintence.EF;
using JuanK.Persintence.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeliveryApp.API.Repositories
{
    public class EntityRepository<TEntity, TKey> : IEntityRepository<TEntity, TKey>
     where TEntity : class, IEntity<TKey>
    {

        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
        public async Task UpdateAsync(TEntity entity) => _dbSet.Update(entity);
        public async Task DeleteAsync(TKey id) => _dbSet.Remove(await GetByIdAsync(id));
        public async Task<TEntity> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (filter != null) query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(
                new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            return orderBy != null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            return query;
        }

        public Task<IQueryable<TEntity>> GetAllWithInclude(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAllWithNestedInclude(params string[] includeProperties)
        {
            throw new NotImplementedException();
        }
    }
}
