using System;
using System.Text;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;
using OnlineServiceLibrary.Repositories;
using OnlineServiceLibrary.Services;

namespace OnlineServiceUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            
            var userRepo = new UserRepository("users.json");
            var bookRepo = new BookRepository("books.json");
            var orderRepo = new OrderRepository("orders.json");

           
            var userService = new UserService(userRepo);
            var bookService = new BookService(bookRepo);
            var orderService = new OrderService(orderRepo, userService, bookService);

            Console.WriteLine("=== СИСТЕМА КЕРУВАННЯ ДАНИМИ ===\n");

           
            Console.WriteLine("--- Додаємо користувачів ---");
            var user1 = await userService.AddUserAsync("Андрій Коваль", "andriy@example.com");
            var user2 = await userService.AddUserAsync("Марія Шевченко", "maria@example.com");
            Console.WriteLine($"Додано: {user1}");
            Console.WriteLine($"Додано: {user2}");

            
            Console.WriteLine("\n--- Додаємо книги ---");
            var book1 = await bookService.AddBookAsync("Майстер і Маргарита", "Михайло Булгаков", 1967, 250m);
            var book2 = await bookService.AddBookAsync("Кобзар", "Тарас Шевченко", 1840, 180m);
            Console.WriteLine($"Додано: {book1}");
            Console.WriteLine($"Додано: {book2}");

           
            Console.WriteLine("\n--- Всі користувачі ---");
            var users = await userService.GetAllUsersAsync();
            foreach (var user in users)
                Console.WriteLine(user);

           
            Console.WriteLine("\n--- Всі книги ---");
            var books = await bookService.GetAllBooksAsync();
            foreach (var book in books)
                Console.WriteLine(book);

           
            Console.WriteLine("\n--- Створюємо замовлення ---");
            var order1 = await orderService.CreateOrderAsync(user1.Id, book1.Id);
            var order2 = await orderService.CreateOrderAsync(user2.Id, book2.Id);
            Console.WriteLine($"Створено: {order1}");
            Console.WriteLine($"Створено: {order2}");

            
            Console.WriteLine("\n--- Оновлюємо статус замовлення ---");
            await orderService.UpdateOrderStatusAsync(order1.Id, OrderStatus.Completed);
            var updatedOrder = await orderService.GetOrderByIdAsync(order1.Id);
            Console.WriteLine($"Оновлено: {updatedOrder}");

            
            Console.WriteLine("\n--- Замовлення користувача Андрій ---");
            var userOrders = await orderService.GetOrdersByUserAsync(user1.Id);
            foreach (var order in userOrders)
                Console.WriteLine(order);

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}