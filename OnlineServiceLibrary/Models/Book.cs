using System.Globalization;

namespace OnlineServiceLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            var uaCulture = new CultureInfo("uk-UA");
            return $"[{Id}] {Title} - {Author} ({Year}), {Price.ToString("C", uaCulture)}";
        }
    }
}