using MediatR;

namespace DddEurope2021.UseCases.CQRS.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderCommand(CreateOrderDto orderDto)
        {
            OrderDto = orderDto;
        }

        public CreateOrderDto OrderDto { get; }
    }
}
