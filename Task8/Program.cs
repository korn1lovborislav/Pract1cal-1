using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;

namespace ErrorHandling
{
    public class UserData
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "user.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            
            UserData validUser = new UserData { Name = "Іван", Age = 25, Email = "ivan@example.com" };
            string validJson = JsonSerializer.Serialize(validUser, options);
            File.WriteAllText(fileName, validJson, Encoding.UTF8);

            Console.WriteLine("=== КОРЕКТНИЙ JSON ===\n");
            Console.WriteLine(validJson);

            
            string corruptedJson = @"{""Name"": ""Іван"", ""Age"": 25, ""Email"": }"; 
            File.WriteAllText("corrupted_user.json", corruptedJson, Encoding.UTF8);

            
            UserData loadedUser = LoadUserData("corrupted_user.json", options);

            if (loadedUser != null)
            {
                Console.WriteLine("\n=== ДЕСЕРІАЛІЗОВАНІ ДАНІ ===");
                Console.WriteLine($"Ім'я: {loadedUser.Name}");
                Console.WriteLine($"Вік: {loadedUser.Age}");
                Console.WriteLine($"Email: {loadedUser.Email}");
            }

            
            Console.WriteLine("\n=== СПРОБА З КОРЕКТНИМ ФАЙЛОМ ===");
            UserData validData = LoadUserData(fileName, options);
            if (validData != null)
            {
                Console.WriteLine($"Ім'я: {validData.Name}, Вік: {validData.Age}, Email: {validData.Email}");
            }
        }

        static UserData LoadUserData(string fileName, JsonSerializerOptions options)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"Файл {fileName} не знайдено. Створюємо новий об'єкт.");
                    return new UserData();
                }

                string json = File.ReadAllText(fileName, Encoding.UTF8);
                UserData user = JsonSerializer.Deserialize<UserData>(json, options);

                if (user == null)
                {
                    Console.WriteLine("Десеріалізація повернула null. Створюємо новий об'єкт.");
                    return new UserData();
                }

                return user;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"❌ ПОМИЛКА ДЕСЕРІАЛІЗАЦІЇ: JSON пошкоджений!");
                Console.WriteLine($"Деталі: {ex.Message}");
                Console.WriteLine("Програма продовжує роботу. Створюємо новий об'єкт за замовчуванням.");
                return new UserData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ НЕВІДОМА ПОМИЛКА: {ex.Message}");
                return new UserData();
            }
        }
    }
}