using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;
        public UnitOfWork(ApplicationContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Job = new JobRepository(_db);
            JobCategory = new JobCategoryRepository(_db);
        }

        public IUserRepository User { get; private set; }
        public IJobRepository Job { get; private set; }
        public IJobCategoryRepository JobCategory { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
