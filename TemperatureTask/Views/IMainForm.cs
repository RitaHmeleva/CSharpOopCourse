using TemperatureTask.Models.TemperatureScales;

namespace TemperatureTask.Views;

internal interface IMainForm
{
    void SetTemperatureScales(IReadOnlyList<ITemperatureScale> scales);

    void SetSourceTemperature(double value);

    void SetTargetTemperature(double value);

    void SetSourceScale(string scaleCode);

    void SetTargetScale(string scaleCode);

    event Action<double>? ConvertTemperature;

    event Action<string>? SaveSourceScale;

    event Action<string>? SaveTargetScale;
}