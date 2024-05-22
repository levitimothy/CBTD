using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null, System.Linq.Expressions.Expression<Func<T, int>>? orderBy = null, string? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null, System.Linq.Expressions.Expression<Func<T, int>>? orderBy = null, string? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null)
        {
            throw new NotImplementedException();
        }

        public T GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
