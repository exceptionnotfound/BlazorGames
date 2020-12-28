using BlazorGames.Models.Blackjack.Enums;
using BlazorGames.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack
{
    public class CardDeck
    {
        protected Stack<Card> Cards { get; set; } = new Stack<Card>();

        public CardDeck()
        {
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

                    Cards.Push(newCard);
                }
            }

            Shuffle();
        }

        public void Add(Card card)
        {
            Cards.Push(card);
        }

        public Card Draw()
        {
            return Cards.Pop();
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            Cards = new Stack<Card>(Cards.OrderBy(x => rnd.Next()));
        }
    }
}
