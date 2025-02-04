using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly ApplicationContext _db;

        public NotificationRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
