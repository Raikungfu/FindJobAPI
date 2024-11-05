using FindJobsApplication.Models;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IJobApplyRepository : IRepository<JobApply>
    {
        void Update(JobApply jobApply);
        Task<JobApply> UpdateStatusAsync(JobApply jobApply);
    }
}