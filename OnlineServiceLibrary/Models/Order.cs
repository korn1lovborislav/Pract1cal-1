using System;

namespace OnlineServiceLibrary.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public override string ToString()
        {
            return $"[{Id}] Користувач: {UserId}, Книга: {BookId}, Статус: {Status}, Дата: {OrderDate:yyyy-MM-dd}";
        }
    }
}