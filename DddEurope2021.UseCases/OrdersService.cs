using DddEurope2021.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DddEurope2021.UseCases
{
    public class OrdersService : IOrdersService
    {
        private readonly IDbContext _context;
        public OrdersService(IDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> CalculateOrderTotalAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync();

            return order.CalculateTotalPrice();
        }
    }
}
