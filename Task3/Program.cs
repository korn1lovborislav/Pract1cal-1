using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace CyclicReferences
{
    public class Author
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }

        [JsonIgnore] 
        public Author Author { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            
            Author author = new Author
            {
                Name = "Тарас Шевченко",
                Books = new List<Book>()
            };

            
            Book book1 = new Book { Title = "Кобзар", Author = author };
            Book book2 = new Book { Title = "Гайдамаки", Author = author };

            author.Books.Add(book1);
            author.Books.Add(book2);

           
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(author, options);
            File.WriteAllText("author.json", json, Encoding.UTF8);

            Console.WriteLine("=== УСПІШНА СЕРІАЛІЗАЦІЯ ===\n");
            Console.WriteLine(json);
        }
    }
}