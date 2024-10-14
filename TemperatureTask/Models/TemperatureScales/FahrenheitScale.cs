namespace TemperatureTask.Models.TemperatureScales;

internal class FahrenheitScale : TemperatureScale
{
    public override string Name => "Шкала Фаренгейта";

    public override string UnitsName => "Градусы Фаренгейта";

    public override string Code => "Fahrenheit";

    public override double FromKelvin(double value)
    {
        return (value - 273.15) * 9 / 5 + 32;
    }

    public override double ToKelvin(double value)
    {
        return (value - 32) * 5 / 9 + 273.15;
    }
}