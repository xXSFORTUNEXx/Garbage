using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Garbage.Classes;

namespace Garbage
{
    public partial class Highscores : Form
    {
        public Highscores()
        {
            InitializeComponent();
            string scores = "1. " + Highscore.Name[0] + " - " + Highscore.Score[0];
            scores += "\n\n2. " + Highscore.Name[1] + " - " + Highscore.Score[1];
            scores += "\n\n3. " + Highscore.Name[2] + " - " + Highscore.Score[2];
            scores += "\n\n4. " + Highscore.Name[3] + " - " + Highscore.Score[3];
            scores += "\n\n5. " + Highscore.Name[4] + " - " + Highscore.Score[4];
            lblHighscores.Text = scores;
        }
    }
}
