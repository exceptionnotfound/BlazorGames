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
        public CellCollection Cells { get; set; } = new CellCollection();

        public GameState State { get; set; } = GameState.NotStarted;

        public bool IsStarted
        {
            get
            {
                return State == GameState.Playing 
                       || State == GameState.GameOver;
            }
        }
    }
}
