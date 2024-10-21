namespace TemperatureTask.Models.TemperatureScales;

internal class KelvinScale : ITemperatureScale
{
    public string Name => "Шкала Кельвина";

    public string UnitsName => "Кельвины";

    public string Code => "Kelvin";

    public double ConvertFromKelvin(double value)
    {
        return value;
    }

    public double ConvertToKelvin(double value)
    {
        return value;
    }
}