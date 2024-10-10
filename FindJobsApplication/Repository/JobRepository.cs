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
    }
}
