using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperUITask.Models
{
    class Cell
    {
        bool IsOpen;
        int MineAroundCount;
        bool HasMine;
        bool HasFlag;
    }

    class Field
    {
        int RowCount;
        int ColumnCount;
        Cell[,] cells;
        int MinesCount;
        int OpenCellsCount;
    }

    class Model
    {
        Field field;
        GameLevel level;
    }

    class GameLevel
    {
        int RowCount;
        int ColumnCount;
        int MinesCount;
    }
}