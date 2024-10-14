namespace TemperatureTask.Controllers;

internal interface IMainController
{
    void SaveSourceScale(int index);

    void SaveTargetScale(int index);

    void ConvertTemperature(double value);
}