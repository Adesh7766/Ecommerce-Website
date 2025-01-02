using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTO_View_Model_
{
    public class CategoryInsights
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public decimal AveragePrice { get; set; }
        public int TotalStock { get; set; }
    }
}
