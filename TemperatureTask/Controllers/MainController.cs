using TemperatureTask.Models;
using TemperatureTask.Views;

namespace TemperatureTask.Controllers;

internal class MainController
{
    private readonly IMainForm _view;
    private readonly IMainModel _model;

    public MainController(IMainForm view, IMainModel model)
    {
        _view = view;
        _model = model;

        _view.SetTemperatureScales(_model.Scales);

        _view.SetSourceScale(_model.SourceScale.Code);

        _view.SetTargetScale(_model.TargetScale.Code);

        _view.ConvertTemperature += ConvertTemperature;

        _view.SaveSourceScale += SaveSourceScale;

        _view.SaveTargetScale += SaveTargetScale;
    }

    private void SaveSourceScale(string scaleCode)
    {
        _model.SetSourceScale(scaleCode);
    }

    private void SaveTargetScale(string scaleCode)
    {
        _model.SetTargetScale(scaleCode);
    }

    private void ConvertTemperature(double value)
    {
        _model.SetTemperature(value);

        _view.SetTargetTemperature(_model.TargetTemperature);
    }
}