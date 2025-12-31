using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using gLiter.Core.Models;

namespace gLiter.Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<PagedResult<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? predicate = null);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}
