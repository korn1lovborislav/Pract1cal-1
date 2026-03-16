using System;

namespace ClimateControl
{
    public class AirConditioner
    {
        public void OnTemperatureChanged(double temperature)
        {
            if (temperature < 17)
            {
                Console.WriteLine("[AirConditioner] Увімкнено ОБІГРІВ (температура < 17°C)");
            }
            else if (temperature >= 17 && temperature <= 25)
            {
                Console.WriteLine("[AirConditioner] Кондиціонер ВИМКНЕНО (температура 17-25°C)");
            }
            else
            {
                Console.WriteLine("[AirConditioner] Увімкнено ОХОЛОДЖЕННЯ (температура > 25°C)");
            }
        }
    }
}