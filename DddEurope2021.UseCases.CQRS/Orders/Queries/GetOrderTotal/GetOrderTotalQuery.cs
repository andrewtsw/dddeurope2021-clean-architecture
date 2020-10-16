using MediatR;

namespace DddEurope2021.UseCases.CQRS.Orders.Queries.GetOrderTotal
{
    public class GetOrderTotalQuery : IRequest<OrderTotalDto>
    {
        public GetOrderTotalQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
