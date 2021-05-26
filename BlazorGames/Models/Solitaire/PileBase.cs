using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Solitaire
{
    public class PileBase
    {
        protected List<Card> Cards { get; set; } = new List<Card>();

        public void Add(Card card)
        {
            if(card != null)
                Cards.Add(card);
        }

        public bool Any()
        {
            return Cards.Any();
        }

        public Card Pop()
        {
            var lastCard = Cards.LastOrDefault();
            if(lastCard != null)
            {
                Cards.Remove(lastCard);
            }

            return lastCard;
        }

        public Card Last()
        {
            return Cards.LastOrDefault();
        }

        public void RemoveIfExists(Card card)
        {
            var matchingCard = Cards.FirstOrDefault(x => x.Suit == card.Suit && x.Value == card.Value);
            if(matchingCard != null)
                Cards.Remove(matchingCard);
        }

        public bool Contains(Card card)
        {
            return Cards.Any(x => x.Suit == card.Suit && x.Value == card.Value);
        }
    }
}
