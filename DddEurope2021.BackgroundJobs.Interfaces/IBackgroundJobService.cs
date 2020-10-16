namespace DddEurope2021.BackgroundJobs.Interfaces
{
    public interface IBackgroundJobService
    {
        void EnqueueCreateOrder(int orderId);
    }
}
