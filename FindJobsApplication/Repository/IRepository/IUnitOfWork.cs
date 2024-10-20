namespace FindJobsApplication.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IJobRepository Job { get; }
        IJobCategoryRepository JobCategory { get; }
        IEmployerRepository Employer { get; }
        IEmployeeRepository Employee { get; }
        IJobApplyRepository JobApply { get; }
        IAdminRepository Admin { get; }
        IHireRepository Hire { get; }
        void Save();
    }
}