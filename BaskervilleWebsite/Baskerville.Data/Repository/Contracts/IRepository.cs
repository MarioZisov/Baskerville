using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Data.Contracts.Repository
{
    public interface IRepository<T> 
        where T : class
    {
        T GetById(object id);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        bool Exists(Expression<Func<T, bool>> predicate);

        bool Exists();

        T GetFirst(Expression<Func<T, bool>> predicate);

        T GetFirstOrNull(Expression<Func<T, bool>> predicate);
    }
}
