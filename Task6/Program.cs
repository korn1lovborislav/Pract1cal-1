using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;

namespace NestedObjects
{
    public class Inventory
    {
        public List<string> Items { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Player player = new Player
            {
                Name = "Герой",
                Inventory = new Inventory { Items = new List<string> { "Меч", "Щит", "Зілля" } }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };

           
            string json = JsonSerializer.Serialize(player, options);
            File.WriteAllText("player.json", json, Encoding.UTF8);

            Console.WriteLine("=== ОРИГІНАЛЬНИЙ JSON ===\n");
            Console.WriteLine(json);

            
            string jsonWithoutInventory = @"{
  ""Name"": ""Герой""
}";
            File.WriteAllText("player_without_inventory.json", jsonWithoutInventory, Encoding.UTF8);

            
            string loadedJson = File.ReadAllText("player_without_inventory.json", Encoding.UTF8);
            Player loadedPlayer = JsonSerializer.Deserialize<Player>(loadedJson, options);

            
            if (loadedPlayer.Inventory == null)
            {
                loadedPlayer.Inventory = new Inventory { Items = new List<string>() };
                Console.WriteLine("\n⚠️ Inventory був відсутній у JSON. Створено порожній інвентар.");
            }

            Console.WriteLine($"\n=== ДЕСЕРІАЛІЗОВАНИЙ ГРАВЕЦЬ ===");
            Console.WriteLine($"Ім'я: {loadedPlayer.Name}");
            Console.WriteLine($"Інвентар: {(loadedPlayer.Inventory.Items.Count == 0 ? "порожній" : string.Join(", ", loadedPlayer.Inventory.Items))}");
        }
    }
}