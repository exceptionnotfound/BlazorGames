using BlazorGames.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.GameOfLife.Enums
{
    public enum Theme
    {
        [Name("faces", "Smiley faces and skulls")]
        Faces,

        [Name("cats", "Cats and mice")]
        Cats,

        [Name("aliens", "Aliens and astronauts")]
        Aliens,

        [Name("boxes", "Simple boxes")]
        Boxes
    }
}
