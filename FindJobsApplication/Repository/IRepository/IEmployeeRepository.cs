using FindJobsApplication.Models;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee employee);
    }
}