using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    /// <summary>
    /// A square or "block" tetromino. Block tetrominos do not rotate.
    /// X X
    /// X X
    /// </summary>
    public class Block : Tetromino
    {
        public Block(Grid board) : base(board) { }

        public override TetrominoStyle Style => TetrominoStyle.Block;

        public override string CssClass => "tetris-yellow-cell";

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
