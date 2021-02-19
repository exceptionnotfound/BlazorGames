using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    /// <summary>
    /// A left-zigzag tetromino
    /// X X        X
    ///   X X    X X
    ///          X
    /// </summary>
    public class LeftZigZag : Tetromino
    {
        public LeftZigZag(Grid grid) : base(grid) { }

        public override TetrominoStyle Style => TetrominoStyle.LeftZigZag;

        public override string CssClass => "tetris-red-cell";

        public override CoordinateCollection CoveredSpaces
        {
            get
            {
                CoordinateCollection coordinates = new CoordinateCollection();
                coordinates.Add(CenterPieceRow, CenterPieceColumn);
                
                switch(Orientation)
                {
                    case TetrominoOrientation.LeftRight:
                        coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                        coordinates.Add(CenterPieceRow + 1, CenterPieceColumn - 1);
                        coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                        break;

                    case TetrominoOrientation.DownUp:
                        coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                        coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                        coordinates.Add(CenterPieceRow + 1, CenterPieceColumn + 1);
                        break;

                    case TetrominoOrientation.RightLeft:
                        coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                        coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                        coordinates.Add(CenterPieceRow - 1, CenterPieceColumn + 1);
                        break;

                    case TetrominoOrientation.UpDown:
                        coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                        coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                        coordinates.Add(CenterPieceRow - 1, CenterPieceColumn - 1);
                        break;
                }
                return coordinates;
            }
        }
    }
}
