using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace EnumSerialization
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed
    }

    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Order order = new Order { Id = 1, Status = OrderStatus.Processing };

            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            string json = JsonSerializer.Serialize(order, options);
            File.WriteAllText("order.json", json, Encoding.UTF8);

            Console.WriteLine("=== СЕРІАЛІЗАЦІЯ ENUM ===\n");
            Console.WriteLine(json);

            
            string loadedJson = File.ReadAllText("order.json", Encoding.UTF8);
            Order loadedOrder = JsonSerializer.Deserialize<Order>(loadedJson, options);

            Console.WriteLine("\n=== ДЕСЕРІАЛІЗАЦІЯ ===");
            Console.WriteLine($"ID: {loadedOrder.Id}, Статус: {loadedOrder.Status}");
        }
    }
}