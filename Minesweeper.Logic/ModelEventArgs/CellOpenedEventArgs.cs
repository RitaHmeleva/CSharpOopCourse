using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.ModelEventArgs
{
    public class CellOpenedEventArgs : EventArgs
    {
        public int RowIndexx { get; set; }

        public int ColumnIndex { get; set; }

        public int MinesAroundCount { get; set; }

        public CellOpenedEventArgs(int rowIndexx, int columnIndex, int minesAroundCount)
        {
            RowIndexx = rowIndexx;
            ColumnIndex = columnIndex;
            MinesAroundCount = minesAroundCount;
        }
    }
}
