using FindJobsApplication.Models;

namespace FindJobsApplication.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(string email, string password);
        void Update(User user);
    }
}