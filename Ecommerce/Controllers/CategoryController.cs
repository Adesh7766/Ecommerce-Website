using Ecommerce.DTO_View_Model_;
using Ecommerce.Model;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        //Get list of categories available
        [HttpGet]
        [Route("GetAllCategory")]
        public List<Category> GetCategories()
        {
            return _categoryRepo.GetCategoryDetails();
        }

        //Get insight on categories
        [HttpGet]
        [Route("GetInsights")]
        public List<CategoryInsights> GetCategoryInsight()
        {
            return _categoryRepo.GetCategoryInsight();
        }

        //Get insight on categories by id
        [HttpGet]
        [Route("GetInsightbyId")]
        public CategoryInsights? GetCategoryInsightsById(int categoryId)
        {
            return _categoryRepo.GetCategoryInsightById(categoryId);
        }

        //Add new category
        [HttpPost]
        [Route("AddNewCategory")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _categoryRepo.CreateCategory(category);
            return Ok(category);
        }

        //Get list of category based on popularity(most sales)
        [HttpGet]
        [Route("OrderedByMostSales")]
        public List<CategoryByMostSales> GetCategoryByMostSales()
        {
            return _categoryRepo.GetPopularCategory();
        }
    }
}
