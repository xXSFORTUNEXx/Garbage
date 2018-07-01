using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Garbage.Classes
{
    public class Dice
    {
        public int Id;
        public int Value;
        public bool Saved;
        public Image image;

        public Dice(int id)
        {
            Id = id;
            Value = (int)Outcome.One;
            Saved = false;
            image = Image.FromFile("Images/" + (Id + 1) + ".png");
        }
    }

    public enum Outcome : int
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six
    }
}
