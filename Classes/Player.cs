using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Classes
{
    public class Player
    {
        public string Name;
        public int Total_Score;
        public int Turn_Score;
        public int Adds;
        public int Chances;
        public bool hotDice;
        public bool canClaim;

        public Player(string name)
        {
            Name = name;
            Total_Score = 0;
            Turn_Score = 0;
            Adds = 2;
            Chances = 0;
            hotDice = false;
            canClaim = false;
        }
    }
}
