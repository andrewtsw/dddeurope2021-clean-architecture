using DddEurope2021.BackgroundJobs.Interfaces;
using MediatR;

namespace DddEurope2021.UseCases.CQRS.Orders.Events
{
    internal class OrderCreatedEventHandler : NotificationHandler<OrderCreated>
    {
        private readonly IBackgroundJobService _backgroundJobService;

        public OrderCreatedEventHandler(IBackgroundJobService backgroundJobService)
        {
            _backgroundJobService = backgroundJobService;
        }

        protected override void Handle(OrderCreated notification)
        {
            _backgroundJobService.EnqueueCreateOrder(notification.Id);

            //TODO: Call more services or add more handlers for this command.
        }
    }
}
