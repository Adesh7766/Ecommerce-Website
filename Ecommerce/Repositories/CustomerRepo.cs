using Ecommerce.Data_Access_Layer;
using Ecommerce.DTO_View_Model_;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public CustomerRepo(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        //Get all Customers
        public List<Customer> GetCustomers()
        {
            return _applicationDBContext.Customers.ToList();
        }

        //Get Customer by id
        public Customer? GetCustomerById(int id)
        {
            return _applicationDBContext.Customers.FirstOrDefault(x => x.CustomerID == id);
        }

        //Get Active Customer
        public List<Customer> GetActiveCustomers()
        {
            return _applicationDBContext.Customers.Where(x => x.isActive == true).ToList();
        }

        //Get Customers by order by most orders made
        public List<CustomersByMostOrdersMade> GetCustomerOrderHistory()
        {
            return _applicationDBContext.CustomersByMostOrders.FromSql($"EXEC CustomersByOrderHistory").ToList();
        }

        //Get Customer by order by most orders made by id
        public CustomersByMostOrdersMade? MostOrderingCustomer()
        {
            return _applicationDBContext.CustomersByMostOrders.FromSql($"EXEC CustomersByOrderHistory").AsEnumerable().FirstOrDefault();
        }

        //Get Customer Order Detials by id
        public CustomersByMostOrdersMade? GetCustomerByOrderDetails(int id)
        {
            return _applicationDBContext.CustomersByMostOrders.FromSqlRaw($"EXEC OrderDetailsByCustomerId {id}").AsEnumerable().FirstOrDefault();
        }

        //Get Customer by spending range
        public List<CustomerBySpendingRange>? GetCustomerBySpending(decimal minPrice, decimal maxPrice)
        {
            return _applicationDBContext.CustomerBySpendingRange.FromSql($"EXEC CustomersBySpendingRange {minPrice}, {maxPrice}").ToList();
        }

        //Update Customer Activeness
        public void UpdateCustomerProfile(int id, Boolean isActive)
        {
            //Customer newCustomer;
            //newCustomer = new Customer();

            var customer = _applicationDBContext.Customers.FirstOrDefault(x => x.CustomerID == id);

            customer.isActive = isActive;

            _applicationDBContext.SaveChanges();
        }

        //Delete Customer
        public void DeleteCustomer(int id)
        {
            var customer = _applicationDBContext.Customers.FirstOrDefault(x => x.CustomerID == id);

            _applicationDBContext.Customers.Remove(customer);

            _applicationDBContext.SaveChanges();
        }
    }
}
