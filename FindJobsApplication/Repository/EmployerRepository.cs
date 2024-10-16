using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class EmployerRepository : Repository<Employer>, IEmployerRepository
    {
        private readonly ApplicationContext _db;

        public EmployerRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
