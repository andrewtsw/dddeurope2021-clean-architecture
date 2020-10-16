using System.Threading.Tasks;

namespace DddEurope2021.UseCases.Interfaces
{
    public interface IOrdersService
    {
        Task<GetOrderTotalDto> GetOrderTotalAsync(int id);

        Task<int> CreateOrder(CreateOrderDto orderDto);
    }

    public interface IOrdersService1
    {
        Task CreateExternalOrderAsync(int id);
    }
}
