namespace TemperatureTask.Models;

using Models.TemperatureScales;

internal class TemperatureModel
{
    private List<TemperatureScale> _scales;

    public List<TemperatureScale> Scales => _scales;

    public double Kelvin { get; set; }

    public TemperatureModel()
    {
        _scales = new List<TemperatureScale>
        {
            new KelvinScale(),
            new CelsiusScale(),
            new FahrenheitScale()
        };
    }

    public TemperatureModel(double temperature, string scaleCode) : this()
    {
        TemperatureScale? scale = GetScaleByCode(scaleCode);

        if (scale != null)
        {
            Kelvin = scale.ToKelvin(temperature);
        }
        else
        {
            throw new ArgumentException("Incorrect temperature scale's code", nameof(scaleCode));
        }
    }

    public List<TemperatureScale> GetScales()
    {
        return Scales;
    }

    public TemperatureScale GetScaleByCode(string code)
    {
        var scale = Scales.Find(s => s.Code == code);

        if (scale == null)
        {
            throw new ArgumentException("Invalid temperature code");
        }

        return scale;
    }

    public double GetTemperature(TemperatureScale scale)
    {
        return scale.FromKelvin(Kelvin);
    }

    public double GetTemperature(double temperature, TemperatureScale scale)
    {
        return scale.FromKelvin(temperature);
    }

    public void SetTemperature(double temperature, TemperatureScale scale)
    {
        Kelvin = scale.ToKelvin(temperature);
    }
}