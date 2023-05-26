﻿using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserByIdAsync(int User_id);
        Task<UserModel> AddUserAsync(UserModel User);
        Task<UserModel> UpdateUserAsync(UserModel User);
        Task<UserModel> Login(string email, string password);

        Task<bool> DeleteUserAsync(int User_id);
    }
}


