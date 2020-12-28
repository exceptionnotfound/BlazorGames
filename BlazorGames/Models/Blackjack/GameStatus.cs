using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack
{
    public enum GameStatus
    {
        NotStarted,
        Betting,
        Dealing,
        InProgress,
        HandOver,
        Shuffling
    }
}
