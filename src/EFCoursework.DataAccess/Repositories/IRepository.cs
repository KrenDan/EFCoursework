using EFCoursework.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCoursework.DataAccess.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task InsertAsync(params T[] entities);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
