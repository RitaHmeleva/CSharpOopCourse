using TemperatureTask.Controllers;
using TemperatureTask.Models;
using TemperatureTask.Models.TemperatureScales;

namespace TemperatureTask;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var mainForm = new MainForm();
        var model = new MainModel(new List<ITemperatureScale>
        {
            new KelvinScale(),
            new CelsiusScale(),
            new FahrenheitScale()
        });
        var controller = new MainController(mainForm, model);

        Application.Run(mainForm);
    }
}