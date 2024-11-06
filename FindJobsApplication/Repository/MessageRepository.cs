using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private ApplicationContext db;

        public MessageRepository(ApplicationContext db) : base(db)
        {
            this.db = db;
        }
    }
}