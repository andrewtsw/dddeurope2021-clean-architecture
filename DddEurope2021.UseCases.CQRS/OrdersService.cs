using DddEurope2021.DataAccess.Interfaces;
using DddEurope2021.Integration.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DddEurope2021.UseCases.CQRS
{
    internal class OrdersService : IOrdersService
    {
        private readonly IDbContext _context;
        private readonly IOrdersIntegrationService _ordersIntegrationService;

        public OrdersService(IDbContext context,
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
