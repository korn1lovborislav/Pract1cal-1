using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;

namespace OnlineServiceLibrary.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(int userId, int bookId);
        Task UpdateOrderStatusAsync(int id, OrderStatus status);
        Task CancelOrderAsync(int id);
        Task<List<Order>> GetOrdersByUserAsync(int userId);
    }
}