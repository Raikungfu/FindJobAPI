using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;

namespace FindJobsApplication.Repository
{
    internal class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationContext _db;

        public EmployeeRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employee employee)
        {
            var objFromDb = _db.Employees.FirstOrDefault(s => s.UserId == employee.UserId);
            if (objFromDb != null)
            {
                objFromDb.FirstName = employee.FirstName;
                objFromDb.LastName = employee.LastName;
                objFromDb.Phone = employee.Phone;
                objFromDb.Address = employee.Address;
                objFromDb.City = employee.City;
                objFromDb.Region = employee.Region;
                objFromDb.Country = employee.Country;
                objFromDb.PostalCode = employee.PostalCode;

                if (!string.IsNullOrEmpty(employee.Image))
                {
                    objFromDb.Image = employee.Image;
                }

                objFromDb.Description = employee.Description;
                objFromDb.Resume = employee.Resume;
                objFromDb.Skills = employee.Skills;
                objFromDb.Education = employee.Education;
                objFromDb.Experience = employee.Experience;
                objFromDb.Language = employee.Language;
                objFromDb.Interest = employee.Interest;
                objFromDb.SocialMedia = employee.SocialMedia;
                objFromDb.Status = employee.Status;

                objFromDb.PostJobServiceCount = employee.PostJobServiceCount;
                objFromDb.PostJobServiceFrom = employee.PostJobServiceFrom;
                objFromDb.PostJobServiceTo = employee.PostJobServiceTo;

                if (!string.IsNullOrEmpty(employee.Avt))
                {
                    objFromDb.Avt = employee.Avt;
                }
                if (!string.IsNullOrEmpty(employee.Cv))
                {
                    objFromDb.Cv = employee.Cv;
                }
                if (!string.IsNullOrEmpty(employee.Cover))
                {
                    objFromDb.Cover = employee.Cover;
                }
                if (!string.IsNullOrEmpty(employee.CIFront))
                {
                    objFromDb.CIFront = employee.CIFront;
                }
                if (!string.IsNullOrEmpty(employee.CIBehind))
                {
                    objFromDb.CIBehind = employee.CIBehind;
                }

            }
            else
            {
                throw new Exception("Employee not found");
            }
        }
    }
}