using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack.Enums
{
    public enum GameState
    {
        NotStarted, //Before first hand
        Betting, //During the betting phase
        Dealing, //Only while dealer is dealing the initial deal
        InProgress, //After the initial deal, but before bets are paid out or collected.
        Insurance, //During an insurance bet
        Payout, //After the hand is over, during while bets are paid out or collected.
        Shuffling, //While the dealer is shuffling the cards
        EscortedOut //Win condition; player won too much money so the casino is kicking them out.
    }
}
