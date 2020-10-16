using System.Threading.Tasks;

namespace DddEurope2021.UseCases.Interfaces
{
    public interface IOrdersService
    {
        Task<GetOrderTotalDto> GetOrderTotalAsync(int id);

        Task<int> CreateOrder(CreateOrderDto orderDto);
    }
}
