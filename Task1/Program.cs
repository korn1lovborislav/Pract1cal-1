using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;

namespace TaskTracker
{
    public class TaskItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{(IsCompleted ? "[✓]" : "[ ]")} {Title}";
        }
    }

    class Program
    {
        private static List<TaskItem> tasks = new List<TaskItem>();
        private static readonly string fileName = "tasks.json";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            LoadTasks();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TASK TRACKER ===\n");
                Console.WriteLine("1. Додати задачу");
                Console.WriteLine("2. Змінити статус задачі");
                Console.WriteLine("3. Переглянути список задач");
                Console.WriteLine("4. Вийти");
                Console.Write("\nВаш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ToggleTaskStatus();
                        break;
                    case "3":
                        ShowTasks();
                        break;
                    case "4":
                        SaveTasks();
                        Console.WriteLine("Програму завершено. Задачі збережено.");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        static void AddTask()
        {
            Console.Write("Введіть назву задачі: ");
            string title = Console.ReadLine();
            tasks.Add(new TaskItem { Title = title, IsCompleted = false });
            Console.WriteLine("Задачу додано!");
        }

        static void ToggleTaskStatus()
        {
            ShowTasks();
            Console.Write("Введіть номер задачі для зміни статусу: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks[index - 1].IsCompleted = !tasks[index - 1].IsCompleted;
                Console.WriteLine($"Статус задачі '{tasks[index - 1].Title}' змінено!");
            }
            else
            {
                Console.WriteLine("Невірний номер!");
            }
        }

        static void ShowTasks()
        {
            Console.WriteLine("\n--- СПИСОК ЗАДАЧ ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Немає задач.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }

        static void SaveTasks()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(fileName, json, Encoding.UTF8);
        }

        static void LoadTasks()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName, Encoding.UTF8);
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
                Console.WriteLine("Задачі завантажено з файлу.");
            }
        }
    }
}