using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;

namespace OnlineServiceLibrary.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(string name, string email);
        Task UpdateUserAsync(int id, string name, string email);
        Task DeleteUserAsync(int id);
        Task<bool> UserExistsAsync(int id);
    }
}