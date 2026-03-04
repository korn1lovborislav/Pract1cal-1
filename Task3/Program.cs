using System;
using System.Text;

namespace FilterDelegateTask
{
    
    public delegate bool FilterPredicate(int number);

    class Program
    {
        
        static void FilterArray(int[] numbers, FilterPredicate predicate, string filterName)
        {
            Console.WriteLine($"\n{filterName}:");
            foreach (int num in numbers)
            {
                if (predicate(num))
                {
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }

        
        static bool IsEven(int n) => n % 2 == 0;
        static bool IsGreaterThanFive(int n) => n > 5;

        static void Main()
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Завдання 3: Фільтрація списку ===\n");

            
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

           
            Console.WriteLine("Всі числа:");
            foreach (int n in numbers) Console.Write(n + " ");
            Console.WriteLine();

           
            FilterArray(numbers, IsEven, "Парні числа");
            FilterArray(numbers, IsGreaterThanFive, "Числа більше 5");

           
            FilterArray(numbers, delegate (int n) { return n % 2 != 0; }, "Непарні числа");

           
            FilterArray(numbers, n => n % 3 == 0, "Числа кратні 3");

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}