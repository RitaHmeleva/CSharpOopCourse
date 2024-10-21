namespace TemperatureTask.Models.TemperatureScales
{
    public interface ITemperatureScale
    {
        string Name { get; }

        string UnitsName { get; }

        string Code { get; }

        double ConvertToKelvin(double value);

        double ConvertFromKelvin(double value);
    }
}