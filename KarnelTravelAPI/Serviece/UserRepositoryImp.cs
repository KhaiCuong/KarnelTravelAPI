using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Serviece
{
    public class UserRepositoryImp : IUserRepository
    {
        private DatabaseContext _dbContext;
        public UserRepositoryImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> AddUserAsync(UserModel User)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.User_name.Equals(User.User_name));
            if (user == null)
            {
                await _dbContext.Users.AddAsync(User);
                await _dbContext.SaveChangesAsync();
                return User;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteUserAsync(int User_id)
        {
            UserModel user = await _dbContext.Users.FindAsync(User_id);
            if (user == null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserModel> GetUserByIdAsync(int User_id)
        {
            UserModel user = await _dbContext.Users.FindAsync(User_id);
            if (user != null) 
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();

        }

        public Task<UserModel> Login(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> UpdateUserAsync(UserModel User)
        {
            var user = await _dbContext.Users.FindAsync(User.User_id);
            if (user != null) 
            
            {
                user.User_name = user.User_name;
                user.Address = user.Address;
                user.Phone_number = user.Phone_number;
                user.Email = user.Email;
                await _dbContext.SaveChangesAsync();
                return user;
                
            }
            else
            {
                return null;
            }    
        }
    }
}
