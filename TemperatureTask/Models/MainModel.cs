namespace TemperatureTask.Models;

using Models.TemperatureScales;

internal class MainModel : IMainModel
{
    public IReadOnlyList<ITemperatureScale> Scales { get; set; }

    public double Kelvin { get; set; }

    public double TargetTemperature => GetTemperature(TargetScale);

    public ITemperatureScale SourceScale { get; set; }

    public ITemperatureScale TargetScale { get; set; }

    public MainModel()
    {
        Scales = new List<ITemperatureScale>
        {
            new KelvinScale(),
            new CelsiusScale(),
            new FahrenheitScale()
        };

        SourceScale = GetScaleByCode("Celsius");
        TargetScale = GetScaleByCode("Fahrenheit");
    }

    public void SetSourceScale(string scaleCode)
    {
        SourceScale = GetScaleByCode(scaleCode);
    }

    public void SetTargetScale(string scaleCode)
    {
        TargetScale = GetScaleByCode(scaleCode);
    }

    public double GetTargetTemperature()
    {
        return GetTemperature(TargetScale);
    }

    public double GetTemperature(ITemperatureScale scale)
    {
        return scale.ConvertFromKelvin(Kelvin);
    }

    public ITemperatureScale GetScaleByCode(string code)
    {
        var scale = Scales.Where(s => s.Code == code).First();

        if (scale == null)
        {
            throw new ArgumentException("Invalid temperature code", nameof(code));
        }

        return scale;
    }

    public void SetTemperature(double temperature, ITemperatureScale scale)
    {
        Kelvin = scale.ConvertToKelvin(temperature);
    }
}