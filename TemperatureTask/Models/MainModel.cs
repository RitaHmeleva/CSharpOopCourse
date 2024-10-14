namespace TemperatureTask.Models;

using Models.TemperatureScales;

internal class MainModel
{
    private TemperatureModel _temperature;

    private double TargetTemperature => GetTemperature(TargetScale);

    private TemperatureScale SourceScale { get; set; }

    private TemperatureScale TargetScale { get; set; }

    public MainModel()
    {
        _temperature = new TemperatureModel(100, "Celsius");

        SourceScale = _temperature.GetScaleByCode("Celsius");
        TargetScale = _temperature.GetScaleByCode("Fahrenheit");
    }

    public void SetSourceScale(TemperatureScale scale)
    {
        SourceScale = scale;
    }

    public void SetSourceScale(string scaleCode)
    { 
        SourceScale = _temperature.GetScaleByCode(scaleCode);
    }

    public void SetTargetScale(TemperatureScale scale)
    {
        TargetScale = scale;
    }

    public void SetTargetScale(string scaleCode)
    {
        TargetScale = _temperature.GetScaleByCode(scaleCode);
    }

    public List<TemperatureScale> GetScales()
    {
        return _temperature.GetScales();
    }

    public double GetTargetTemperature()
    {
        return TargetTemperature;
    }

    public TemperatureScale GetSourceScale()
    {
        return SourceScale;
    }

    public TemperatureScale GetTargetScale()
    {
        return TargetScale;
    }

    public double GetTemperature(TemperatureScale scale)
    {
        return _temperature.GetTemperature(scale);
    }

    public void SetTemperature(double value, TemperatureScale scale)
    { 
        _temperature.SetTemperature(value, scale);
    }
}