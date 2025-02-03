using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly ApplicationContext _db;

        public ReviewRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
