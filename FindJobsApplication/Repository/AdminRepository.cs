using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using System.Linq.Expressions;

namespace FindJobsApplication.Repository
{
    internal class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private readonly ApplicationContext _db;

        public AdminRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}