using Oficina.Models;
using System.Linq.Expressions;

namespace Oficina.Repositories
{
    public interface IRepository<T> where T : class
    {
        T? Get(long id);
        IEnumerable<T> List(Expression<Func<T, bool>>? filter);
        void SaveOrUpdate(T entity);
        void Delete(T entity);
        bool Exists(Expression<Func<T, bool>> filter);
    }
}
