using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;
using OnlineServiceLibrary.Repositories;

namespace OnlineServiceLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> AddBookAsync(string title, string author, int year, decimal price)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Year = year,
                Price = price
            };
            await _bookRepository.AddAsync(book);
            return book;
        }

        public async Task UpdateBookAsync(int id, string title, string author, int year, decimal price)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                book.Title = title;
                book.Author = author;
                book.Year = year;
                book.Price = price;
                await _bookRepository.UpdateAsync(book);
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<bool> BookExistsAsync(int id)
        {
            return await _bookRepository.ExistsAsync(id);
        }
    }
}