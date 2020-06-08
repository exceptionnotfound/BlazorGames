using BlazorGames.Models.Yahtzee.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Yahtzee
{
    public class PlayCollection
    {
        public List<Play> Plays { get; set; } = new List<Play>();

        public bool HasPlay(PlayType type)
        {
            return Plays.Select(x => x.Type).Contains(type);
        }

        public void Add(PlayType type, int value)
        {
            Plays.Add(new Play(type, value));
        }

        public int GetScore(PlayType type)
        {
            var matchingPlay = Plays.FirstOrDefault(x => x.Type == type);
            if(matchingPlay != null)
            {
                return matchingPlay.PointValue;
            }

            return 0;
        }

        public int GetTotal()
        {
            return Plays.Sum(x => x.PointValue);
        }

        public void Reset()
        {
            Plays.Clear();
        }
    }
}
