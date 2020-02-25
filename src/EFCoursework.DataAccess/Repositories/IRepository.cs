using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCoursework.DataAccess.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
