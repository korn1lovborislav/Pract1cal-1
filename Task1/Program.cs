
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string storyPath = "story.txt";
        string reportPath = "report.txt";

        if (!File.Exists(storyPath))
        {
            File.WriteAllText(storyPath, """
                It was a dark and stormy night.
                The detective entered the abandoned warehouse.
                Shadows danced across the broken walls.
                A faint sound echoed in the distance.
                He reached for his flashlight and moved forward.
                """, System.Text.Encoding.UTF8);

            Console.WriteLine($"Створено демо-файл: {storyPath}\n");
        }

        int lineCount = 0;
        int wordCount = 0;
        int charCount = 0;

        using (var reader = new StreamReader(storyPath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                lineCount++;
                charCount += line.Length;

                string[] words = line.Split(
                    new char[] { ' ', '\t', ',', '.', '!', '?' },
                    StringSplitOptions.RemoveEmptyEntries);

                wordCount += words.Length;
            }
        }

        string report = $"""
            Файл    : {Path.GetFullPath(storyPath)}
            Рядків  : {lineCount}
            Слів    : {wordCount}
            Символів: {charCount}
            Дата    : {DateTime.Now:dd.MM.yyyy HH:mm:ss}
            """;

        File.WriteAllText(reportPath, report, System.Text.Encoding.UTF8);

        Console.WriteLine(report);
        Console.WriteLine($"\n Звіт збережено: {reportPath}");
    }
}