using Ecommerce.Data_Access_Layer;
using Ecommerce.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public ProductRepo(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        //Gets the List of products from database
        public List<Products> GetProducts()
        {
            return _applicationDBContext.Products.ToList();
        }

        //Gets the List of products from database ProductID
        public Products? GetProductById(int id)
        {
            return _applicationDBContext.Products.FirstOrDefault(p => p.ProductId == id);
        }

        //Add a new product
        public void AddProduct(Products product)
        {
            Products newProduct = new Products()
            {
                ProductName = product.ProductName,

                CategoryId = product.CategoryId,
                
                Price = product.Price,

                stock = product.stock,

                CreatedAt = DateTime.Now
            };

            _applicationDBContext.Add(newProduct);

            _applicationDBContext.SaveChanges();
        }

        //Update product stock
        public void UpdateStock(int Stock, int id)
        {
            Products? product;
            product = _applicationDBContext.Products.FirstOrDefault(p => p.ProductId == id);

            product.stock = Stock;

            _applicationDBContext.SaveChanges();
        }

        //Delete product
        public void DeleteProductById(int id)
        {
            Products? product = _applicationDBContext.Products.FirstOrDefault(p => p.ProductId == id);

            _applicationDBContext.Remove(product);

            _applicationDBContext.SaveChanges();
        }

        //Get products by category
        public List<Products> GetProductByCategory(int categoryid)
        {
            return _applicationDBContext.Products.FromSql($"EXEC SelectByCategory {categoryid}").ToList();
        }

        //Get product with price range
        public Products? GetProductByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _applicationDBContext.Products.FromSql($"EXEC SelectByPriceRange {minPrice},{maxPrice}").AsEnumerable().FirstOrDefault();
        }

        //Get product order by maximum Stock
        public List<Products> GetProductByStock()
        {
            return _applicationDBContext.Products.FromSql($"EXEC ProductOrderByStock").ToList();
        }

        //Get product by name
        public Products? GetProductByName(string name)
        {
            return _applicationDBContext.Products.FirstOrDefault(p => p.ProductName == name);
        }
    }
}
