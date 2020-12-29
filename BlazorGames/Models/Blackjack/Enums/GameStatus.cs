using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack.Enums
{
    public enum GameStatus
    {
        NotStarted, //Before first hand
        Betting, //During the betting phase
        Dealing, //Only while dealer is dealing first hand
        InProgress, //After first hand is dealt, but before bets are paid out or collected.
        Insurance, //During an insurance bet
        HandOver, //After the hand is over, during while bets are paid out or collected.
        Shuffling, //While the dealer is shuffling the cards
        EscortedOut //Win condition; player won too much money so the casino is kicking them out.
    }
}
