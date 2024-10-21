namespace TemperatureTask.Models;

using TemperatureScales;

internal interface IMainModel
{
    ITemperatureScale SourceScale { get; set; }

    ITemperatureScale TargetScale { get; set; }

    double TargetTemperature { get; }

    IReadOnlyList<ITemperatureScale> Scales { get; set; }

    void SetSourceScale(string scaleCode);

    void SetTargetScale(string scaleCode);

    double GetTemperature(ITemperatureScale scale);

    void SetTemperature(double value, ITemperatureScale scale);
}