using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace PolymorphismSerialization
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Dog), "dog")]
    [JsonDerivedType(typeof(Cat), "cat")]
    public abstract class Animal
    {
        public string Name { get; set; }
    }

    public class Dog : Animal
    {
        public int BarkVolume { get; set; }
    }

    public class Cat : Animal
    {
        public int Lives { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Animal> animals = new List<Animal>
            {
                new Dog { Name = "Бобик", BarkVolume = 7 },
                new Cat { Name = "Мурка", Lives = 9 },
                new Dog { Name = "Рекс", BarkVolume = 5 }
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

           
            string json = JsonSerializer.Serialize(animals, options);
            File.WriteAllText("animals.json", json, Encoding.UTF8);

            Console.WriteLine("=== СЕРІАЛІЗАЦІЯ ПОЛІМОРФНОГО СПИСКУ ===\n");
            Console.WriteLine(json);

            
            string loadedJson = File.ReadAllText("animals.json", Encoding.UTF8);
            List<Animal> loadedAnimals = JsonSerializer.Deserialize<List<Animal>>(loadedJson, options);

            Console.WriteLine("\n=== ДЕСЕРІАЛІЗАЦІЯ ===\n");
            foreach (var animal in loadedAnimals)
            {
                if (animal is Dog dog)
                    Console.WriteLine($"Собака: {dog.Name}, Гучність гавкоту: {dog.BarkVolume}");
                else if (animal is Cat cat)
                    Console.WriteLine($"Кіт: {cat.Name}, Кількість життів: {cat.Lives}");
            }
        }
    }
}