using System;
using System.Linq;
using System.Threading.Tasks;
using OnlineServiceLibrary.Models;
using OnlineServiceLibrary.Serialization;

namespace OnlineServiceLibrary.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly JsonSerializer<Book> _serializer;
        private List<Book> _books;
        private int _nextId = 1;
        private readonly object _lock = new object();

        public BookRepository(string filePath)
        {
            _serializer = new JsonSerializer<Book>(filePath);
            _books = new List<Book>();
        }

        private async Task LoadAsync()
        {
            _books = await _serializer.LoadAsync();
            if (_books.Any())
                _nextId = _books.Max(b => b.Id) + 1;
        }

        private async Task SaveAsync()
        {
            await _serializer.SaveAsync(_books);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            await LoadAsync();
            return _books.ToList();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            await LoadAsync();
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public async Task AddAsync(Book book)
        {
            await LoadAsync();
            book.Id = _nextId++;
            _books.Add(book);
            await SaveAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            await LoadAsync();
            var existing = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Year = book.Year;
                existing.Price = book.Price;
                await SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await LoadAsync();
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
                await SaveAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            await LoadAsync();
            return _books.Any(b => b.Id == id);
        }
    }
}