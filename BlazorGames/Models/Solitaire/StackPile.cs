using BlazorGames.Models.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Solitaire
{
    public class StackPile : PileBase
    {
        public bool CanStack(Card card)
        {
            var lastCard = Last();

            int draggedCardValue = (int)card.Value;
            int stackedCardValue = (int)lastCard.Value;

            bool isOneLess = draggedCardValue == stackedCardValue - 1;

            bool isOppositeColor = (card.Suit == CardSuit.Spades || card.Suit == CardSuit.Clubs)
                                    ? lastCard.Suit == CardSuit.Hearts || lastCard.Suit == CardSuit.Diamonds
                                    : lastCard.Suit == CardSuit.Spades || lastCard.Suit == CardSuit.Clubs;

            return isOneLess && isOppositeColor;
        }

        public int IndexOf(Card card)
        {
            var matchingCard = Cards.FirstOrDefault(x => x.Suit == card.Suit && x.Value == card.Value);
            if (matchingCard != null)
                return Cards.IndexOf(matchingCard);

            return 0;
        }

        public bool HasNoHiddenCards()
        {
            return !Any() || AllAreVisible();
        }

        public bool AllAreVisible()
        {
            return Cards.All(x => x.IsVisible);
        }

        public int Count()
        {
            return Cards.Count();
        }

        public List<Card> GetAllCards()
        {
            return Cards;
        }
    }
}
