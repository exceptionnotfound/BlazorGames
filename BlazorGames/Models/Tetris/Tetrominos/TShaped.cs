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

        public override CoordinateCollection CoveredSpaces
        {
            get
            {
                CoordinateCollection coordinates = new CoordinateCollection();
                coordinates.Add(CenterPieceRow, CenterPieceColumn);

                if (Orientation == TetrominoOrientation.UpDown)
                {
                    coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                }
                else if (Orientation == TetrominoOrientation.LeftRight)
                {
                    coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                    coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                }
                else if (Orientation == TetrominoOrientation.DownUp)
                {
                    coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                }
                else //RightLeft
                {
                    coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                    coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                }

                return coordinates;
            }
        }
    }
}
