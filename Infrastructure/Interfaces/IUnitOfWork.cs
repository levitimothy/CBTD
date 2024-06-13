using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Category> Category {  get; }
        public IGenericRepository<Manufacturer> Manufacturer { get; }
        public IGenericRepository<Product> Product { get; }
		public IGenericRepository<ApplicationUser> ApplicationUser { get; }
        public IGenericRepository<ShoppingCart> ShoppingCart { get; }
		int Commit();
        Task<int> CommitAsync();
    }
}
