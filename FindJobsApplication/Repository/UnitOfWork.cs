﻿using FindJobsApplication.Models;
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
            Employer = new EmployerRepository(_db);
            Job = new JobRepository(_db);
            JobCategory = new JobCategoryRepository(_db);
            Employee = new EmployeeRepository(_db);
            Admin = new AdminRepository(_db);
            JobApply = new JobApplyRepository(_db);
            Hire = new HireRepository(_db);
            JobService = new JobServiceRepository(_db);
            Order = new OrderRepository(_db);
            Room = new RoomRepository(_db);
            Message = new MessageRepository(_db);
        }

        public IUserRepository User { get; private set; }
        public IJobRepository Job { get; private set; }
        public IJobCategoryRepository JobCategory { get; private set; }
        public IEmployerRepository Employer { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IAdminRepository Admin { get; private set; }
        public IJobApplyRepository JobApply { get; private set;}
        public IHireRepository Hire { get; private set; }

        public IJobServiceRepository JobService { get; private set; }

        public IOrderRepository Order { get; private set; }
        public IRoomRepository Room { get; private set; }
        public IMessageRepository Message { get; private set; }

        public async ValueTask DisposeAsync()
        {
            await _db.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }


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
