using FindJobsApplication.Models;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IJobRepository : IRepository<Job>
    {
        void Update(Job job);
    }
}
