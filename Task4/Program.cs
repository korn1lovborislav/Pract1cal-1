using System;
using System.Collections.Generic;
using System.Text;

namespace StandardDelegatesTask
{
    class Program
    {
        static void Main()
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Завдання 4: Стандартні делегати ===\n");

           
            Console.WriteLine("--- Калькулятор з Func ---");

            
            Func<double, double, double> add = (x, y) => x + y;
            Func<double, double, double> subtract = (x, y) => x - y;
            Func<double, double, double> multiply = (x, y) => x * y;
            Func<double, double, double> divide = (x, y) => y != 0 ? x / y : 0;

            Console.WriteLine($"Add(15, 5) = {add(15, 5)}");
            Console.WriteLine($"Subtract(15, 5) = {subtract(15, 5)}");
            Console.WriteLine($"Multiply(15, 5) = {multiply(15, 5)}");
            Console.WriteLine($"Divide(15, 5) = {divide(15, 5)}");

            
            Console.WriteLine("\n--- Фільтрація списку студентів ---");

            List<string> students = new List<string>
            {
                "Андрій", "Богдан", "Василь", "Ганна", "Дмитро",
                "Анна", "Борис", "Віктор", "Галина", "Дарина"
            };

           
            Console.WriteLine("Всі студенти:");
            foreach (var student in students) Console.Write(student + " ");
            Console.WriteLine();

            
            List<string> studentsWithA = students.FindAll(s => s.StartsWith("А"));
            Console.WriteLine("\nСтуденти на літеру 'А':");
            foreach (var student in studentsWithA) Console.Write(student + " ");
            Console.WriteLine();

            
            List<string> longNames = students.FindAll(s => s.Length > 5);
            Console.WriteLine("\nСтуденти з іменем довше 5 символів:");
            foreach (var student in longNames) Console.Write(student + " ");
            Console.WriteLine();

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}