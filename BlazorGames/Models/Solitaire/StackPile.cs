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
            var lastCard = Cards.Last();

            int draggedCardValue = (int)card.Value;
            int stackedCardValue = (int)lastCard.Value;

            bool isOneLess = draggedCardValue == stackedCardValue - 1;

            bool isOppositeColor = (card.Suit == CardSuit.Spades || card.Suit == CardSuit.Clubs)
                                    ? lastCard.Suit == CardSuit.Hearts || lastCard.Suit == CardSuit.Diamonds
                                    : lastCard.Suit == CardSuit.Spades || lastCard.Suit == CardSuit.Clubs;

            return isOneLess && isOppositeColor;
        }

        public bool HasNoHiddenCards()
        {
            return !Cards.Any() || Cards.All(x => x.IsVisible);
        }
    }
}
