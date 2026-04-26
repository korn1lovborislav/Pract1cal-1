using System;
using System.Linq;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;
using OnlineServiceLibrary.Serialization;

namespace OnlineServiceLibrary.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly JsonSerializer<Order> _serializer;
        private List<Order> _orders;
        private int _nextId = 1;
        private readonly object _lock = new object();

        public OrderRepository(string filePath)
        {
            _serializer = new JsonSerializer<Order>(filePath);
            _orders = new List<Order>();
        }

        private async Task LoadAsync()
        {
            _orders = await _serializer.LoadAsync();
            if (_orders.Any())
                _nextId = _orders.Max(o => o.Id) + 1;
        }

        private async Task SaveAsync()
        {
            await _serializer.SaveAsync(_orders);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            await LoadAsync();
            return _orders.ToList();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            await LoadAsync();
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await LoadAsync();
            order.Id = _nextId++;
            order.OrderDate = DateTime.Now;
            order.Status = OrderStatus.Pending;
            _orders.Add(order);
            await SaveAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            await LoadAsync();
            var existing = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existing != null)
            {
                existing.Status = order.Status;
                await SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await LoadAsync();
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _orders.Remove(order);
                await SaveAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            await LoadAsync();
            return _orders.Any(o => o.Id == id);
        }
    }
}