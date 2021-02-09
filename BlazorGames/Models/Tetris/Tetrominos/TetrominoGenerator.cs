using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Tetrominos
{
    public class TetrominoGenerator
    {
        public Tetromino Next(TetrominoStyle? currentStyle)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            var style = (TetrominoStyle)rand.Next(1, 4);

            while(style == currentStyle)
            {
                style = (TetrominoStyle)rand.Next(1, 4);
            }

            switch(style)
            {
                case TetrominoStyle.Block:
                    return new Block();

                case TetrominoStyle.Straight:
                    return new Straight();

                case TetrominoStyle.TShaped:
                    return new TShaped();

                default:
                    return new Block();
            }
        }
    }
}
