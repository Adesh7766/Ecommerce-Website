using Ecommerce.DTO_View_Model_;
using Ecommerce.Model;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        //Get all Customers
        [HttpGet]
        [Route("GetAllCustomers")]
        public List<Customer> GetCustomers()
        {
            return _customerRepo.GetCustomers();
        }

        //Get Customer by id
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public Customer GetCustomerById(int id)
        {
            return _customerRepo.GetCustomerById(id);
        }

        //Get active Customers
        [HttpGet]
        [Route("GetActiveCustomers")]
        public List<Customer> GetActiveCustomers()
        {
            return _customerRepo.GetActiveCustomers();
        }

        //Get Customers order by most orders made
        [HttpGet]
        [Route("GetCustomersOrderByOrdersMade")]
        public List<CustomersByMostOrdersMade> GetCustomersByMostOrders()
        {
            return _customerRepo.GetCustomerOrderHistory();
        }

        //Get most ordering customer
        [HttpGet]
        [Route("MostOrdermakingCustomer")]
        public CustomersByMostOrdersMade MostOrderingCustomer()
        {
            return _customerRepo.MostOrderingCustomer();
        }

        //Get Customer order details by id
        [HttpGet]
        [Route("OrderDetailsById/{id}")]
        public CustomersByMostOrdersMade GetCustomerByOrderDetails(int id)
        {
            return _customerRepo.GetCustomerByOrderDetails(id);
        }

        //Get Customer by spending range
        [HttpGet]
        [Route("CustomerBySpendingRange")]
        public List<CustomerBySpendingRange> GetCustomersBySpendingRange(decimal minPrice, decimal maxPrice)
        {
            return _customerRepo.GetCustomerBySpending(minPrice, maxPrice);
        }

        //Update Customer Activeness
        [HttpPut]
        [Route("UpdateIsActive/{id}/{isActive}")]
        public IActionResult UpdateCustomerProfile(int id, Boolean isActive)
        {
            _customerRepo.UpdateCustomerProfile(id, isActive);
            return Ok("Activeness updated successfully");
        }

        //Delete Customer
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
            return Ok("Customer deleted successfully");
        }
    }
}
