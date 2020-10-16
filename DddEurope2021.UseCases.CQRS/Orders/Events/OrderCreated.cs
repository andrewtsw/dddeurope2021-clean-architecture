using MediatR;

namespace DddEurope2021.UseCases.CQRS.Orders.Events
{
    public class OrderCreated : INotification
    {
        public OrderCreated(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
