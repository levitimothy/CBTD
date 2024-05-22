using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //get object by its key id
        T GetById(int? id);

        /* 
         *  The following method will return a set of objects using an Expression filter (similar to a WHERE clause in SQL)
         *  Func<T, bool> represents a function that takes an object of generic type T and returns a bool on whether filter exists or not*
         *  Expression<Func<T>> is a description of a function as an expression tree.
         *  https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/expression-trees/expression-trees-explainedLinks to an external site.
         *  The expression is commonly referred to as a predicate and is used to verify a condition on an object.
         *  https://learn.microsoft.com/en-us/dotnet/api/system.predicate-1?view=net-7.0Links to an external site.
         *  *The advantage is that Func<T> can be evaluated and compiled at run time and translated to other languages e.g. SQL in LINQ to SQL.
         *  trackChanges is used to flag whether we want EF to help track changes between read and write (tracking is normally set to true, but adds additional overhead, so if we do not need to track changes, we set to false)
         *  Includes will be used similarly to a SQL JOIN to “connect and relate to” other objects (PK-FK)
        */
        T Get(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null);

        // Returns an Enumerable list of results to iterate through.
        // Espression is the same as before (where clause)
        // a second expression is added for order by and column is int
        // Includes allows JOINS
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, int>>? orderBy = null, string? includes = null);
        //same as GetAll by asynchronous call
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, int>>? orderBy = null, string? includes = null);

        //add a new instance of the object
        void Add(T entity);
        //delete (Remove) a single instance of an ovject
        void Delete(T entity);
        //delete (remove) a range of items in an object
        void Delete(IEnumerable<T> entities);
        //update changes to an object
        void Update(T entity);
    }
}
