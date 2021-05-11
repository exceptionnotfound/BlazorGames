using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack
{
    public class Dealer : Person
    {
        public CardDeck Deck { get; set; } = new CardDeck();

        public Card Deal()
        {
            return Deck.Draw();
        }

        public bool HasAceShowing => Cards.Count == 2 && VisibleScore == 11 && Cards.Any(x => x.IsVisible == false);

        public void Reveal()
        {
            Cards.ForEach(x => x.IsVisible = true);
        }

        public async Task DealToSelf()
        {
            await AddCard(Deal());
        }

        public async Task DealToPlayer(Player player)
        {
            await player.AddCard(Deal());
        }
    }
}
