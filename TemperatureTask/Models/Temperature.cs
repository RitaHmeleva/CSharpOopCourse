namespace TemperatureTask.Models
{
    enum TemperatureScale
    {
        Kelvin = 0,
        Celsius = 1,
        Fahrenheit = 2
    }

    internal class Temperature
    {
        public double Kelvin { get; set; }

        public double Celsius
        {
            get
            {
                return Kelvin - 273.15;
            }
            set
            {
                Kelvin = value + 273.15;
            }
        }

        public double Fahrenheit
        {
            get
            {
                return (Kelvin - 273.15) * 9 / 5 + 32;
            }
            set
            {
                Kelvin = (value - 32) * 5 / 9 + 273.15;
            }
        }

        public Temperature()
        {
            Kelvin = 0;
        }

        public Temperature(double temperature, TemperatureScale scale)
        {
            if (scale == TemperatureScale.Kelvin)
            {
                Kelvin = temperature;
            }
            else if (scale == TemperatureScale.Celsius)
            {
                Celsius = temperature;
            }
            else if (scale == TemperatureScale.Fahrenheit)
            {
                Fahrenheit = temperature;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}