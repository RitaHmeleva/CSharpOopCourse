using TemperatureTask.Models;
using TemperatureTask.Views;

namespace TemperatureTask.Controllers;

internal class MainController
{
    private IMainForm _view;
    private IMainModel _model;

    public MainController(IMainForm view, IMainModel model)
    {
        _view = view;
        _model = model;

        _view.SetSourceScales(_model.GetScales().ToDictionary(k => k.Code, i => i.UnitsName));

        _view.SetTargetScales(_model.GetScales().ToDictionary(k => k.Code, i => i.UnitsName));

        _view.SetSourceScale(_model.GetSourceScale().Code);

        _view.SetTargetScale(_model.GetTargetScale().Code);

        _view.ConvertTemperature += ConvertTemperature;

        _view.SaveSourceScale += SaveSourceScale;

        _view.SaveTargetScale += SaveTargetScale;
    }

    private void SaveSourceScale(object? sender, string scaleCode)
    {
        _model.SetSourceScale(scaleCode);
    }

    private void SaveTargetScale(object? sender, string scaleCode)
    {
        _model.SetTargetScale(scaleCode);
    }

    private void ConvertTemperature(object? sender, double value)
    {
        _model.SetTemperature(value, _model.GetSourceScale());

        _view.SetTargetTemperature(Math.Round(_model.GetTargetTemperature(), 3, MidpointRounding.AwayFromZero));
    }
}