using DddEurope2021.BackgroundJobs.Interfaces;
using DddEurope2021.DataAccess.Interfaces;
using DddEurope2021.Domain;
using DddEurope2021.Integration.Interfaces;
using DddEurope2021.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DddEurope2021.UseCases.Implementation
{
    public class OrdersService : IOrdersService
    {
        private readonly IDbContext _context;
        private readonly IBackgroundJobService _backgroundJobService;

        public OrdersService(IDbContext context, 
            IBackgroundJobService backgroundJobService)
        {
            _context = context;
            _backgroundJobService = backgroundJobService;
        }

        public async Task<int> CreateOrder(CreateOrderDto orderDto)
        {
            var order = CreateOrderFromDto(orderDto);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            _backgroundJobService.EnqueueCreateOrder(order.Id);

            return order.Id;
        }

        public async Task<GetOrderTotalDto> GetOrderTotalAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == id);

            return new GetOrderTotalDto 
            {
                Id = order.Id,
                Comment = order.Comment,
                ExternalId = order.ExternalId,
                SubTotal = order.CalculateDiscount(),
                Tax = order.CalculateTax(),
                Discount = order.CalculateDiscount(),
                Total = order.CalculateTotalPrice()
            };
        }

        private Order CreateOrderFromDto(CreateOrderDto orderDto)
        {
            return new Order
            {
                Comment = orderDto.Comment,
                OrderItems = orderDto.OrderItems.Select(itemDto => new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    UnitPrice = itemDto.UnitPrice,
                    Quantity = itemDto.Quantity

                }).ToList()
            };
        }
    }

    public class OrdersService1 : IOrdersService1
    {
        private readonly IDbContext _context;
        private readonly IOrdersIntegrationService _ordersIntegrationService;

        public OrdersService1(IDbContext context,
            IOrdersIntegrationService ordersIntegrationService)
        {
            _context = context;
            _ordersIntegrationService = ordersIntegrationService;
        }

        public async Task CreateExternalOrderAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == orderId);

            var externalId = await _ordersIntegrationService.SendOrderAsync(order);
            order.ExternalId = externalId;
            await _context.SaveChangesAsync();
        }
    }
}
