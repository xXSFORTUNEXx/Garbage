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
        public bool Claimed;
        public Image Dice_Image;

        public Dice(int id)
        {
            Id = id;
            Value = 1;
            Claimed = false;
            Dice_Image = Image.FromFile("Images/" + (Id + 1) + "u.png");
        }
    }
}
