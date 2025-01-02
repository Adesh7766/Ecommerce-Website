using Ecommerce.Data_Access_Layer;
using Ecommerce.Model;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }


        //Gets the List of products from database
        [HttpGet]
        [Route("api/products")]
        public List<Products> GetProducts()
        {
            return _productRepo.GetProducts();
        }

        //Gets the List of products from database ProductID
        [HttpGet("{id}")]
        public Products? GetProduct(int id)
        {
            return _productRepo.GetProductById(id);
        }

        //Add a new product
        [HttpPost]
        public IActionResult AddProduct([FromBody] Products product)
        {
            _productRepo.AddProduct(product);
            return Ok("Product added successfully");
        }

        //Update Stock of a product selected according to its id
        [HttpPut("{id}")]
        public IActionResult UpdateStock(int id, [FromBody] int stock)
        {
            _productRepo.UpdateStock(stock, id);
            return Ok("Stock updated successfully.");
        }

        //Delete Product, selected by its id
        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            _productRepo.DeleteProductById(id);
            return Ok("Product deleted successfully");
        }

        //Get list of product according to category
        [HttpGet]
        [Route("api/products/{categoryid}")]
        public List<Products> GetProductsByCategory(int categoryid)
        {
            return _productRepo.GetProductByCategory(categoryid);
        }

        //Get product with price range
        [HttpGet]
        [Route("api/products/SelectByPriceRange")]
        public Products? GetProductByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _productRepo.GetProductByPriceRange(minPrice, maxPrice);
        }

        ////Get product order by maximum Stock
        [HttpGet]
        [Route("api/products/OrderByStock")]
        public List<Products> GetProductByStock()
        {
            return _productRepo.GetProductByStock();
        }

        //Get product by product name
        [HttpGet]
        [Route("api/products/ByName")]
        public Products? GetProductByName(string name)
        {
            return _productRepo.GetProductByName(name);
        }
    }
}
