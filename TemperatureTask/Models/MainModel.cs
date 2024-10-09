namespace TemperatureTask.Models
{
    internal class MainModel
    {
        public Temperature _temperature;
        public TemperatureScale _targetScale;

        public double SourceTemperature => GetTemperature(SourceScale);

        public double TargetTemperature => GetTemperature(TargetScale);

        public TemperatureScale SourceScale { get; set; }

        public TemperatureScale TargetScale { get; set; }

        public MainModel()
        {
            SourceScale = TemperatureScale.Kelvin;
            TargetScale = TemperatureScale.Fahrenheit;

            _temperature = new Temperature(100, SourceScale);
        }

        public double GetTemperature(TemperatureScale scale)
        {
            if (scale == TemperatureScale.Kelvin)
            {
                return _temperature.Kelvin;
            }
            else if (scale == TemperatureScale.Celsius)
            {
                return _temperature.Celsius;
            }
            else if (scale == TemperatureScale.Fahrenheit)
            {
                return _temperature.Fahrenheit;
            }

            return _temperature.Kelvin;
        }

        public void SetTemperature(double value, TemperatureScale scale)
        {
            if (scale == TemperatureScale.Kelvin)
            {
                _temperature.Kelvin = value;
            }
            else if (scale == TemperatureScale.Celsius)
            {
                _temperature.Celsius = value;
            }
            else if (scale == TemperatureScale.Fahrenheit)
            {
                _temperature.Fahrenheit = value;
            }
        }
    }
}