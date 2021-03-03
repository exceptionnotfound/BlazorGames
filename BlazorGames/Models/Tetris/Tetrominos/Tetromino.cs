using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class Tetromino
    {
        /// <summary>
        /// Represents the grid on which this tetromino can move.
        /// </summary>
        public Grid Grid { get; set; }

        /// <summary>
        /// The current orientation of this tetromino. Tetrominos rotate about their center.
        /// </summary>
        public TetrominoOrientation Orientation { get; set; } = TetrominoOrientation.LeftRight;

        /// <summary>
        /// The X-coordinate of the center piece.
        /// </summary>
        public int CenterPieceRow { get; set; }

        /// <summary>
        /// The Y-coordinate of the center piece.
        /// </summary>
        public int CenterPieceColumn { get; set; }

        /// <summary>
        /// The style of this tetromino, e.g. Straight, Block, T-Shaped, etc.
        /// </summary>
        public virtual TetrominoStyle Style { get; }

        /// <summary>
        /// The CSS class that is unique to this style of tetromino.
        /// </summary>
        public virtual string CssClass { get; }

        /// <summary>
        /// A collection of all spaces currently occupied by this tetromino.
        /// This collection is calculated by each style.
        /// </summary>
        public virtual CellCollection CoveredCells { get; }

        public Tetromino(Grid grid)
        {
            Grid = grid;
            CenterPieceRow = grid.Height;
            CenterPieceColumn = grid.Width / 2;
        }

        /// <summary>
        /// Rotates the tetromino around the center piece. Tetrominos always rotate clockwise.
        /// </summary>
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

            var coveredSpaces = CoveredCells;

            //If the new rotation of the tetromino means it would be outside the
            //play area, shift the center space so as to keep the entire tetromino visible.
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

        /// <summary>
        /// Moves the tetromino one column to the right
        /// </summary>
        public void MoveRight()
        {
            if (CanMoveRight())
            {
                CenterPieceColumn++;
            }
        }

        /// <summary>
        /// Make the tetromino drop all the way to its lowest possible point.
        /// </summary>
        /// <returns>The score gained from dropping the piece</returns>
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

        /// <summary>
        /// Move the tetromino down one row.
        /// </summary>
        public void MoveDown()
        {
            if (CanMoveDown())
            {
                CenterPieceRow--;
            }
        }

        /// <summary>
        /// Returns whether or not the tetromino can move in any direction (down, left, right).
        /// </summary>
        /// <returns></returns>
        public bool CanMove()
        {
            return CanMoveDown() || CanMoveLeft() || CanMoveRight();
        }

        /// <summary>
        /// Returns whether or not the tetromino can move down.
        /// </summary>
        /// <returns></returns>
        public bool CanMoveDown()
        {
            //For each of the covered spaces, get the space immediately below
            foreach (var coord in CoveredCells.GetLowest())
            {
                if (Grid.Cells.Contains(coord.Row - 1, coord.Column))
                    return false;
            }

            //If any of the covered spaces are currently in the lowest row, the piece cannot move down.
            if (CoveredCells.HasRow(1))
                return false;

            return true;
        }

        /// <summary>
        /// Returns whether or not the tetromino can move right
        /// </summary>
        /// <returns></returns>
        public bool CanMoveRight()
        {
            //For each of the covered spaces, get the space immediately to the right
            foreach (var cell in CoveredCells.GetRightmost())
            {
                if (Grid.Cells.Contains(cell.Row, cell.Column + 1))
                    return false;
            }

            //If any of the covered spaces are currently in the rightmost column, the piece cannot move right.
            if (CoveredCells.HasColumn(Grid.Width))
                return false;

            return true;
        }

        /// <summary>
        /// Moves the tetromino one column to the left.
        /// </summary>
        public void MoveLeft()
        {
            if (CanMoveLeft())
            {
                CenterPieceColumn--;
            }
        }

        /// <summary>
        /// Returns whether or not the tetromino can move to the left.
        /// </summary>
        /// <returns></returns>
        public bool CanMoveLeft()
        {
            //For each of the covered spaces, get the space immediately to the left
            foreach (var cell in CoveredCells.GetLeftmost())
            {
                if (Grid.Cells.Contains(cell.Row, cell.Column - 1))
                    return false;
            }

            //If any of the covered spaces are currently in the leftmost column, the piece cannot move left.
            if (CoveredCells.HasColumn(1))
                return false;

            return true;
        }
    }
}
