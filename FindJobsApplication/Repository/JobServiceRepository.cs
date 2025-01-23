using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Repository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace FindJobsApplication.Repository
{
    public class JobServiceRepository : Repository<JobService>, IJobServiceRepository
    {
        private readonly ApplicationContext _db;

        public JobServiceRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(JobService jobService)
        {
            var objFromDb = _db.JobServices.FirstOrDefault(s => s.JobServiceId == jobService.JobServiceId);
            if (objFromDb != null)
            {
                objFromDb.ServiceName = jobService.ServiceName;
                objFromDb.Description = jobService.Description;
                if (!jobService.Image.IsNullOrEmpty())
                {
                    objFromDb.Image = jobService.Image;
                }
                objFromDb.Price = jobService.Price;
                objFromDb.Duration = jobService.Duration;
                objFromDb.Count = jobService.Count;
                objFromDb.jobServiceType = jobService.jobServiceType;
                objFromDb.AdminId = jobService.AdminId;

            }
            else
            {
                throw new Exception("JobApply not found");
            }
        }
    }
}