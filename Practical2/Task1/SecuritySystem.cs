using System;

namespace ClimateControl
{
    public class SecuritySystem
    {
        public void OnTemperatureChanged(double temperature)
        {
            if (temperature > 40)
            {
                Console.WriteLine($"[SecuritySystem] УВАГА! ПЕРЕГРІВ! Температура {temperature}°C > 40°C");
            }
            else if (temperature < 5)
            {
                Console.WriteLine($"[SecuritySystem] ПОПЕРЕДЖЕННЯ! Ризик замерзання! Температура {temperature}°C < 5°C");
            }
        }
    }
}