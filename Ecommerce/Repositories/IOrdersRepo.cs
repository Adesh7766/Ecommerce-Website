using Ecommerce.Model;

namespace Ecommerce.Repositories
{
    public interface IOrdersRepo
    {
        //Get all orders
        List<Orders> GetOrders();

        ////Get order by ID
        //void GetOrderById(int id);

        //Create new order
        void CreateOrder(int customerId, DateTime orderDate);

        ////Update Order Status
        //void UpdateOrderStatus(int id);

        ////Get orders by Customers
        //void OrdersByCustomers(int customerID);

        ////Get orders by date range
        //void OrdersByDateRange(DateTime startDate, DateTime endDate);
    }
}
