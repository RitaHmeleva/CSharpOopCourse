namespace TemperatureTask.Models.TemperatureScales;

internal class KelvinScale : TemperatureScale
{
    public override string Name => "Шкала Кельвина";

    public override string UnitsName => "Кельвины";

    public override string Code => "Kelvin";

    public override double FromKelvin(double value)
    {
        return value;
    }

    public override double ToKelvin(double value)
    {
        return value;
    }
}