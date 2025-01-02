using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Ecommerce.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int stock { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
