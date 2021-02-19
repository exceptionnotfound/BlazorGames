using BlazorGames.Models.Tetris.Enums;
using BlazorGames.Models.Tetris.Tetrominos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris
{
    public class TetrominoGenerator
    {
        public TetrominoStyle Next(params TetrominoStyle[] unusableStyles)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            //Randomly generate one of the eight possible tetrominos
            var style = (TetrominoStyle)rand.Next(1, 8);

            //Re-generate the new tetromino until it is of a style that is not one of the upcoming styles.
            while (unusableStyles.Contains(style))
                style = (TetrominoStyle)rand.Next(1, 8);

            return style;
        }

        public Tetromino CreateFromStyle(TetrominoStyle style, Grid grid)
        {
            return style switch
            {
                TetrominoStyle.Block => new Block(grid),
                TetrominoStyle.Straight => new Straight(grid),
                TetrominoStyle.TShaped => new TShaped(grid),
                TetrominoStyle.LeftZigZag => new LeftZigZag(grid),
                TetrominoStyle.RightZigZag => new RightZigZag(grid),
                TetrominoStyle.LShaped => new LShaped(grid),
                TetrominoStyle.ReverseLShaped => new ReverseLShaped(grid),
                _ => new Block(grid),
            };
        }
    }
}
