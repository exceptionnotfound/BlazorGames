using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    /// <summary>
    /// A straight-line tetromino
    /// X X X X    X
    ///            X
    ///            X
    ///            X
    /// </summary>
    public class Straight : Tetromino
    {
        public Straight(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.Straight;

        public override string CssClass => "tetris-lightblue-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CenterPieceRow, CenterPieceColumn);

                if (Orientation == TetrominoOrientation.LeftRight)
                {
                    cells.Add(CenterPieceRow, CenterPieceColumn - 1);
                    cells.Add(CenterPieceRow, CenterPieceColumn - 2);
                    cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                }
                else if (Orientation == TetrominoOrientation.DownUp)
                {
                    cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                    cells.Add(CenterPieceRow + 1, CenterPieceColumn);
                    cells.Add(CenterPieceRow + 2, CenterPieceColumn);
                }
                else if(Orientation == TetrominoOrientation.RightLeft)
                {
                    cells.Add(CenterPieceRow, CenterPieceColumn - 1);
                    cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                    cells.Add(CenterPieceRow, CenterPieceColumn + 2);
                }
                else //UpDown
                {
                    cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                    cells.Add(CenterPieceRow - 2, CenterPieceColumn);
                    cells.Add(CenterPieceRow + 1, CenterPieceColumn);
                }

                return cells;
            }
        }
    }
}
