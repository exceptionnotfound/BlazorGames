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
            switch (style)
            {
                case TetrominoStyle.Block:
                    return new Block(board);

                case TetrominoStyle.Straight:
                    return new Straight(board);

                case TetrominoStyle.TShaped:
                    return new TShaped(board);

                case TetrominoStyle.LeftZigZag:
                    return new LeftZigZag(board);

                case TetrominoStyle.RightZigZag:
                    return new RightZigZag(board);

                case TetrominoStyle.LShaped:
                    return new LShaped(board);

                case TetrominoStyle.ReverseLShaped:
                    return new ReverseLShaped(board);

                default:
                    return new Block(board);
            }
        }
    }
}
