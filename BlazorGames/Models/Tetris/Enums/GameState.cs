using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris.Enums
{
    /// <summary>
    /// Represents the current state of the Tetris game
    /// </summary>
    public enum GameState
    {
        NotStarted, 
        Playing, //Game playing normally
        GameOver
    }
}
