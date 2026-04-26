using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;
using OnlineServiceLibrary.Repositories;

namespace OnlineServiceLibrary.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public OrderService(OrderRepository orderRepository, IUserService userService, IBookService bookService)
        {
            _orderRepository = orderRepository;
            _userService = userService;
            _bookService = bookService;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<Order> CreateOrderAsync(int userId, int bookId)
        {
            if (!await _userService.UserExistsAsync(userId))
                throw new System.Exception($"Користувача з ID {userId} не існує");

            if (!await _bookService.BookExistsAsync(bookId))
                throw new System.Exception($"Книги з ID {bookId} не існує");

            var order = new Order
            {
                UserId = userId,
                BookId = bookId
            };
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task UpdateOrderStatusAsync(int id, OrderStatus status)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
            {
                order.Status = status;
                await _orderRepository.UpdateAsync(order);
            }
        }

        public async Task CancelOrderAsync(int id)
        {
            await UpdateOrderStatusAsync(id, OrderStatus.Cancelled);
        }

        public async Task<List<Order>> GetOrdersByUserAsync(int userId)
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Where(o => o.UserId == userId).ToList();
        }
    }
}