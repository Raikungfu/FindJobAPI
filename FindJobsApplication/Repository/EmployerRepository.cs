using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class EmployerRepository : Repository<Employer>, IEmployerRepository
    {
        private readonly ApplicationContext _db;

        public EmployerRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employer employer)
        {
            var objFromDb = _db.Employers.FirstOrDefault(s => s.UserId == employer.UserId);

            if (objFromDb != null)
            {
                objFromDb.Name = employer.Name;
                objFromDb.Description = employer.Description;
                objFromDb.CompanyName = employer.CompanyName;
                objFromDb.CompanyDescription = employer.CompanyDescription;
                objFromDb.CompanyWebsite = employer.CompanyWebsite;
                objFromDb.CompanyLocation = employer.CompanyLocation;
                objFromDb.CompanyContact = employer.CompanyContact;
                objFromDb.CompanyEmail = employer.CompanyEmail;
                objFromDb.CompanyPhone = employer.CompanyPhone;
                objFromDb.CompanyType = employer.CompanyType;
                objFromDb.CompanySize = employer.CompanySize;
                objFromDb.CompanyIndustry = employer.CompanyIndustry;
                objFromDb.CompanyFounded = employer.CompanyFounded;
                objFromDb.CompanyMission = employer.CompanyMission;
                objFromDb.CompanyVision = employer.CompanyVision;
                objFromDb.CompanyValues = employer.CompanyValues;
                objFromDb.CompanyBenefits = employer.CompanyBenefits;
                objFromDb.CompanyProjects = employer.CompanyProjects;
                objFromDb.CompanyServices = employer.CompanyServices;

                if (!string.IsNullOrEmpty(employer.CompanyLogo))
                {
                    objFromDb.CompanyLogo = employer.CompanyLogo;
                }

                if (!string.IsNullOrEmpty(employer.Cover))
                {
                    objFromDb.Cover = employer.Cover;
                }

                if (!string.IsNullOrEmpty(employer.CIFront))
                {
                    objFromDb.CIFront = employer.CIFront;
                }

                if (!string.IsNullOrEmpty(employer.CIBehind))
                {
                    objFromDb.CIBehind = employer.CIBehind;
                }

                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Employer not found");
            }
        }

    }
}
