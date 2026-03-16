using System;

namespace ClimateControl
{
    public class Display
    {
        public void OnTemperatureChanged(double temperature)
        {
            Console.WriteLine($"[Display] Поточна температура: {temperature}°C");
        }
    }
}