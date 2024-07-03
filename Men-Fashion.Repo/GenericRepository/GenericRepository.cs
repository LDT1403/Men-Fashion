
using Men_Fashion.Repo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Men_Fashion.Repo.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MenShopContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(MenShopContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            T delete = _dbSet.Find(id);
            if (delete != null)
            {
                _dbSet.Remove(delete);
                _context.SaveChanges();
            }
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }


        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            return query.ToList();
        }

        public T getID(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            //_dbSet.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);

        }
    }
}
