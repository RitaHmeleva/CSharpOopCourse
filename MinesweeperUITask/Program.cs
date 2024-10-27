using MinesweeperUITask.Controllers;

namespace MinesweeperUITask
{
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
            
            var form = new Minesweeper.Gui.Views.MainForm();
            var model = new Minesweeper.Logic.Models.GameModel();
            var controller = new MainController(form, model);

            Application.Run(form);
        }
    }
}