using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Domain.SeedWork;

namespace TaskManagement.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly TaskManagementContext _context;
        internal readonly DbSet<T> _set;

        public IUnitOfWork UnitOfWork => _context;
        public GenericRepository(TaskManagementContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }

        //public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        //{
        //    var any = await _set.AnyAsync(predicate);
        //    return any;
        //}

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            var data = await _set.ToListAsync();
            return data;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var data = await _set.FirstOrDefaultAsync(predicate);
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _set.FindAsync(id);
            return data;
        }

        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        //private IEnumerable<T> Include(params string[] includes)
        //{
        //    IEnumerable<T> query = null;
        //    foreach (var include in includes)
        //    {
        //        query = _set.Include(include);
        //    }
        //    return query ?? _set;
        //}
    }
}
