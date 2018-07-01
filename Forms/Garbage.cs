using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Garbage.Classes;

namespace Garbage
{
    public partial class Garbage : Form
    {
        private Player player;
        private Dice[] dice = new Dice[6];
        private PictureBox[] picGameDice = new PictureBox[6];
        private CheckBox[] combinations = new CheckBox[21];
        const int Total_Dice = 6;
        const int Total_Combos = 21;

        public Garbage()
        {
            InitializeComponent();
            CreateCombinations();
            CreateDice();
            for (int i = 0; i < Total_Dice; i++)
            {
                dice[i] = new Dice(i);
                picGameDice[i].Image = dice[i].image;
            }
        }

        private void CreateDice()
        {
            picGameDice[0] = new PictureBox();
            picGameDice[0].Location = new Point(12, 43);
            picGameDice[0].Size = new Size(100, 100);           
            picGameDice[1] = new PictureBox();
            picGameDice[1].Location = new Point(118, 43);
            picGameDice[1].Size = new Size(100, 100);
            picGameDice[2] = new PictureBox();
            picGameDice[2].Location = new Point(224, 43);
            picGameDice[2].Size = new Size(100, 100);
            picGameDice[3] = new PictureBox();
            picGameDice[3].Location = new Point(12, 149);
            picGameDice[3].Size = new Size(100, 100);
            picGameDice[4] = new PictureBox();
            picGameDice[4].Location = new Point(118, 149);
            picGameDice[4].Size = new Size(100, 100);
            picGameDice[5] = new PictureBox();
            picGameDice[5].Location = new Point(224, 149);
            picGameDice[5].Size = new Size(100, 100);

            Controls.Add(picGameDice[0]);
            Controls.Add(picGameDice[1]);
            Controls.Add(picGameDice[2]);
            Controls.Add(picGameDice[3]);
            Controls.Add(picGameDice[4]);
            Controls.Add(picGameDice[5]);
        }
        
        private void CreateCombinations()
        {
            for (int i = 0; i < Total_Combos; i++)
            {
                combinations[i] = new CheckBox();
                combinations[i].Location = new Point(12, ((i + 1) * 22));
                combinations[i].Size = new Size(290, 20);
                grpCombinations.Controls.Add(combinations[i]);
            }

            combinations[0].Text = "One - 100 Points";
            combinations[1].Text = "Five - 50 Points";
            combinations[2].Text = "3 x Ones - 1000 Points";
            combinations[3].Text = "3 x Twos - 200 Points";
            combinations[4].Text = "3 x Threes - 300 Points";
            combinations[5].Text = "3 x Fours - 400 Points";
            combinations[6].Text = "3 x Fives - 500 Points";
            combinations[7].Text = "3 x Sixes - 600 Points";
            combinations[8].Text = "1 Pair Any Number - 50 Points";
            combinations[9].Text = "2 Pairs of Any 2 Numbers - 500 Points";
            combinations[10].Text = "Straight One-Two-Three - 250 Points";
            combinations[11].Text = "Straight One-Two-Three-Four - 500 Points";
            combinations[12].Text = "Straight One-Two-Three-Four-Five - 1000 Points";
            combinations[13].Text = "Straight One-Two-Three-Four-Five-Six - 3000 Points";
            combinations[14].Text = "4 Set Any Number - 1000 Points";
            combinations[15].Text = "5 Set Any Number - 2000 Points";
            combinations[16].Text = "6 Set Any Number - 3000 Points";
            combinations[17].Text = "Full House Set Of 3 and 2 Pair - 1000 Points";
            combinations[18].Text = "4 Set Any Number And 2 Pair Any Number - 3000 Points";
            combinations[19].Text = "3 Set and 3 Set Any Number - 2000 Points";
            combinations[20].Text = "3 Pairs of 2 Any Number - 2000 Points";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you wish to exit?", "Exit", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes) { Application.Exit(); }            
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rules rules = new Rules();
            rules.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Please enter your name: ", "Enter Name", "John Doe");
            player = new Player(name);
            lblName.Text = "Name: " + name;
            lblAdds.Text = "Adds: " + player.Adds;
            btnRoll.Enabled = true;
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            var random = new Random();

            for (int i = 0; i < Total_Dice; i++)
            {
                if (!dice[i].Saved)
                {
                    dice[i].Value = random.Next(1, 6);
                    dice[i].image = Image.FromFile("Images/" + dice[i].Value + ".png");
                    picGameDice[i].Image = dice[i].image;
                }
            }

            btnRoll.Enabled = false;
            btnClaim.Enabled = true;
            grpCombinations.Enabled = true;
            btnEndTurn.Enabled = false;
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            bool anything = false;
            for (int i = 0; i < Total_Combos; i++)
            {
                if (combinations[i].Checked)
                {
                    anything = true;
                    break;
                }
            }

            if (!anything) { MessageBox.Show("Please claim a combination or end your turn.", "Limbo", MessageBoxButtons.OK); return; }

            CheckCombinations();
        }

        private void CheckCombinations()
        {
            player.canClaim = false;
            //Check for just a singular 1
            if (combinations[0].Checked)
            {
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == (int)Outcome.One)
                        {
                            dice[i].Saved = true;
                            player.canClaim = true;
                            player.Turn_Score += 100;
                            lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                            break;
                        }
                    }
                }
            }
            //Check for a 5
            if (combinations[1].Checked)
            {
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == (int)Outcome.Five)
                        {
                            dice[i].Saved = true;
                            player.canClaim = true;
                            player.Turn_Score += 50;
                            lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                            break;
                        }
                    }
                }
            }

            //Can we claim something? If not then we need to or claim a 0, or chance it...
            if (player.canClaim)
            {
                for (int i = 0; i < Total_Combos; i++)
                {
                    combinations[i].Checked = false;
                    grpCombinations.Enabled = false;
                }
                btnRoll.Enabled = true;
                btnClaim.Enabled = false;
                btnEndTurn.Enabled = true;
            }
            else
            {
                DialogResult answer = MessageBox.Show("You havent selected any combinations. Do you want to end your turn and claim 0?", "Invalid Selection", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    player.Turn_Score = 0;
                    EndTurn();
                }
                return;
            }
        }

        private void EndTurn()
        {
            for (int i = 0; i < Total_Dice; i++)
            {
                dice[i].Saved = false;
            }

            for (int i = 0; i < Total_Combos; i++)
            {
                combinations[i].Checked = false;
                grpCombinations.Enabled = false;
            }

            player.Total_Score += player.Turn_Score;
            player.Turn_Score = 0;
            lblTotalScore.Text = "Total Score: " + player.Total_Score;
            lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
            player.hotDice = false;
            btnRoll.Enabled = true;
            btnClaim.Enabled = false;
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            EndTurn();
        }
    }
}
