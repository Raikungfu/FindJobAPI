namespace FindJobsApplication.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IJobRepository Job { get; }
        IJobCategoryRepository JobCategory { get; }
        IEmployerRepository Employer { get; }
        void Save();
    }
}