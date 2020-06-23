using BlazorGames.Models.Common;

namespace BlazorGames.Models.Yahtzee.Enums
{
    public enum PlayType
    {
        [Name("Three 1s", "Roll at least three 1s, score the total of the 1s.")]
        Ones,

        [Name("Three 2s", "Roll at least three 2s, score the total of the 2s.")]
        Twos,

        [Name("Three 3s", "Roll at least three 3s, score the total of the 3s.")]
        Threes,

        [Name("Three 4s", "Roll at least three 4s, score the total of the 4s.")]
        Fours,

        [Name("Three 5s", "Roll at least three 1s, score the total of the 5s.")]
        Fives,

        [Name("Three 6s", "Roll at least three 1s, score the total of the 6s.")]
        Sixes,

        [Name("Yahtzee!", "Roll all five dice as the same number, score 50.")]
        Yahtzee,

        [Name("Three of a Kind", "Roll at least 3 of the same number, score the total of that number.")]
        ThreeOfAKind,

        [Name("Four of a Kind", "Roll at least 4 of the same number, score the total of that number.")]
        FourOfAKind,

        [Name("Small Straight", "Roll four dice in sequential order (e.g. 2-3-4-5), score 30.")]
        SmallStraight,

        [Name("Large Straight", "Roll five dice in sequential order (e.g. 2-3-4-5-6), score 40.")]
        LargeStraight,

        [Name("Full House", "Roll three of one number and two of another (e.g. 5-5-5-2-2), score 25.")]
        FullHouse,

        [Name("Chance", "Score tbe total of all five dice.")]
        Chance,

        [Name("Bonus Yahtzee!", "Worth 100 points! Only available if you already have a Yahtzee!")]
        BonusYahtzee
    }
}
