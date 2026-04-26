using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;

namespace OnlineServiceLibrary.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(string title, string author, int year, decimal price);
        Task UpdateBookAsync(int id, string title, string author, int year, decimal price);
        Task DeleteBookAsync(int id);
        Task<bool> BookExistsAsync(int id);
    }
}