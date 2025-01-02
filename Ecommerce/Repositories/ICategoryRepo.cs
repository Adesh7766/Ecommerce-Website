using Ecommerce.DTO_View_Model_;
using Ecommerce.Model;

namespace Ecommerce.Repositories
{
    public interface ICategoryRepo
    {
        //Get details of all available categories
        List<Category> GetCategoryDetails();

        //Get insights on categories(total products, average price, total sales)
        List<CategoryInsights> GetCategoryInsight();

        //Get insights on categories(total products, average price, total sales) by id
        CategoryInsights? GetCategoryInsightById(int categoryId);

        ////Create a new category(By Admin)
        //void CreateCategory(Category category);

        ////Sort categories based on popularity(total sales)
        //void GetPopularCategory();
    }
}
