using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts
{
    public class RannaDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=Task2Db;Port=5432;User Id=postgres;Password=12345");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
      
    }
}
