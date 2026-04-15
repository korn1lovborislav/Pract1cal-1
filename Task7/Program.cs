using System;
using System.IO;
using System.Text.Json;
using System.Text;

namespace VersioningModels
{
    
    public class PlayerV1
    {
        public string Name { get; set; }
    }

   
    public class PlayerV2
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1; 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "player_v1.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            
            PlayerV1 oldPlayer = new PlayerV1 { Name = "Андрій" };
            string oldJson = JsonSerializer.Serialize(oldPlayer, options);
            File.WriteAllText(fileName, oldJson, Encoding.UTF8);

            Console.WriteLine("=== СТАРИЙ JSON (без поля Level) ===\n");
            Console.WriteLine(oldJson);

            
            string loadedJson = File.ReadAllText(fileName, Encoding.UTF8);
            PlayerV2 newPlayer = JsonSerializer.Deserialize<PlayerV2>(loadedJson, options);

            Console.WriteLine("\n=== ДЕСЕРІАЛІЗАЦІЯ У НОВУ МОДЕЛЬ ===");
            Console.WriteLine($"Ім'я: {newPlayer.Name}");
            Console.WriteLine($"Рівень: {newPlayer.Level} (значення за замовчуванням, оскільки поле було відсутнє)");

            
            string newJson = JsonSerializer.Serialize(newPlayer, options);
            File.WriteAllText("player_v2.json", newJson, Encoding.UTF8);

            Console.WriteLine("\n=== НОВИЙ JSON (з полем Level) ===\n");
            Console.WriteLine(newJson);
        }
    }
}