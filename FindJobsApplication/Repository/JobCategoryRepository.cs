using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
    {
        private readonly ApplicationContext _db;
        public JobCategoryRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Review review)
        {
            var objFromDb = _db.Reviews.FirstOrDefault(s => s.ReviewId == review.ReviewId);
            if (objFromDb != null)
            {
                objFromDb.Rating = review.Rating;
                objFromDb.Comment = review.Comment;
            }
        }
    }
}
