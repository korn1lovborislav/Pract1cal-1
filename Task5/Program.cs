using System;
using System.Text;

namespace LoggerTask
{
    
    public class Logger
    {
        public Action<string> LogHandler;

        public void Log(string message)
        {
            if (LogHandler != null)
            {
                LogHandler(message);
            }
            else
            {
                Console.WriteLine("Логер не налаштовано!");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Завдання 5: Логування ===\n");

            
            Logger logger = new Logger();

           
            Console.WriteLine("--- Звичайний вивід ---");
            logger.LogHandler = Console.WriteLine;
            logger.Log("Це звичайне повідомлення");
            logger.Log("Ще одне повідомлення");

            
            Console.WriteLine("\n--- Вивід у верхньому регістрі ---");
            logger.LogHandler = message => Console.WriteLine(message.ToUpper());
            logger.Log("це повідомлення буде у верхньому регістрі");
            logger.Log("А це теж буде ВЕЛИКИМИ літерами");

            
            Console.WriteLine("\n--- Мультикастинг логерів ---");
            logger.LogHandler = null;  // скидаємо
            logger.LogHandler += Console.WriteLine;
            logger.LogHandler += message => Console.WriteLine($"UPPER: {message.ToUpper()}");

            logger.Log("Тест мультикастингу");

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}