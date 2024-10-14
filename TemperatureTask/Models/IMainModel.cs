namespace TemperatureTask.Models;

using TemperatureScales;

internal interface IMainModel
{
    void SetSourceScale(TemperatureScale scale);

    void SetTargetScale(TemperatureScale scale);

    double GetTargetTemperature();

    double GetTemperature(TemperatureScale scale);

    void SetTemperature(double value, TemperatureScale scale);
}