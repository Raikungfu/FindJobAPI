using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class HireRepository : Repository<Hire>, IHireRepository
    {
        private readonly ApplicationContext _db;

        public HireRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}