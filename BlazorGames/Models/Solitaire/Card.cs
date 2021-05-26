using BlazorGames.Models.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Solitaire
{
public class Card
{
    public CardSuit Suit { get; set; }
    public CardValue Value { get; set; }
    public string ImageName { get; set; }
    public bool IsVisible { get; set; }

    public bool IsRed 
    { 
        get {
            return Suit == CardSuit.Diamonds || Suit == CardSuit.Hearts;
        } 
    }

    public bool IsBlack
    {
        get
        {
            return !IsRed;
        }
    }
}
}
