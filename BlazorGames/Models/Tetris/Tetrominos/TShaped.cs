using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class TShaped : Tetromino
    {
        public TShaped(Board board) : base(board) { }

        public override string CssClass
        {
            get
            {
                return "tetris-purple-piece";
            }
        }

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
