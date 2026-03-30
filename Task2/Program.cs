
using System;
using System.IO;

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

        Console.WriteLine($"\nІнспекція: {path}");
        Console.WriteLine(new string('─', 50));

        string[] subDirs = Directory.GetDirectories(path);
        Console.WriteLine($"\nПідпапки ({subDirs.Length}):");

        foreach (string dir in subDirs)
            Console.WriteLine($"   └─ {Path.GetFileName(dir)}");


        string[] files = Directory.GetFiles(path);
        Console.WriteLine($"\nФайли ({files.Length}):");

        foreach (string file in files)
        {
            var info = new FileInfo(file);
            Console.WriteLine($"   ├─ {info.Name}");
            Console.WriteLine($"   │    Розмір  : {FormatSize(info.Length)}");
            Console.WriteLine($"   │    Створено: {info.CreationTime:dd.MM.yyyy HH:mm}");
        }

        Console.WriteLine();
    }

    static string FormatSize(long bytes)
    {
        if (bytes >= 1_048_576) return $"{bytes / 1_048_576.0:F2} MB";
        if (bytes >= 1_024) return $"{bytes / 1_024.0:F1} KB";
        return $"{bytes} B";
    }
}