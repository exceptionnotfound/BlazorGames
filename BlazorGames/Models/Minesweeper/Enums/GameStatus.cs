using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Minesweeper.Enums
{
    public enum GameStatus
    {
        AwaitingFirstMove,
        InProgress,
        Failed,
        Completed
    }
}
