namespace TemperatureTask.Models.TemperatureScales;

internal class CelsiusScale : ITemperatureScale
{
    public string Name => "Шкала Цельсия";

    public string UnitsName => "Градусы Цельсия";

    public string Code => "Celsius";

    public double ConvertFromKelvin(double value)
    {
        return value - 273.15;
    }

    public double ConvertToKelvin(double value)
    {
        return value + 273.15;
    }
}