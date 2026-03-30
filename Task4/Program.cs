
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть шлях до папки cache: ");
        string? input = Console.ReadLine();
        string cachePath = string.IsNullOrWhiteSpace(input) ? "cache" : input;

        if (!Directory.Exists(cachePath))
        {
            Console.WriteLine($"Помилка: папку не знайдено → {cachePath}");
            return;
        }

        Console.WriteLine("\n── Варіант А: рекурсія ──");
        int deletedA = 0;
        long sizeA = 0;
        DeleteRecursive(cachePath, ref deletedA, ref sizeA);
        PrintReport(deletedA, sizeA);


        Console.WriteLine("── Варіант Б: ітерація ──");
        int deletedB = 0;
        long sizeB = 0;
        DeleteIterative(cachePath, ref deletedB, ref sizeB);
        PrintReport(deletedB, sizeB);
    }

    static void DeleteRecursive(string dir, ref int count, ref long size)
    {
        foreach (string file in Directory.GetFiles(dir))
        {
            var info = new FileInfo(file);
            size += info.Length;
            File.Delete(file);
            count++;
            Console.WriteLine($"   Видалено: {info.Name} ({FormatSize(info.Length)})");
        }

        foreach (string sub in Directory.GetDirectories(dir))
            DeleteRecursive(sub, ref count, ref size);
    }

    static void DeleteIterative(string root, ref int count, ref long size)
    {
        var stack = new Stack<string>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            string current = stack.Pop();

            foreach (string file in Directory.GetFiles(current))
            {
                var info = new FileInfo(file);
                size += info.Length;
                File.Delete(file);
                count++;
                Console.WriteLine($"   Видалено: {info.Name} ({FormatSize(info.Length)})");
            }

            foreach (string sub in Directory.GetDirectories(current))
                stack.Push(sub);
        }
    }

    static void PrintReport(int deleted, long size)
    {
        Console.WriteLine($"   Видалено файлів : {deleted}");
        Console.WriteLine($"   Звільнено місця : {FormatSize(size)}");
        Console.WriteLine($"   Виконано        : {DateTime.Now:dd.MM.yyyy HH:mm:ss}\n");
    }

    static string FormatSize(long bytes)
    {
        if (bytes >= 1_048_576) return $"{bytes / 1_048_576.0:F2} MB";
        if (bytes >= 1_024) return $"{bytes / 1_024.0:F1} KB";
        return $"{bytes} B";
    }
}