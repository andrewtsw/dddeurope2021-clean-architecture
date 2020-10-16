using DddEurope2021.Domain;
using System.Threading.Tasks;

namespace DddEurope2021.Integration.Interfaces
{
    public interface IOrdersIntegrationService 
    {
        Task<string> SendOrderAsync(Order order);
    }
}
