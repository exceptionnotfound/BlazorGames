using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    /// <summary>
    /// A "t-shaped" tetromino
    ///   X      X      X X X      X
    /// X X X    X X      X      X X
    ///          X                 X    
    /// </summary>
    public class TShaped : Tetromino
    {
        public TShaped(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.TShaped;

        public override string CssClass => "tetris-purple-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CenterPieceRow, CenterPieceColumn);

                if (Orientation == TetrominoOrientation.UpDown)
                {
                    cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                    cells.Add(CenterPieceRow + 1, CenterPieceColumn);
                    cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                }
                else if (Orientation == TetrominoOrientation.LeftRight)
                {
                    cells.Add(CenterPieceRow, CenterPieceColumn - 1);
                    cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                    cells.Add(CenterPieceRow + 1, CenterPieceColumn);
                }
                else if (Orientation == TetrominoOrientation.DownUp)
                {
                    cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                    cells.Add(CenterPieceRow + 1, CenterPieceColumn);
                    cells.Add(CenterPieceRow, CenterPieceColumn - 1);
                }
                else //RightLeft
                {
                    cells.Add(CenterPieceRow, CenterPieceColumn - 1);
                    cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                    cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                }

                return cells;
            }
        }
    }
}
