using System;
using System.IO;
using System.Text;

namespace ModulWork
{
    public class MessagePublisher
    {
        public event Action<string>? MessageEvent;

        public void Send(string message)
        {
            MessageEvent?.Invoke(message);
        }
    }

    public class FileLogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void OnMessageReceived(string message)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:HH:mm:ss}] {message}";
                File.AppendAllLines(_filePath, new[] { logEntry });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка запису: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string logFile = "logPD25.txt";
            File.WriteAllText(logFile, string.Empty);

            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger(logFile);

            publisher.MessageEvent += logger.OnMessageReceived;

            Console.WriteLine("Введіть 4 повідомлення для логування:");

            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"{i} > ");
                string? input = Console.ReadLine();

                if (input != null)
                {
                    publisher.Send(input);
                }
            }

            Console.WriteLine($"Повідомлення записано у {logFile}");
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}