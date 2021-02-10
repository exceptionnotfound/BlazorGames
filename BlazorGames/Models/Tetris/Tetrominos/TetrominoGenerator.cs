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

        public Tetromino CreateFromStyle(TetrominoStyle style)
        {
            switch (style)
            {
                case TetrominoStyle.Block:
                    return new Block();

                case TetrominoStyle.Straight:
                    return new Straight();

                case TetrominoStyle.TShaped:
                    return new TShaped();

                case TetrominoStyle.LeftZigZag:
                    return new LeftZigZag();

                case TetrominoStyle.RightZigZag:
                    return new RightZigZag();

                case TetrominoStyle.LShaped:
                    return new LShaped();

                case TetrominoStyle.ReverseLShaped:
                    return new ReverseLShaped();

                default:
                    return new Block();
            }
        }
    }
}
