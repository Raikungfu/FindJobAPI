using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext db) : base(db)
        {

        }
    }
}