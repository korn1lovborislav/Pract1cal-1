
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть шлях до папки: ");
        string? input = Console.ReadLine();
        string path = string.IsNullOrWhiteSpace(input) ? Directory.GetCurrentDirectory() : input;

        if (!Directory.Exists(path))
        {
            Console.WriteLine($"Помилка: папку не знайдено → {path}");
            return;
        }

        Console.WriteLine($"\nПошук у: {path}");
        Console.WriteLine(new string('─', 50));

        FileInfo? largest = Directory
            .GetFiles(path, "*", SearchOption.AllDirectories)
            .Select(f => new FileInfo(f))
            .OrderByDescending(f => f.Length)
            .FirstOrDefault();

        if (largest == null)
        {
            Console.WriteLine("Файлів не знайдено.");
            return;
        }

        Console.WriteLine($"  Name : {largest.Name}");
        Console.WriteLine($"  Size : {FormatSize(largest.Length)}");
        Console.WriteLine($"  Path : {largest.FullName}");
    }

    static string FormatSize(long bytes)
    {
        if (bytes >= 1_048_576) return $"{bytes / 1_048_576.0:F2} MB";
        if (bytes >= 1_024) return $"{bytes / 1_024.0:F1} KB";
        return $"{bytes} B";
    }
}