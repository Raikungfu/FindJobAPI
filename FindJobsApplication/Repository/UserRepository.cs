using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FindJobsApplication.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationContext _db;

        public UserRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(User user)
        {
            var objFromDb = _db.Users.FirstOrDefault(s => s.UserId == user.UserId);
            if (objFromDb != null)
            {
                if (user.PasswordHash != null)
                {
                    objFromDb.PasswordHash = user.PasswordHash;
                }

                objFromDb.Email = user.Email;
                objFromDb.Phone = user.Phone;
                objFromDb.BirthDay = user.BirthDay;
                objFromDb.Gender = user.Gender;

                objFromDb.UserType = user.UserType;
                objFromDb.IsBanned = user.IsBanned;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<bool> UserExists(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;
            }

            return password == user.PasswordHash;
        }
    }
}