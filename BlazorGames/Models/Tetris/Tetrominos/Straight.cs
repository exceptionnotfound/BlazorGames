using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class Straight : Tetromino
    {
        public override string CssClass
        {
            get
            {
                return "tetris-lightblue-piece";
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
