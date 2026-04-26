using System;
using System.Linq;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;
using OnlineServiceLibrary.Serialization;

namespace OnlineServiceLibrary.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly JsonSerializer<User> _serializer;
        private List<User> _users;
        private int _nextId = 1;
        private readonly object _lock = new object();

        public UserRepository(string filePath)
        {
            _serializer = new JsonSerializer<User>(filePath);
            _users = new List<User>();
        }

        private async Task LoadAsync()
        {
            _users = await _serializer.LoadAsync();
            if (_users.Any())
                _nextId = _users.Max(u => u.Id) + 1;
        }

        private async Task SaveAsync()
        {
            await _serializer.SaveAsync(_users);
        }

        public async Task<List<User>> GetAllAsync()
        {
            await LoadAsync();
            return _users.ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            await LoadAsync();
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await LoadAsync();
            user.Id = _nextId++;
            user.RegisteredAt = DateTime.Now;
            _users.Add(user);
            await SaveAsync();
        }

        public async Task UpdateAsync(User user)
        {
            await LoadAsync();
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
                await SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await LoadAsync();
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                await SaveAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            await LoadAsync();
            return _users.Any(u => u.Id == id);
        }
    }
}