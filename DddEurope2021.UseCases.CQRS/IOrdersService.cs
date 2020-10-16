using System.Threading.Tasks;

namespace DddEurope2021.UseCases.CQRS
{
    public interface IOrdersService
    {
        Task CreateExternalOrderAsync(int id);
    }
}
