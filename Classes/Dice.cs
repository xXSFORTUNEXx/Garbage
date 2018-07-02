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
            Value = 1;
            Saved = false;
            image = Image.FromFile("Images/" + (Id + 1) + "u.png");
        }
    }
}
