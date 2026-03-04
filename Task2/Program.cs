using System;
using System.Text;

namespace MulticastDelegateTask
{
    
    public delegate void NotificationHandler(string message);

    class Program
    {
        static void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }

        static void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }

        static void Main()
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Завдання 2: Мультикастинг ===\n");

            
            NotificationHandler notification = SendEmail;
            notification += SendSMS;  

            
            notification("Привіт! Це тестове повідомлення.");

            
            Console.WriteLine("\n--- Видаляємо SMS ---");
            notification -= SendSMS;
            notification("Тільки Email повідомлення.");

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}