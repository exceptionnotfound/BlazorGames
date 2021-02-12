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
        public Straight(Grid board) : base(board) { }

        public override TetrominoStyle Style => TetrominoStyle.Straight;

        public override string CssClass => "tetris-lightblue-cell";

        public override CoordinateCollection CoveredSpaces
        {
            get
            {
                CoordinateCollection coordinates = new CoordinateCollection();
                coordinates.Add(CenterPieceRow, CenterPieceColumn);

                if (Orientation == TetrominoOrientation.UpDown)
                {
                    coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow - 2, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                }
                else if (Orientation == TetrominoOrientation.LeftRight)
                {
                    coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn - 2);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                }
                else if (Orientation == TetrominoOrientation.DownUp)
                {
                    coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                    coordinates.Add(CenterPieceRow + 2, CenterPieceColumn);
                }
                else //RightLeft
                {
                    coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                    coordinates.Add(CenterPieceRow, CenterPieceColumn + 2);
                }

                return coordinates;
            }
        }
    }
}
