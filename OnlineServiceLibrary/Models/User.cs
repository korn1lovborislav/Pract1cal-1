using System;

namespace OnlineServiceLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Email} (Зареєстрований: {RegisteredAt:yyyy-MM-dd})";
        }
    }
}