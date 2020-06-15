using BlazorGames.Models.Yahtzee.Enums;
using BlazorGames.Models.Yahtzee.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

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
