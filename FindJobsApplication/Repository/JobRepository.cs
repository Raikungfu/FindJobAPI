using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private readonly ApplicationContext _db;

        public JobRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Job job)
        {
            var objFromDb = _db.Jobs.FirstOrDefault(s => s.JobId == job.JobId);
            if (objFromDb != null)
            {
                objFromDb.Title = job.Title;
                objFromDb.Description = job.Description;
                objFromDb.Salary = job.Salary;
                objFromDb.Amount = job.Amount;
                objFromDb.Location = job.Location;
                objFromDb.Description = job.Description;
                objFromDb.DateFrom = job.DateFrom;
                objFromDb.DateTo = job.DateTo;
                objFromDb.JobCategoryId = job.JobCategoryId;
                objFromDb.JobType = job.JobType;
                
            }
            else
            {
                throw new Exception("JobApply not found");
            }
        }
    }
}
