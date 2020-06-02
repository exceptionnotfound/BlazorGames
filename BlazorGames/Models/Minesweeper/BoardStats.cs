using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Minesweeper
{
    public class BoardStats
    {
        public double TotalPanels { get; set; }
        public double PanelsRevealed { get; set; }
        public double Mines { get; set; }
        public double FlaggedMinePanels { get; set; }
        public double PercentMinesFlagged { get; set; }
        public double PercentPanelsRevealed { get; set; }
    }
}
