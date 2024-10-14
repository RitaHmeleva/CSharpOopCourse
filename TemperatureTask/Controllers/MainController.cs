using TemperatureTask.Models;

namespace TemperatureTask.Controllers;

internal class MainController
{
    private MainForm _view;
    private MainModel _model;

    public MainController(MainForm view, MainModel model)
    {
        _view = view;
        _model = model;

        _view.ConvertTemperature = ConvertTemperature;

        _view.SetSourceScales(_model.GetScales().ToDictionary(k => k.Code, i => i.UnitsName));

        _view.SetTargetScales(_model.GetScales().ToDictionary(k => k.Code, i => i.UnitsName));

        _view.SaveSourceScale = SaveSourceScale;

        _view.SaveTargetScale = SaveTargetScale;

        _view.SetSourceScale(_model.GetSourceScale().Code);

        _view.SetTargetScale(_model.GetTargetScale().Code);
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
        _model.SetTemperature(value, _model.GetSourceScale());

        _view.SetTargetTemperature(Math.Round(_model.GetTargetTemperature(), 3, MidpointRounding.AwayFromZero));
    }
}