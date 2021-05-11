using BlazorGames.Models.Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack
{
    public class Person
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public string ScoreDisplay
        {
            get
            {
                if (HasNaturalBlackjack && Cards.All(x => x.IsVisible))
                    return "Blackjack!";

                //We use Visible Score because this display
                //should only show the Dealer's visible score,
                //and the Player's visible score and true score
                //will always be the same value.
                var score = VisibleScore;

                if (score > 21)
                    return "Busted!";
                else return score.ToString();
            }
        }

        public async Task AddCard(Card card)
        {
            Cards.Add(card);
            await Task.Delay(300);
        }

        public int Score
        {
            get
            {
                return ScoreCalculation();
            }
        }

        public int VisibleScore
        {
            get
            {
                return ScoreCalculation(true);
            }
        }

        private int ScoreCalculation(bool onlyVisible = false)
        {
            var cards = Cards;

            if (onlyVisible)
            {
                cards = Cards.Where(x => x.IsVisible).ToList();
            }

            //If the sum total of all cards is <= 21, return that value
            var totalScore = cards.Sum(x => x.Score);
            if (totalScore <= 21) return totalScore;

            //If there are no Aces and the sum total is > 21, we are busted
            bool hasAces = cards.Any(x => x.Value == CardValue.Ace);
            if (!hasAces && totalScore > 21) return totalScore;

            //By this point, the sum will be greater than 21 if all Aces are worth 11
            //So, make each Ace worth 1, until the sum is <= 21
            //There can only ever be four aces in one hand
            var acesCount = cards.Where(x => x.Value == CardValue.Ace).Count();
            var acesScore = cards.Sum(x => x.Score);

            while (acesCount > 0)
            {
                acesCount -= 1;
                acesScore -= 10;

                if (acesScore <= 21) return acesScore;
            }

            //If the score never gets returned, we are busted
            return cards.Sum(x => x.Score);
        }

        public bool IsBusted => Score > 21;

        public void ClearHand()
        {
            Cards.Clear();
        }

        public bool HasNaturalBlackjack =>
            Cards.Count == 2
            && Score == 21
            && Cards.Any(x => x.Value == CardValue.Ace)
            && Cards.Any(x => x.IsTenCard);
        }
}
