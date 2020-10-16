using DddEurope2021.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DddEurope2021.UseCases.CQRS.Orders.Queries.GetOrderTotal
{
    internal class GetOrderTotalQueryHandler : IRequestHandler<GetOrderTotalQuery, OrderTotalDto>
    {
        private readonly IDbContext _context;

        public GetOrderTotalQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<OrderTotalDto> Handle(GetOrderTotalQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == request.Id);

            return new OrderTotalDto
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
    }
}
