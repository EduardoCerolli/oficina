using NHibernate;
using System.Linq.Expressions;

namespace Oficina.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public T? Get(long id)
        {
            return session.Get<T>(id);
        }

        public IEnumerable<T> List(Expression<Func<T, bool>>? filter)
        {
            IQueryable<T> query;
            query = session.Query<T>();
            if (filter != null)
                query = query.Where(filter);
            return query.ToList();
        }

        public void SaveOrUpdate(T entity)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete(T entity)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public bool Exists(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query;
            query = session.Query<T>();
            return query.Any(filter);
        }
    }
}
