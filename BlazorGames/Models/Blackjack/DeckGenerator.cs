using BlazorGames.Models.Blackjack.Enums;
using BlazorGames.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack
{
    public static class DeckGenerator
    {
        public static CardDeck Generate()
        {
            CardDeck deck = new CardDeck();

            foreach (CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in (CardValue[])Enum.GetValues(typeof(CardValue)))
                {
                    Card newCard = new Card()
                    {
                        Suit = suit,
                        Value = value,
                        CssClass = "card" + suit.GetDisplayName() + value.GetDisplayName()
                    };

                    deck.Add(newCard);
                }
            }

            return deck;
        }
    }
}
