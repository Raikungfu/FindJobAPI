using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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

            }
            else
            {
                throw new Exception("JobApply not found");
            }
        }

        public async Task<JobApply> UpdateStatusAsync(JobApply jobApply)
        {
            var objFromDb = await _db.JobApplies.SingleOrDefaultAsync(s => s.JobApplyId == jobApply.JobApplyId);
            if (objFromDb == null)
            {
                throw new KeyNotFoundException("Không tìm thấy JobApply.");
            }

            objFromDb.Status = jobApply.Status;
            await _db.SaveChangesAsync();
            return objFromDb;
        }
    }
}