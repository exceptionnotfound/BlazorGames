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

        public decimal Bet { get; set; }

        public decimal InsuranceBet { get; set; }

        public decimal Change { get; set; }

        public bool HasStood { get; set; }

        public bool HasInsurance => InsuranceBet > 0M;

        public void Collect()
        {
            Funds += Change;
            Change = 0M;
            InsuranceBet = 0M;
        }
    }
}
