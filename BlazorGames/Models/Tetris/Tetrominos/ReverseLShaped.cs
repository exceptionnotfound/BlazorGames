using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    /// <summary>
    /// A reverse-L-shaped tetromino, also called a J-shaped tetromino
    /// X        X X    X X X      X
    /// X X X    X          X      X
    ///          X               X X
    /// </summary>
    public class ReverseLShaped : Tetromino
    {
        public ReverseLShaped(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.ReverseLShaped;

        public override string CssClass => "tetris-darkblue-cell";

        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new CellCollection();
                cells.Add(CenterPieceRow, CenterPieceColumn);
                
                switch(Orientation)
                {
                    case TetrominoOrientation.LeftRight:
                        cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                        cells.Add(CenterPieceRow, CenterPieceColumn + 2);
                        cells.Add(CenterPieceRow + 1, CenterPieceColumn);
                        break;

                    case TetrominoOrientation.DownUp:
                        cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                        cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                        cells.Add(CenterPieceRow - 2, CenterPieceColumn);
                        break;

                    case TetrominoOrientation.RightLeft:
                        cells.Add(CenterPieceRow, CenterPieceColumn - 1);
                        cells.Add(CenterPieceRow, CenterPieceColumn - 2);
                        cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                        break;

                    case TetrominoOrientation.UpDown:
                        cells.Add(CenterPieceRow, CenterPieceColumn - 1);
                        cells.Add(CenterPieceRow + 1, CenterPieceColumn);
                        cells.Add(CenterPieceRow + 2, CenterPieceColumn);
                        break;
                }
                return cells;
            }
        }
    }
}
