using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Men_Fashion.Repo.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "",
           int? pageIndex = null,
           int? pageSize = null);
        T getID(object id);
        void Delete(int id);
        void Add(T entity);
        void Update(T entity);
    }
}
