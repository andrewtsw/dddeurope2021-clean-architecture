using DddEurope2021.Domain;
using DddEurope2021.Integration.Interfaces;
using System.Threading.Tasks;

namespace DddEurope2021.Integration.Implementation
{
    public class OrdersIntegrationService : IOrdersIntegrationService
    {
        public Task<string> SendOrderAsync(Order order)
        {
            // TODO:
            return Task.FromResult($"external-id-{order.Id}");
        }
    }
}
