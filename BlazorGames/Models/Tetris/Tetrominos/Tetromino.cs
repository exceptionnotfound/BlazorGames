using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class Tetromino
    {
        public TetrominoStyle Style { get; set; }

        public TetrominoOrientation Orientation { get; set; } = TetrominoOrientation.LeftRight;

        public int CenterPieceRow { get; set; } = 20;

        public int CenterPieceColumn { get; set; } = 5;

        public virtual string CssClass { get; }

        public virtual CoordinateCollection CoveredSpaces { get; }

        public void Rotate() 
        { 
            switch(Orientation)
            {
                case TetrominoOrientation.UpDown:
                    Orientation = TetrominoOrientation.RightLeft;
                    break;

                case TetrominoOrientation.RightLeft:
                    Orientation = TetrominoOrientation.DownUp;
                    break;

                case TetrominoOrientation.DownUp:
                    Orientation = TetrominoOrientation.LeftRight;
                    break;

                case TetrominoOrientation.LeftRight:
                    Orientation = TetrominoOrientation.UpDown;
                    break;
            }

            var coveredSpaces = CoveredSpaces;

            if(coveredSpaces.HasColumn(-1))
            {
                CenterPieceColumn += 2;
            }
            else if (coveredSpaces.HasColumn(12))
            {
                CenterPieceColumn -= 2;
            }
            else if (coveredSpaces.HasColumn(0))
            {
                CenterPieceColumn++;
            }
            else if (coveredSpaces.HasColumn(11))
            {
                CenterPieceColumn--;
            }
        }

        public void MoveRight(Board board)
        {
            if (CanMoveRight(board))
            {
                CenterPieceColumn++;
            }
        }

        public void MoveDown(Board board)
        {
            if (CanMoveDown(board))
                CenterPieceRow--;
        }

        public bool CanMoveDown(Board board)
        {
            //For each of the covered spaces, get the space immediately below
            foreach (var coord in CoveredSpaces.GetLowest())
            {
                if (board.Coordinates.Contains(coord.Row - 1, coord.Column))
                    return false;
            }

            if (CoveredSpaces.HasRow(1))
                return false;

            return true;
        }

        public bool CanMoveRight(Board board)
        {
            //For each of the covered spaces, get the space immediately to the right
            foreach (var coord in CoveredSpaces.GetRightmost())
            {
                if (board.Coordinates.Contains(coord.Row, coord.Column + 1))
                    return false;
            }

            if (CoveredSpaces.HasColumn(10))
                return false;

            return true;
        }

        public void MoveLeft(Board board)
        {
            if (CanMoveLeft(board))
            {
                CenterPieceColumn--;
            }
        }

        public bool CanMoveLeft(Board board)
        {
            //For each of the covered spaces, get the space immediately to the left
            foreach (var coord in CoveredSpaces.GetLeftmost())
            {
                if (board.Coordinates.Contains(coord.Row, coord.Column - 1))
                    return false;
            }

            if (CoveredSpaces.HasColumn(1))
                return false;

            return true;
        }
    }
}
