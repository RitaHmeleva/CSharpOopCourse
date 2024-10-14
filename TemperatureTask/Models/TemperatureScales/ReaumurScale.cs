namespace TemperatureTask.Models.TemperatureScales;

internal class ReaumurScale : TemperatureScale
{
    public override string Name => "Шкала Реомюра";

    public override string UnitsName => "Градусы Реомюра";

    public override string Code => "Reaumur";

    public override double FromKelvin(double value)
    {
        return 0.8 * value - 218;
    }

    public override double ToKelvin(double value)
    {
        return 1.25 * value + 273.15;
    }
}