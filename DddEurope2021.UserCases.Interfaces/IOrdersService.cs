using System.Threading.Tasks;

namespace DddEurope2021.UseCases.Interfaces
{
    public interface IOrdersService
    {
        Task<decimal> CalculateOrderTotalAsync(int id);
    }
}
