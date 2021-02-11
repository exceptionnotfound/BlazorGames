using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris
{
    public enum GameState
    {
        NotStarted,
        Playing,
        Dropping,
        ClearingRows,
        GameOver
    }
}
