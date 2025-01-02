using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }

        //In this property datatype with table is not matching
        //public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
