using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public virtual T Get(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (!string.IsNullOrEmpty(includes)) // If other objects to include (join)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }
            if (!trackChanges) // If we do not want EF tracking changes
            {
                queryable = queryable.AsNoTracking();
            }
            return queryable.FirstOrDefault(predicate);
        }


        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, int>>? orderBy = null, string? includes = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            if (orderBy != null)
            {
                queryable = queryable.OrderBy(orderBy);
            }
            return queryable.ToList();
        }


        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, int>>? orderBy = null, string? includes = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            if (orderBy != null)
            {
                queryable = queryable.OrderBy(orderBy);
            }
            return await queryable.ToListAsync();
        }


        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null)
        {
            if (includes == null)
            {
                if (!trackChanges)
                {
                    return await _dbContext.Set<T>().Where(predicate).AsNoTracking().FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
                }
            }
            else
            {
                IQueryable<T> queryable = _dbContext.Set<T>();
                foreach (var includeProperty in includes.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (!trackChanges)
                {
                    return queryable.Where(predicate).AsNoTracking().FirstOrDefault();
                }
                else
                {
                    return queryable.Where(predicate).FirstOrDefault();
                }
            }
        }

        public virtual T GetById(int? id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            //for track change im flagging modified to the system
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
