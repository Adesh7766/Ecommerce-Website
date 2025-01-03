using Ecommerce.Data_Access_Layer;
using Ecommerce.Model;

namespace Ecommerce.Repositories
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public OrdersRepo(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public List<Orders> GetOrders()
        {
            return _applicationDBContext.Orders.ToList();
        }

        public void CreateOrder(int customerId, DateTime orderDate)
        {
            
        }
    }
}
