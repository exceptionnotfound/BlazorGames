using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class ReverseLShaped : Tetromino
    {
        public override string CssClass
        {
            get
            {
                return "tetris-darkblue-piece";
            }
        }

        public override CoordinateCollection CoveredSpaces
        {
            get
            {
                CoordinateCollection coordinates = new CoordinateCollection();
                coordinates.Add(CenterPieceRow, CenterPieceColumn);
                
                switch(Orientation)
                {
                    case TetrominoOrientation.LeftRight:
                        coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                        coordinates.Add(CenterPieceRow, CenterPieceColumn + 2);
                        coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                        break;

                    case TetrominoOrientation.DownUp:
                        coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                        coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                        coordinates.Add(CenterPieceRow - 2, CenterPieceColumn);
                        break;

                    case TetrominoOrientation.RightLeft:
                        coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                        coordinates.Add(CenterPieceRow, CenterPieceColumn - 2);
                        coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                        break;

                    case TetrominoOrientation.UpDown:
                        coordinates.Add(CenterPieceRow, CenterPieceColumn - 1);
                        coordinates.Add(CenterPieceRow + 1, CenterPieceColumn);
                        coordinates.Add(CenterPieceRow + 2, CenterPieceColumn);
                        break;
                }
                return coordinates;
            }
        }
    }
}
