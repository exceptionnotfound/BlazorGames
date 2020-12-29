using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack.Enums
{
    public enum GameStatus
    {
        NotStarted,
        Betting,
        Dealing,
        InProgress,
        Insurance,
        HandOver,
        Shuffling,
        EscortedOut
    }
}
