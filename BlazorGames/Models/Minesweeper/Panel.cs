using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Minesweeper
{
    public class Panel
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsMine { get; set; }
        public int AdjacentMines { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }

        public Panel(int id, int x, int y)
        {
            ID = id;
            X = x;
            Y = y;
        }

        public void Flag()
        {
            if(!IsRevealed)
            {
                IsFlagged = !IsFlagged;
            }
        }

        public void Reveal()
        {
            IsRevealed = true;
            IsFlagged = false; //Revealed panels cannot be flagged
        }
    }
}
