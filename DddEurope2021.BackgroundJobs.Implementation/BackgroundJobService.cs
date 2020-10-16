using DddEurope2021.BackgroundJobs.Interfaces;
using DddEurope2021.UseCases.Interfaces;
using Hangfire;

namespace DddEurope2021.BackgroundJobs.Implementation
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly IOrdersService _ordersService;

        public BackgroundJobService(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public void EnqueueCreateOrder(int orderId)
        {
            BackgroundJob.Enqueue(() => _ordersService.CreateExternalOrderAsync(orderId));
        }
    }
}
