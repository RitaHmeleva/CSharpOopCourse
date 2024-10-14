namespace TemperatureTask.Models.TemperatureScales;

internal class CelsiusScale : TemperatureScale
{
    public override string Name => "Шкала Цельсия";

    public override string UnitsName => "Градусы Цельсия";

    public override string Code => "Celsius";

    public override double FromKelvin(double value)
    {
        return value - 273.15;
    }

    public override double ToKelvin(double value)
    {
        return value + 273.15;
    }
}