using BlazorGames.Models.Yahtzee.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Yahtzee
{
    public class Die
    {
        public int Value { get; set; } = 1;

        public bool IsHeld { get; set; }

        public DieState State { get; set; } = DieState.Stopped;

        public Die(int value)
        {
            Value = value;
        }

        public void Hold()
        {
            IsHeld = !IsHeld;
        }

        public string GetClassName()
        {
            return Value switch
            {
                1 => "one",
                2 => "two",
                3 => "three",
                4 => "four",
                5 => "five",
                6 => "six",
                _ => "one",
            };
        }
    }
}
