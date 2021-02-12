using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class Tetromino
    {
        public Board Board { get; set; }

        public TetrominoStyle Style { get; set; }

        public TetrominoOrientation Orientation { get; set; } = TetrominoOrientation.LeftRight;

        public int CenterPieceRow { get; set; }

        public int CenterPieceColumn { get; set; }

        public virtual string CssClass { get; }

        public virtual CoordinateCollection CoveredSpaces { get; }

        public Tetromino(Board board)
        {
            Board = board;
            CenterPieceRow = board.Height;
            CenterPieceColumn = board.Width / 2;
        }

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

        public void MoveRight()
        {
            if (CanMoveRight())
            {
                CenterPieceColumn++;
            }
        }

        public int Drop()
        {
            int scoreCounter = 0;
            while(CanMoveDown())
            {
                MoveDown();
                scoreCounter++;
            }

            return scoreCounter;
        }

        public void MoveDown()
        {
            if (CanMoveDown())
            {
                CenterPieceRow--;
            }
        }

        public bool CanMove()
        {
            return CanMoveDown() || CanMoveLeft() || CanMoveRight();
        }

        public bool CanMoveDown()
        {
            //For each of the covered spaces, get the space immediately below
            foreach (var coord in CoveredSpaces.GetLowest())
            {
                if (Board.Coordinates.Contains(coord.Row - 1, coord.Column))
                    return false;
            }

            //If any of the covered spaces are currently in the lowest row, the piece cannot move down.
            if (CoveredSpaces.HasRow(1))
                return false;

            return true;
        }

        public bool CanMoveRight()
        {
            //For each of the covered spaces, get the space immediately to the right
            foreach (var coord in CoveredSpaces.GetRightmost())
            {
                if (Board.Coordinates.Contains(coord.Row, coord.Column + 1))
                    return false;
            }

            //If any of the covered spaces are currently in the rightmost column, the piece cannot move right.
            if (CoveredSpaces.HasColumn(10))
                return false;

            return true;
        }

        public void MoveLeft()
        {
            if (CanMoveLeft())
            {
                CenterPieceColumn--;
            }
        }

        public bool CanMoveLeft()
        {
            //For each of the covered spaces, get the space immediately to the left
            foreach (var coord in CoveredSpaces.GetLeftmost())
            {
                if (Board.Coordinates.Contains(coord.Row, coord.Column - 1))
                    return false;
            }

            //If any of the covered spaces are currently in the leftmost column, the piece cannot move left.
            if (CoveredSpaces.HasColumn(1))
                return false;

            return true;
        }
    }
}
