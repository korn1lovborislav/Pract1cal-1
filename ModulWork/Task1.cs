using System;
using System.IO;
using System.Text;

namespace ModulWork
{
    public delegate string TextOperation(string text);

    public static class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

           
            string inputFile = "textPD25.txt";
            string outputFile = "resultPD25.txt";

            // Перевіряємо чи існує вхідний файл
            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"ПОМИЛКА: Файл {inputFile} не знайдено!");
                Console.WriteLine($"Поточна папка: {Directory.GetCurrentDirectory()}");
                return;
            }

            // Очищаємо вихідний файл
            File.WriteAllText(outputFile, string.Empty, Encoding.UTF8);

            // Операції
            TextOperation toUpper = (text) => text.ToUpper();
            TextOperation countChars = (text) => $"Кількість символів: {text.Length}";
            TextOperation countWords = (text) =>
            {
                string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':' },
                                            StringSplitOptions.RemoveEmptyEntries);
                return $"Кількість слів: {words.Length}";
            };

            Console.WriteLine("Обробка файлу...");

            // Викликаємо ProcessFile 3 рази з різними операціями
            ProcessFile(inputFile, outputFile, toUpper);
            ProcessFile(inputFile, outputFile, countChars);
            ProcessFile(inputFile, outputFile, countWords);

            Console.WriteLine($"Результати записані у {outputFile}");

            // Показуємо результат
            Console.WriteLine("\n=== ВМІСТ ФАЙЛУ resultPD25.txt ===");
            Console.WriteLine(File.ReadAllText(outputFile, Encoding.UTF8));
        }

        public static void ProcessFile(string sourcePath, string destPath, TextOperation operation)
        {
            // Читаємо ВСІ рядки з файлу
            string[] lines = File.ReadAllLines(sourcePath, Encoding.UTF8);

            // Дописуємо результат у вихідний файл
            using (StreamWriter sw = File.AppendText(destPath))
            {
                sw.WriteLine($"Виконання операції: {operation.Method.Name}");
                foreach (string line in lines)
                {
                    string result = operation(line);
                    sw.WriteLine(result);
                }
                sw.WriteLine();
            }
        }
    }
}