using Minesweeper.Logic.Models;
using Minesweeper.Gui.Views;

namespace MinesweeperUITask.Controllers;

internal class MainController
{
    private IMainForm _view;
    private IGameModel _model;

    public MainController(IMainForm view, IGameModel model)
    {
        _model = model;

        _view = view;

        _view.OpenCell += OpenCell;

        _view.ToggleFlag += ToggleFlag;

        _view.GameLevelSelected += GameLevelSelected;

        _view.RecordsTableRequested += RecordsTableRequested;

        _model.FieldCreated += FieldCreated;

        _model.FlagToggled += FlagToggledHandler;

        _model.CellOpened += CellOpenedHandler;

        _model.GameLost += GameLostHandler;

        _model.GameWon += GameWonHandler;

        _model.MineOpened += MineOpenedHandler;

        GameLevel[] levels = _model.GetLevels();

        foreach (GameLevel level in levels)
        {
            _view.AddLevel(level.Name, level.RowsCount, level.ColumnsCount, level.MinesCount);
        }
    }

    private void RecordsTableRequested()
    {
        List<(string Level, int Time, string GamerName)> records = _model.GetRecordsTable();

        _view.ShowRecordsTable(records);
    }

    private void GameLostHandler((int RowIndex, int ColumnIndex) e)
    {
        _view.SetGameLost(e.RowIndex, e.ColumnIndex);
    }

    private void GameWonHandler()
    {
        int gameTime = _view.SetGameWon();

        if (_model.IsGameRecord(gameTime))
        {
            string gamerName = _view.GetGamer();

            _model.SaveRecord(gamerName, gameTime);
        }
    }

    private void FlagToggledHandler((int RowIndex, int ColumnIndex, bool HasFlag) e)
    {
        _view.SetFlag(e.RowIndex, e.ColumnIndex, e.HasFlag);
    }

    private void MineOpenedHandler((int RowIndex, int ColumnIndex, bool HasFlag) e)
    {
        _view.OpenMine(e.RowIndex, e.ColumnIndex, e.HasFlag);
    }

    private void CellOpenedHandler((int RowIndex, int ColumnIndex, int MinesAroundCount) e)
    {
        _view.CellOpenedHandler(e.RowIndex, e.ColumnIndex, e.MinesAroundCount);
    }

    private void FieldCreated()
    {
        _view.SetGameReady();
    }

    private void GameLevelSelected((int RowsCount, int ColumnsCount, int MinesCount) e)
    {
        _model.CreateField(e.RowsCount, e.ColumnsCount, e.MinesCount);
    }

    private void OpenCell(int row, int column)
    {
        _model.OpenCell(row, column);
    }

    private void ToggleFlag(int row, int column)
    {
        _model.ToggleFlag(row, column);
    }
}