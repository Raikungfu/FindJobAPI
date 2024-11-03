using FindJobsApplication.Models;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}