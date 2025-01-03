using Ecommerce.Model;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepo _ordersRepo;

        public OrdersController(IOrdersRepo ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        [HttpGet]
        [Route("GetOrders")]
        public List<Orders> GetOrders()
        {
            return _ordersRepo.GetOrders();
        }
    }
}
