using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;

namespace StudentSerialization
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double AverageScore { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Age} років, середній бал: {AverageScore:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string fileName = "students.json";

            
            List<Student> students = new List<Student>
            {
                new Student { Name = "Андрій Коваль", Age = 20, AverageScore = 85.5 },
                new Student { Name = "Марія Шевченко", Age = 19, AverageScore = 92.3 },
                new Student { Name = "Іван Бондар", Age = 21, AverageScore = 78.9 },
                new Student { Name = "Олена Мельник", Age = 20, AverageScore = 88.7 },
                new Student { Name = "Дмитро Лисенко", Age = 22, AverageScore = 95.1 }
            };

            Console.WriteLine("=== СПИСОК СТУДЕНТІВ ===\n");

            
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(fileName, json, Encoding.UTF8);
            Console.WriteLine($"Серіалізовано та збережено у файл: {fileName}\n");

            
            string loadedJson = File.ReadAllText(fileName, Encoding.UTF8);
            List<Student> loadedStudents = JsonSerializer.Deserialize<List<Student>>(loadedJson);

            Console.WriteLine("=== ДЕСЕРІАЛІЗОВАНІ ДАНІ ===\n");
            foreach (var student in loadedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}