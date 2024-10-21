namespace TemperatureTask.Models.TemperatureScales;

internal class FahrenheitScale : ITemperatureScale
{
    public string Name => "Шкала Фаренгейта";

    public string UnitsName => "Градусы Фаренгейта";

    public string Code => "Fahrenheit";

    public double ConvertFromKelvin(double value)
    {
        return (value - 273.15) * 9 / 5 + 32;
    }

    public double ConvertToKelvin(double value)
    {
        return (value - 32) * 5 / 9 + 273.15;
    }
}