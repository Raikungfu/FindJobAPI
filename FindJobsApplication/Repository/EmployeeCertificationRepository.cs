using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class EmployeeCertificationRepository : Repository<EmployeeCertification>, IEmployeeCertificationRepository
    {
        private readonly ApplicationContext _db;

        public EmployeeCertificationRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
