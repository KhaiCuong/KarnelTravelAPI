using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUserById(int User_id);
        Task<UserModel> AddUser(UserModel User);
        Task<UserModel> UpdateUser(UserModel User);
        Task<UserModel> Login(string Email,string Password);

        Task<bool> DeleteUser(int User_id);
    }
}
