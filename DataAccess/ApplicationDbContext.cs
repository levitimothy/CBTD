using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }


        //inserting seed data when Model is physically created in the DB the first time
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Non-Alcoholic Beverages", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Wine", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Snacks", DisplayOrder = 3 }
               );

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Coca Cola" },
                new Manufacturer { Id = 2, Name = "The Casella Family" },
                new Manufacturer { Id = 3, Name = "Trinchero Family Estates" },
                new Manufacturer { Id = 4, Name = "Frito Lay" }
               );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Coca Cola Classic",
                    Description = "The primary taste of Coca-Cola is thought to come from vanilla and cinnamon, with trace amounts of essential oils, and spices such as nutmeg.",
                    ListPrice = 1.99,
                    UnitPrice = 1.49,
                    HalfDozenPrice = 1.24,
                    DozenPrice = .99,
                    Size = "33cl",
                    UPC = "4894034",
                    ImageUrl = "/images/products/Coke.jpg",
                    CategoryId = 1,
                    ManufacturerId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Yellow Tail Shiraz",
                    Description = "<p>The Yellow Tail Shiraz has a deep red color with bright purple hues, characteristic of fine young wines. It displays impressive <strong>spice, licorice, and black currant aromas</strong>. The palate is perfectly balanced with soft tannins and fine French Oak, further complemented by ripe fruit flavors.</p>",
                    ListPrice = 9.99,
                    UnitPrice = 8.99,
                    HalfDozenPrice = 7.99,
                    DozenPrice = 6.99,
                    Size = "750 ml",
                    UPC = "031259008943",
                    ImageUrl = "/images/products/YellowTail.png",
                    CategoryId = 2,
                    ManufacturerId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Menage a Trois Merlot",
                    Description = "Menage a Trois California Red Blend exposes the fresh, ripe, jam-like fruit that is the calling card of California wine. Forward, spicy and soft, this delicious dalliance makes the perfect accompaniment for grilled meats or chicken.",
                    ListPrice = 12.99,
                    UnitPrice = 11.49,
                    HalfDozenPrice = 10.75,
                    DozenPrice = 9.99,
                    Size = "750 ml",
                    UPC = "099988071096",
                    ImageUrl = "/images/products/menage.jpg",
                    CategoryId = 2,
                    ManufacturerId = 3
                },
                new Product
                {
                    Id = 4,
                    Name = "Doritos",
                    Description = "The chip that packs a flavorful punch with the classic crunch. Boldly seasoned with three cheeses, tomatoes, onions, and a savory blend of spices. Indulge yourself or share with large gatherings",
                    ListPrice = 1.99,
                    UnitPrice = 1.49,
                    HalfDozenPrice = 1.05,
                    DozenPrice = .69,
                    Size = "175 grams",
                    UPC = "028400443753",
                    ImageUrl = "/images/products/doritos.jpg",
                    CategoryId = 3,
                    ManufacturerId = 4
                },
                new Product
                {
                    Id = 5,
                    Name = "Cheetos",
                    Description = "The fun, crunchy snack that is made with real cheese. Packed with flavor that satisfies. Always a crowd favorite.",
                    ListPrice = 1.99,
                    UnitPrice = 1.49,
                    HalfDozenPrice = 1.05,
                    DozenPrice = .69,
                    Size = "200 grams",
                    UPC = "028400443661",
                    ImageUrl = "/images/products/cheetos.jpg",
                    CategoryId = 3,
                    ManufacturerId = 4
                });


        }


    }
}
