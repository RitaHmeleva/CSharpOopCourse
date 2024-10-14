namespace TemperatureTask.Views;

internal interface IMainForm
{
    void SetSourceScales(Dictionary<string, string> scales);

    void SetTargetScales(Dictionary<string, string> scales);

    void SetSourceTemperature(double value);

    void SetTargetTemperature(double value);

    void SetSourceScale(string scaleCode);

    void SetTargetScale(string scaleCode);
}