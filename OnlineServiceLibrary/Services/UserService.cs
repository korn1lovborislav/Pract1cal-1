using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;
using OnlineServiceLibrary.Repositories;

namespace OnlineServiceLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> AddUserAsync(string name, string email)
        {
            var user = new User
            {
                Name = name,
                Email = email
            };
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(int id, string name, string email)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                user.Name = name;
                user.Email = email;
                await _userRepository.UpdateAsync(user);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            return await _userRepository.ExistsAsync(id);
        }
    }
}