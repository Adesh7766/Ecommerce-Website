using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTO_View_Model_
{
    public class CategoryByMostSales
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int TotalSalesByProduct { get; set; }
    }
}
