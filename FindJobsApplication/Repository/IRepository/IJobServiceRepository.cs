using FindJobsApplication.Models;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IJobServiceRepository : IRepository<JobService>
    {
        void Update(JobService jobService);
    }
}
