using BlazorGames.Models.ConnectFour.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.ConnectFour
{
    public class GameBoard
    {
        public GamePiece[,] Board { get; set; }


        public GameBoard()
        {
            Board = new GamePiece[7, 6];

            //Populate the Board with blank pieces
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    Board[i, j] = new GamePiece(PieceColor.Blank);
                }
            }
        }
    }
}
