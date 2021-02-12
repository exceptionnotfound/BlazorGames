using BlazorGames.Models.Tetris.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris
{
    public class Grid
    {
        public int Width { get; } = 10;
        public int Height { get; } = 20;
        public CoordinateCollection Coordinates { get; set; } = new CoordinateCollection();

        public GameState State { get; set; } = GameState.NotStarted;
    }
}
