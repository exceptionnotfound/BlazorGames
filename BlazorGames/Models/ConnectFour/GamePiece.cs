using BlazorGames.Models.ConnectFour.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.ConnectFour
{
    public class GamePiece
    {
        public PieceColor Color;

        public GamePiece()
        {
            Color = PieceColor.Blank;
        }

        public GamePiece(PieceColor color)
        {
            Color = color;
        }
    }
}
