using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Yahtzee.Enums
{
    public enum PlayType
    {
        [Description("Three 1s")]
        Ones,

        [Description("Three 2s")]
        Twos,

        [Description("Three 3s")]
        Threes,

        [Description("Three 4s")]
        Fours,

        [Description("Three 5s")]
        Fives,

        [Description("Three 6s")]
        Sixes,

        [Description("Yahtzee!")]
        Yahtzee,

        [Description("Three of a Kind")]
        ThreeOfAKind,

        [Description("Four of a Kind")]
        FourOfAKind,

        [Description("Small Straight")]
        SmallStraight,

        [Description("Large Straight")]
        LargeStraight,

        [Description("Full House")]
        FullHouse,

        [Description("Chance")]
        Chance,

        [Description("Bonus Yahtzee!")]
        BonusYahtzee
    }
}
