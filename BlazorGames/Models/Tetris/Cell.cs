using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string CssClass { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Cell(int row, int column, string css)
        {
            Row = row;
            Column = column;
            CssClass = css;
        }
    }
}
