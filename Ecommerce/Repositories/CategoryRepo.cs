using Ecommerce.Data_Access_Layer;
using Ecommerce.DTO_View_Model_;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public CategoryRepo(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        //Get list of all categories available
        public List<Category> GetCategoryDetails()
        {
            return _applicationDBContext.Category.ToList();
        }

        //Get insight on categories(average price, total stocks)
        public List<CategoryInsights> GetCategoryInsight()
        {
            return _applicationDBContext.CategoryInsights.FromSql($"EXEC CategoryInsight").AsEnumerable().ToList();
        }

        //Get insight on categories(average price, total stocks) by ID
        public CategoryInsights? GetCategoryInsightById(int categoryid)
        {
            return _applicationDBContext.CategoryInsights.FromSql($"EXEC CategoryInsightById @categoryid = {categoryid}").AsEnumerable().FirstOrDefault();
        }

        //Create a new category(By Admin)
        public void CreateCategory(Category category)
        {
            Category newCategory = new Category()
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            _applicationDBContext.Category.Add(newCategory);
            _applicationDBContext.SaveChanges();
        }

        //Sort categories based on popularity(total sales)
        public List<CategoryByMostSales> GetPopularCategory()
        {
            return _applicationDBContext.CategoryByMostSales.FromSql($"EXEC ListByMostSales").AsEnumerable().ToList();
        }

        //Remove category by id
        public void RemoveCategory(int id)
        {
            Category category = _applicationDBContext.Category.FirstOrDefault(x => x.CategoryID == id);

            _applicationDBContext.Remove(category);
            _applicationDBContext.SaveChanges();
        }
    }
}
