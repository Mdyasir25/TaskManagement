using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.SeedWork
{
    public interface IGenericRepository<T> where T: Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        Task<T> GetByIdAsync(int id, params string[] includes);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
