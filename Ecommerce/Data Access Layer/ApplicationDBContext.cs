using Ecommerce.Controllers;
using Ecommerce.DTO_View_Model_;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data_Access_Layer
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
        }
        
        public DbSet<Products> Products {  get; set; }  

        public DbSet<Category> Category { get; set; }

        public DbSet<CategoryInsights> CategoryInsights { get; set; }

        public DbSet<CategoryByMostSales> CategoryByMostSales { get; set; }

    }
}
