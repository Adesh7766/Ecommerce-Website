using Ecommerce.DTO_View_Model_;
using Ecommerce.Model;

namespace Ecommerce.Repositories
{
    public interface ICustomerRepo
    {
        //Get all customers
        List<Customer> GetCustomers();

        //Get Customer by id
        Customer GetCustomerById(int id);

        //Get active customers
        List<Customer> GetActiveCustomers();

        //Get Customers by order by most orders made
        List<CustomersByMostOrdersMade> GetCustomerOrderHistory();

        //Get Most ordering customer
        CustomersByMostOrdersMade MostOrderingCustomer();

        //Get Customer Order Detials by id
        CustomersByMostOrdersMade GetCustomerByOrderDetails(int id);

        //Get Customers by spending range
        List<CustomerBySpendingRange> GetCustomerBySpending(decimal minPrice, decimal maxPrice);

        //Update Customer Activeness
        void UpdateCustomerProfile(int id, Boolean isActive);

        //Delete any customer by id
        void DeleteCustomer(int id);
    }
}
