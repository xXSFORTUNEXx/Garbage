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
        public int Current_Turn_Score;
        public int[] Turn_Scores = new int[10];
        public int Adds;
        public int Chances;
        public int Turn;
        public bool Hot_Dice;
        public bool Can_Claim;
        public bool Taking_Chance;
        public bool Using_Add;

        public Player(string name)
        {
            Name = name;
            Total_Score = 0;
            Current_Turn_Score = 0;
            Turn = 1;
            Adds = 2;
            Chances = 0;
            Hot_Dice = false;
            Can_Claim = false;
            Taking_Chance = false;
            Using_Add = false;
        }
    }
}
