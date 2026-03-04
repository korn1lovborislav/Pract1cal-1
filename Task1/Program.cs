using System;
using System.Text;

namespace DelegateTasks
{
    
    public delegate double MathOperation(double a, double b);

    class Program
    {
        
        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Multiply(double x, double y) => x * y;
        static double Divide(double x, double y)
        {
            if (y == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль!");
                return 0;
            }
            return x / y;
        }

        static void Main()
        {
           
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Завдання 1: Калькулятор ===\n");

            
            MathOperation operation;

            
            operation = Add;
            Console.WriteLine($"Add(10, 5) = {operation(10, 5)}");

            
            operation = Subtract;
            Console.WriteLine($"Subtract(10, 5) = {operation(10, 5)}");

           
            operation = Multiply;
            Console.WriteLine($"Multiply(10, 5) = {operation(10, 5)}");

           
            operation = Divide;
            Console.WriteLine($"Divide(10, 5) = {operation(10, 5)}");
            Console.WriteLine($"Divide(10, 0) = {operation(10, 0)}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}