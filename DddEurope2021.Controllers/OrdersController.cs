using DddEurope2021.UseCases.CQRS.Orders.Commands;
using DddEurope2021.UseCases.CQRS.Orders.Queries.GetOrderTotal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DddEurope2021.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;
        public OrdersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<OrderTotalDto> GetById(int id)
        {
            return await _sender.Send(new GetOrderTotalQuery(id));
        }

        [HttpPost]
        public async Task<int> CreateOrder(CreateOrderDto orderDto)
        {
            return await _sender.Send(new CreateOrderCommand(orderDto));
        }
    }
}
