using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class TetrominoGenerator
    {
        public TetrominoStyle Next(params TetrominoStyle[] unusableStyles)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            var style = (TetrominoStyle)rand.Next(1, 8);

            while (unusableStyles.Contains(style))
                style = (TetrominoStyle)rand.Next(1, 8);

            return style;
        }

        public Tetromino CreateFromStyle(TetrominoStyle style, Board board)
        {
            return style switch
            {
                TetrominoStyle.Block => new Block(board),
                TetrominoStyle.Straight => new Straight(board),
                TetrominoStyle.TShaped => new TShaped(board),
                TetrominoStyle.LeftZigZag => new LeftZigZag(board),
                TetrominoStyle.RightZigZag => new RightZigZag(board),
                TetrominoStyle.LShaped => new LShaped(board),
                TetrominoStyle.ReverseLShaped => new ReverseLShaped(board),
                _ => new Block(board),
            };
        }
    }
}
