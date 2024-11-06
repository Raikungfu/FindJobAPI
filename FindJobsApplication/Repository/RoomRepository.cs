using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private ApplicationContext db;

        public RoomRepository(ApplicationContext db) : base(db)
        {
            this.db = db;
        }
    }
}