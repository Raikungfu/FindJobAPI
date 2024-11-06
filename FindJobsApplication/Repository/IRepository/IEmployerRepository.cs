using FindJobsApplication.Models;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IEmployerRepository : IRepository<Employer>
    {
        void Update(Employer employer);
    }
}
