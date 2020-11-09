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
			if (HasThreeOfAKind())
				return false;

			// Large straight is also a small sraight
			if (HasLargeStraight())
				return true;

			// small straight must start with a 1, 2 or a 3 and have four unique die
			if (_sorted[0] > 3 || _sorted[1] > 3 || _rollCounts.Count < 4)
				return false;

			var consecutive = 1;
			for (var i = 1; i < _sorted.Length; i++)
			{
				if (_sorted[i] - 1 == _sorted[i - 1])
					consecutive++;
				else if (_sorted[i] == _sorted[i - 1])
					continue;
				else
					consecutive = 1;

				// small straight must have four consecutive die
				if (consecutive == 4)
					return true;
			}

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
