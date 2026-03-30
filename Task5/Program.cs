
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string path;
        if (args.Length > 0)
        {
            path = args[0];
        }
        else
        {
            Console.Write("Введіть шлях до папки: ");
            path = Console.ReadLine() ?? Directory.GetCurrentDirectory();
        }

        if (!Directory.Exists(path))
        {
            Console.WriteLine($"Помилка: папку не знайдено → {path}");
            Environment.Exit(1);
            return;
        }

        string[] allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        string[] allDirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

        long totalBytes = allFiles.Sum(f => new FileInfo(f).Length);

        FileInfo? largest = allFiles
            .Select(f => new FileInfo(f))
            .OrderByDescending(f => f.Length)
            .FirstOrDefault();

        Console.WriteLine();
        Console.WriteLine($"  Analyzing : {path}");
        Console.WriteLine(new string('─', 40));
        Console.WriteLine($"  Folders   : {allDirs.Length}");
        Console.WriteLine($"  Files     : {allFiles.Length}");
        Console.WriteLine($"  Total size: {FormatSize(totalBytes)}");
        Console.WriteLine($"  Largest   : {largest?.Name ?? "—"}");
        Console.WriteLine();
    }

    static string FormatSize(long bytes)
    {
        if (bytes >= 1_073_741_824) return $"{bytes / 1_073_741_824.0:F2} GB";
        if (bytes >= 1_048_576) return $"{bytes / 1_048_576.0:F2} MB";
        if (bytes >= 1_024) return $"{bytes / 1_024.0:F1} KB";
        return $"{bytes} B";
    }
}