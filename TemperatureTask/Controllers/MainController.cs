using TemperatureTask.Models;

namespace TemperatureTask.Controllers
{
    internal class MainController
    {
        MainForm _view;
        MainModel _model;

        List<string> scales = new List<string> { "Кельвины", "Градусы Цельсия", "Градусы Фаренгейта" };

        public MainController(MainForm view)
        {
            _view = view;
            _model = new MainModel();

            _view.SaveSourceScale = SaveSourceScale;

            _view.SaveTargetScale = SaveTargetScale;

            _view.ConvertTemperature = ConvertTemperature;

            _view.SetSourceScales(scales);

            _view.SetTargetScales(scales);

            _view.SetSourceTemperature(_model.SourceTemperature);

            _view.SetSourceScale((int)_model.SourceScale);

            _view.SetTargetScale((int)_model.TargetScale);
        }

        private void SaveSourceScale(int index)
        {
            _model.SourceScale = (TemperatureScale)index;
        }

        private void SaveTargetScale(int index)
        {
            _model.TargetScale = (TemperatureScale)index;
        }

        private void ConvertTemperature(double value)
        {
            _model.SetTemperature(value, _model.SourceScale);

            _view.SetTargetTemperature(Math.Round(_model.TargetTemperature, 3));
        }
    }
}