namespace TemperatureTask.Models;

using TemperatureScales;

internal interface IMainModel
{
    void SetSourceScale(string scaleCode);

    void SetTargetScale(string scaleCode);

    double GetTargetTemperature();

    double GetTemperature(TemperatureScale scale);

    void SetTemperature(double value, TemperatureScale scale);

    List<TemperatureScale> GetScales();

    TemperatureScale GetSourceScale();

    TemperatureScale GetTargetScale();
}