using DddEurope2021.BackgroundJobs.Interfaces;
using DddEurope2021.DataAccess.Interfaces;
using DddEurope2021.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DddEurope2021.UseCases.CQRS.Orders.Commands
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IBackgroundJobService _backgroundJobService;

        public CreateOrderCommandHandler(IDbContext context,
            IBackgroundJobService backgroundJobService)
        {
            _context = context;
            _backgroundJobService = backgroundJobService;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = CreateOrderFromDto(request.OrderDto);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            _backgroundJobService.EnqueueCreateOrder(order.Id);

            return order.Id;
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
}
