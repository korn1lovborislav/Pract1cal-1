using System;
using System.Text;

namespace ClimateControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== СИСТЕМА КЛІМАТ-КОНТРОЛЮ ===\n");

            TemperatureSensor sensor = new TemperatureSensor();
            Display display = new Display();
            AirConditioner ac = new AirConditioner();
            SecuritySystem security = new SecuritySystem();

            sensor.TemperatureChanged += display.OnTemperatureChanged;
            sensor.TemperatureChanged += ac.OnTemperatureChanged;
            sensor.TemperatureChanged += security.OnTemperatureChanged;

            Console.WriteLine("1. Встановлюємо температуру 10°C:\n");
            sensor.Temperature = 10;

            Console.WriteLine("\n2. Встановлюємо температуру 22°C:\n");
            sensor.Temperature = 22;

            Console.WriteLine("\n3. Встановлюємо температуру 30°C:\n");
            sensor.Temperature = 30;

            Console.WriteLine("\n4. Встановлюємо температуру 42°C:\n");
            sensor.Temperature = 42;

            Console.WriteLine("\n5. Встановлюємо температуру 3°C:\n");
            sensor.Temperature = 3;

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}