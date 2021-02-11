using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris
{
    public class Board
    {
        public int Width { get; set; } = 10;
        public int Height { get; set; } = 20;
        public CoordinateCollection Coordinates { get; set; } = new CoordinateCollection();

        public GameState State { get; set; } = GameState.NotStarted;
    }
}
