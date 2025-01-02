using Ecommerce.Model;

namespace Ecommerce.Repositories
{
    public interface IProductRepo
    {
        //Gets the List of products from database
        List<Products> GetProducts();

        //Gets the List of products from database ProductID
        Products? GetProductById(int id);

        //Add a new Product
        void AddProduct(Products product);

        //Update Product Stock
        void UpdateStock(int stock, int id);

        //Delete a Product
        void DeleteProductById(int id);

        //GET products by category
        List<Products> GetProductByCategory(int categoryid);

        //GET product with price range
        Products? GetProductByPriceRange(decimal maxPrice, decimal minPrice);
        
        //GET product order by maximum stock
        List<Products> GetProductByStock();

        //GET product by name
        Products? GetProductByName(string name);
    }
}
