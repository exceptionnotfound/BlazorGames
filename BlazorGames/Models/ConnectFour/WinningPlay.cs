using BlazorGames.Models.ConnectFour.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.ConnectFour
{
    public class WinningPlay
    {
        public List<string> WinningMoves { get; set; }
        public EvaluationDirection WinningDirection { get; set; }
        public PieceColor WinningColor { get; set; }
    }
}
