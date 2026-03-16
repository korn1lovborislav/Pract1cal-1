using System;

namespace ClimateControl
{
    public class TemperatureSensor
    {
        private double _temperature;
        public event Action<double> TemperatureChanged;

        public double Temperature
        {
            get { return _temperature; }
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    TemperatureChanged?.Invoke(_temperature);
                }
            }
        }
    }
}