using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class JobApplyRepository : Repository<JobApply>, IJobApplyRepository
    {
        private readonly ApplicationContext _db;

        public JobApplyRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(JobApply jobApply)
        {
            var objFromDb = _db.JobApplies.FirstOrDefault(s => s.JobApplyId == jobApply.JobApplyId);
            if (objFromDb != null)
            {
                objFromDb.Status = jobApply.Status;
                objFromDb.EmployeeId = jobApply.EmployeeId;
                objFromDb.Employee = jobApply.Employee;
                objFromDb.JobId = jobApply.JobId;
                objFromDb.Job = jobApply.Job;

                _db.SaveChanges();
            }
            else
            {
                throw new Exception("JobApply not found");
            }
        }

        public void UpdateStatus(JobApply jobApply)
        {
            var objFromDb = _db.JobApplies.FirstOrDefault(s => s.JobApplyId == jobApply.JobApplyId);
            if (objFromDb != null)
            {
                objFromDb.Status = jobApply.Status;
                _db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("JobApply not found.");
            }
        }


    }
}