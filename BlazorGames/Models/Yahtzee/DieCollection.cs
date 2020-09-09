using BlazorGames.Models.Yahtzee.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Yahtzee
{
	public class DieCollection
	{
		public List<Die> Dice { get; set; } = new List<Die>();

		private IList<DiceCount> _rollCounts;
		private int[] _sorted;

		public void Add(int value)
		{
			Dice.Add(new Die(value));
		}

		public void Roll()
		{
			Random rand = new Random();
			foreach(var die in Dice)
			{
				if(!die.IsHeld)
					die.Value = rand.Next(1, 7);
			}

			_rollCounts = Dice.GroupBy(x => x.Value)
				.Select(group => new DiceCount
				{
					Value = group.Key,
					Count = group.Count()
				})
				.OrderByDescending(x => x.Count).ToList();

			_sorted = Dice.Select(r => r.Value).ToArray();
			Array.Sort(_sorted);
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

			// Since the Has* methods are called by bindings before our first roll,
			// we need to ensure that _rollCount[0] is never null.
			// (we never look at any value after index 0, except when checking
			// for a full house, but then only when  _rollCount[0].Count ==3
			_rollCounts = new DiceCount[1] {new DiceCount{Count = 0, Value = 0}};

			_sorted = new[] {0, 0, 0, 0, 0};
			;
		}

		public int GetSumOf(int value)
		{
			return Dice.Where(x => x.Value == value).Sum(x => x.Value);
		}

		public bool HasThreeOnes() => HasThreeOfAKind(1);

		public bool HasThreeTwos() => HasThreeOfAKind(2);

		public bool HasThreeThrees() => HasThreeOfAKind(3);

		public bool HasThreeFours() => HasThreeOfAKind(4);

		public bool HasThreeFives() => HasThreeOfAKind(5);

		public bool HasThreeSixes() => HasThreeOfAKind(6);

		// If a roll has 3, 4, or 5 of a Kind, that value would have to be the most common
		// value, hence it must be in _rollCounts[0].
		public bool HasYahtzee() => _rollCounts[0].Count == 5;
		public bool HasThreeOfAKind() => _rollCounts[0].Count >= 3;
		public bool HasFourOfAKind() => _rollCounts[0].Count >= 4;
		public bool HasThreeOfAKind(int value) => _rollCounts[0].Count >= 3 && _rollCounts[0].Value == value;
		public bool HasFourOfAKind(int value) => _rollCounts[0].Count >= 4 && _rollCounts[0].Value == value;
  

		public int GetOfAKindTotal(int count) //Count will be 3 or 4
			=>
				_rollCounts[0].Count>=count ? _rollCounts[0].Count * _rollCounts[0].Value : 0;

		public bool HasSmallStraight()
		{
			// Straight impossible with 3 of a kind.
			if (_rollCounts[0].Count>2)
				return false;

			// possible small straights w/5 distinct dice.
			// A) 1,2,3,4,5  (also large straight)
			// B) 1,2,3,4,6
			// C) 1,3,4,5,6
			// D) 2,3,4,5,6 (also large straight)
			if (_rollCounts[0].Count == 1)
			{
				if (_sorted[0] == 1 && _sorted[3] == 4)		// Handles A & B
					return true;
				if (_sorted[1] == 3 && _sorted[4] == 6)		// Handles C & D
					return true;

				return false;
			}

			// possible small straights w/two similar dice
			// E) 1,1,2,3,4
			// F) 1,2,2,3,4
			// G) 1,2,3,3,4
			// H) 1,2,3,4,4

			// I) 2,2,3,4,5
			// J) 2,3,3,4,5
			// K) 2,3,4,4,5
			// L) 2,3,4,5,5

			// M) 3,3,4,5,6
			// N) 3,4,4,5,6
			// O) 3,4,5,5,6
			// P) 3,4,5,6,6

			// _rollCounts[0].Count == 2
			if (_sorted[0] == 1 && _sorted[4] == 4)		// Handle E thru H
				return true;

			if (_sorted[0] == 2 && _sorted[4] == 5)		// Handles I thru L
				return true;

			if (_sorted[0] == 3 && _sorted[4] == 6)		// Handles M thru P
				return true;

			return false;
		}

		public bool HasLargeStraight()
		{
			if (_rollCounts[0].Count>1)
				return false;

			if (_sorted[0] == 1 && _sorted[4] == 5)
				return true;

			if (_sorted[0] == 2 && _sorted[4] == 6)
				return true;

			return false;
		}

		public bool HasFullHouse() => _rollCounts[0].Count == 3 && _rollCounts[1].Count == 2;
	}

	/// <summary>
	/// DiceCount - hold the die value + the number of times it appears in the roll.
	/// (This needs to be a named type since we'll be storing the value.
	/// </summary>
	struct  DiceCount
	{
		public int Value;
		public int Count;
	}

}
