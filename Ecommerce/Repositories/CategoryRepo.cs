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
    }
}
