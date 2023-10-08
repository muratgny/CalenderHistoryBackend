using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);

        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<T> Query();
        Task<int> Execute(FormattableString interpolatedQueryString);

        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);
        int GetCount(Expression<Func<T, bool>> expression = null);
        TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null);
    }
}
