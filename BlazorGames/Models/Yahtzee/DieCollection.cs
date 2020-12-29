using BlazorGames.Models.Yahtzee.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorGames.Models.Yahtzee
{
    public class DieCollection
    {
        public List<Die> Dice { get; set; } = new List<Die>();



        public void Add(int value)
        {
            Dice.Add(new Die(value));
        }

        public void ReleaseHold()
        {
            Dice.ForEach(x => x.IsHeld = false);
        }

        public void Reset()
        {
            Dice.Clear();
            Add(1);
            Add(2);
            Add(3);
            Add(4);
            Add(5);
        }

        public int GetSumOf(int value)
        {
            return Dice.Where(x => x.Value == value).Sum(x => x.Value);
        }

        public bool HasThreeOnes()
        {
            return HasThreeOfAKind(1);
        }

        public bool HasThreeTwos()
        {
            return HasThreeOfAKind(2);
        }

        public bool HasThreeThrees()
        {
            return HasThreeOfAKind(3);
        }

        public bool HasThreeFours()
        {
            return HasThreeOfAKind(4);
        }

        public bool HasThreeFives()
        {
            return HasThreeOfAKind(5);
        }

        public bool HasThreeSixes()
        {
            return HasThreeOfAKind(6);
        }

        public bool HasYahtzee()
        {
            var value = Dice.First().Value;

            return Dice.All(x => x.Value == value);
        }

        public bool HasThreeOfAKind()
        {
            return HasThreeOnes()
                || HasThreeTwos()
                || HasThreeThrees()
                || HasThreeFours()
                || HasThreeFives()
                || HasThreeSixes();
        }

        public bool HasFourOfAKind()
        {
            return HasFourOfAKind(1)
                || HasFourOfAKind(2)
                || HasFourOfAKind(3)
                || HasFourOfAKind(4)
                || HasFourOfAKind(5)
                || HasFourOfAKind(6);
        }

        public bool HasThreeOfAKind(int value)
        {
            return Dice.Where(x => x.Value == value).Count() >= 3;
        }

        public bool HasFourOfAKind(int value)
        {
            return Dice.Where(x => x.Value == value).Count() >= 4;
        }

        public int GetOfAKindTotal(int count) //Count will be 3 or 4
        {
            var groups = Dice.GroupBy(x => x.Value)
                             .Select(group => new
                             {
                                 Value = group.Key,
                                 Count = group.Count()
                             })
                             .OrderByDescending(x => x.Count);

            var mostCommonValue = groups.First().Value;

            if (Dice.Where(x => x.Value == mostCommonValue).Count() >= count)
            {
                return Dice.Where(x => x.Value == mostCommonValue).Sum(x => x.Value);
            }
            else return 0;
        }

        public bool HasSmallStraight()
        {
            var hasOne = Dice.Exists(x => x.Value == 1);
            var hasTwo = Dice.Exists(x => x.Value == 2);
            var hasThree = Dice.Exists(x => x.Value == 3);
            var hasFour = Dice.Exists(x => x.Value == 4);
            var hasFive = Dice.Exists(x => x.Value == 5);
            var hasSix = Dice.Exists(x => x.Value == 6);

            //There are more concise ways to do this
            if (hasOne && hasTwo && hasThree && hasFour) return true;
            if (hasTwo && hasThree && hasFour && hasFive) return true;
            if (hasThree && hasFour && hasFive && hasSix) return true;

            return false;
        }

        public bool HasLargeStraight()
        {
            var hasOne = Dice.Exists(x => x.Value == 1);
            var hasTwo = Dice.Exists(x => x.Value == 2);
            var hasThree = Dice.Exists(x => x.Value == 3);
            var hasFour = Dice.Exists(x => x.Value == 4);
            var hasFive = Dice.Exists(x => x.Value == 5);
            var hasSix = Dice.Exists(x => x.Value == 6);

            if (hasOne && hasTwo && hasThree && hasFour && hasFive) return true;
            if (hasTwo && hasThree && hasFour && hasFive && hasSix) return true;

            return false;
        }

        public bool HasFullHouse()
        {
            //By definition, only two values of dice can be shown for a full house.

            var values = Dice.GroupBy(x => x.Value)
                                .Select(group => new
                                {
                                    Value = group.Key,
                                    Count = group.Count()
                                })
                                .OrderByDescending(x => x.Count);

            if (values.Count() != 2) return false;

            if (values.ElementAt(0).Count == 3
                && values.ElementAt(1).Count == 2)
                return true;

            return false;
        }
    }

}
