using BlazorGames.Models.Yahtzee.Enums;

namespace BlazorGames.Models.Yahtzee
{
    public class Play
    {
        public int PointValue { get; set; }
        public PlayType Type { get; set; }

        public Play(PlayType type, int points)
        { 
            Type = type;
            PointValue = points;
        }
    }
}
