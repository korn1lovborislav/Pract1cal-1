using System;
using System.Text;

namespace ValidatorTask
{
    
    public delegate bool Validator(string text);

    class Program
    {
      
        static Validator GetValidator(int minLength)
        {
           
            return text => text != null && text.Length >= minLength;
        }

        static void Main()
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Завдання 6: Динамічний валідатор тексту ===\n");

            
            Validator passwordValidator = GetValidator(8);  
            Validator loginValidator = GetValidator(3);     
            Validator commentValidator = GetValidator(1);   

            
            TestValidator("passwordValidator", passwordValidator);
            TestValidator("loginValidator", loginValidator);
            TestValidator("commentValidator", commentValidator);

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        static void TestValidator(string validatorName, Validator validator)
        {
            Console.WriteLine($"--- Тестуємо {validatorName} ---");

            string[] testStrings = { "123", "qwerty", "qwerty123", "", "a", "abcdefgh", null };

            foreach (string test in testStrings)
            {
                string displayText = test ?? "null";
                bool result = validator(test);
                Console.WriteLine($"Текст: '{displayText}' -> {(result ? "ПРОЙШОВ" : "НЕ ПРОЙШОВ")}");
            }
            Console.WriteLine();
        }
    }
}