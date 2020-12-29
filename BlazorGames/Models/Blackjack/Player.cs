using BlazorGames.Models.Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Blackjack
{
    public class Player : Person
    {
        public decimal Funds { get; set; } = 200M;
    }
}
