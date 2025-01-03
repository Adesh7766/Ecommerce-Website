using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTO_View_Model_
{
    public class CustomerBySpendingRange
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal TotalSpending { get; set; }
    }
}
