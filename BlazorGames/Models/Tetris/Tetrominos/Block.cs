using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class Block : Tetromino
    {
        public Block(Board board) : base(board) { }

        public override string CssClass
        {
            get
            {
                return "tetris-yellow-cell";
            }
        }

        public override CoordinateCollection CoveredSpaces
        {
            get
            {
                CoordinateCollection coordinates = new CoordinateCollection();
                coordinates.Add(CenterPieceRow, CenterPieceColumn);
                coordinates.Add(CenterPieceRow - 1, CenterPieceColumn);
                coordinates.Add(CenterPieceRow, CenterPieceColumn + 1);
                coordinates.Add(CenterPieceRow - 1, CenterPieceColumn + 1);
                return coordinates;
            }
        }
    }
}
