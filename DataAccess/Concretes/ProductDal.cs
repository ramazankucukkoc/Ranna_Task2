using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Repository;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class ProductDal : EfEntityRepositoryBase<Product, RannaDbContext>, IProductDal
    {
        public List<Product> GetAllWithCategory()
        {
            using (RannaDbContext context = new RannaDbContext())
            {
                return context.Products.Include(p => p.Category).ToList();
            }
        }

        public List<Product> GetAllWithCategory(string productName)
        {
            using (RannaDbContext context = new RannaDbContext())
            {
                return context.Products.Include(p => p.Category)
                    .Where(p => p.Name.ToLower().Contains(productName.ToLower())).ToList();
            }
        }
    }
}
