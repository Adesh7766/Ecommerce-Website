using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTO_View_Model_
{
    public class CustomersByMostOrdersMade
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TotalOrderMade { get; set; }
    }
}
