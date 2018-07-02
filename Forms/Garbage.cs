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

            combinations[0].Text = "Five - 50 Points";
            combinations[1].Text = "1 Pair Any Number - 50 Points";
            combinations[2].Text = "One - 100 Points";
            combinations[3].Text = "3 x Twos - 200 Points";
            combinations[4].Text = "Straight One-Two-Three - 250 Points";
            combinations[5].Text = "3 x Threes - 300 Points";
            combinations[6].Text = "3 x Fours - 400 Points";
            combinations[7].Text = "3 x Fives - 500 Points";
            combinations[8].Text = "2 Pairs of Any 2 Numbers - 500 Points";
            combinations[9].Text = "Straight One-Two-Three-Four - 500 Points";
            combinations[10].Text = "3 x Sixes - 600 Points";
            combinations[11].Text = "3 x Ones - 1000 Points";
            combinations[12].Text = "4 Set Any Number - 1000 Points";
            combinations[13].Text = "Full House Set Of 3 and 2 Pair - 1000 Points";
            combinations[14].Text = "Straight One-Two-Three-Four-Five - 1000 Points";
            combinations[15].Text = "5 Set Any Number - 2000 Points";
            combinations[16].Text = "3 Set and 3 Set Any Number - 2000 Points";
            combinations[17].Text = "3 Pairs of 2 Any Number - 2000 Points";
            combinations[18].Text = "Straight One-Two-Three-Four-Five-Six - 3000 Points";
            combinations[19].Text = "6 Set Any Number - 3000 Points";
            combinations[20].Text = "4 Set Any Number And 2 Pair Any Number - 3000 Points";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitGame();
        }

        private void ExitGame()
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
            NewGame();
        }

        private void NewGame()
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
                    //dice[i].Value = 1;
                    dice[i].image = Image.FromFile("Images/" + dice[i].Value + "u.png");
                    picGameDice[i].Image = dice[i].image;
                }
            }

            //For testing
            /*for (int n = 2; n < Total_Dice; n++)
            {
                dice[n].Value = 2;
                dice[n].image = Image.FromFile("Images/" + dice[n].Value + "u.png");
                picGameDice[n].Image = dice[n].image;
            }*/

            btnRoll.Enabled = false;
            btnClaim.Enabled = true;
            grpCombinations.Enabled = true;
            btnEndTurn.Enabled = false;
            lblHotDice.Visible = false;
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

            if (!anything)
            {
                DialogResult answer = MessageBox.Show("You havent selected any combinations. Do you want to end your turn and claim 0? Press no to chance!", "Invalid Selection", MessageBoxButtons.YesNoCancel);
                if (answer == DialogResult.Yes)
                {
                    player.Turn_Score = 0;
                    lblTurnScore.Text = "Turn Score: 0";
                    lblProjectedScore.Text = "Projected Score: 0";
                    EndTurn();
                    return;
                }
                else if (answer == DialogResult.No)
                {
                    return;
                }
            }

            CheckCombinations();
        }

        private void CheckCombinations()
        {
            player.canClaim = false;
            //Five - 50 Points
            if (combinations[0].Checked)
            {
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 5)
                        {
                            dice[i].Saved = true;
                            dice[i].image = Image.FromFile("Images/5c.png");
                            picGameDice[i].Image = dice[i].image;
                            player.canClaim = true;
                            player.Turn_Score += 50;
                            lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                            break;
                        }
                    }
                }
            }
            //1 Pair Any Number - 50 Points
            if (combinations[1].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    if (dice[i].Value == dice[n].Value)
                                    {
                                        dice[i].Saved = true;
                                        dice[n].Saved = true;
                                        dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                                        dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                                        picGameDice[i].Image = dice[i].image;
                                        picGameDice[n].Image = dice[n].image;
                                        player.canClaim = true;
                                        player.Turn_Score += 50;
                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                        done = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //One - 100 Points
            if (combinations[2].Checked)
            {
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 1)
                        {
                            dice[i].Saved = true;
                            dice[i].image = Image.FromFile("Images/1c.png");
                            picGameDice[i].Image = dice[i].image;
                            player.canClaim = true;
                            player.Turn_Score += 100;
                            lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                            break;
                        }
                    }
                }
            }
            //3 x Twos - 200 Points
            if (combinations[3].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 2)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (dice[n].Id != dice[i].Id)
                                {
                                    if (!dice[n].Saved)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                            {
                                                if (!dice[m].Saved)
                                                {
                                                    if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value)
                                                    {
                                                        dice[i].Saved = true;
                                                        dice[n].Saved = true;
                                                        dice[m].Saved = true;
                                                        dice[i].image = Image.FromFile("Images/2c.png");
                                                        dice[n].image = Image.FromFile("Images/2c.png");
                                                        dice[m].image = Image.FromFile("Images/2c.png");
                                                        picGameDice[i].Image = dice[i].image;
                                                        picGameDice[n].Image = dice[n].image;
                                                        picGameDice[m].Image = dice[m].image;
                                                        player.canClaim = true;
                                                        player.Turn_Score += 200;
                                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                        done = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (done) { break; }
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //Straight One-Two-Three - 250 Points
            if (combinations[4].Checked)
            {
                bool one = false;
                bool two = false;
                bool three = false;
                int[] ids = { 6, 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!dice[n].Saved)
                    {
                        if (n != ids[0])
                        {
                            if (dice[n].Value == 2)
                            {
                                two = true;
                                ids[1] = n;
                                break;
                            }
                        }
                    }
                }

                for (int m = 0; m < Total_Dice; m++)
                {
                    if (!dice[m].Saved)
                    {
                        if (m != ids[1])
                        {
                            if (dice[m].Value == 3)
                            {
                                three = true;
                                ids[2] = m;
                                break;
                            }
                        }
                    }
                }

                if (one && two && three)
                {
                    int i = ids[0];
                    int n = ids[1];
                    int m = ids[2];
                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[i].image = Image.FromFile("Images/1c.png");
                    dice[n].image = Image.FromFile("Images/2c.png");
                    dice[m].image = Image.FromFile("Images/3c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    player.canClaim = true;
                    player.Turn_Score += 250;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //3 x Threes - 300 Points
            if (combinations[5].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 3)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (dice[n].Id != dice[i].Id)
                                {
                                    if (!dice[n].Saved)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                            {
                                                if (!dice[m].Saved)
                                                {
                                                    if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value)
                                                    {
                                                        dice[i].Saved = true;
                                                        dice[n].Saved = true;
                                                        dice[m].Saved = true;
                                                        dice[i].image = Image.FromFile("Images/3c.png");
                                                        dice[n].image = Image.FromFile("Images/3c.png");
                                                        dice[m].image = Image.FromFile("Images/3c.png");
                                                        picGameDice[i].Image = dice[i].image;
                                                        picGameDice[n].Image = dice[n].image;
                                                        picGameDice[m].Image = dice[m].image;
                                                        player.canClaim = true;
                                                        player.Turn_Score += 300;
                                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                        done = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (done) { break; }
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //3 x Fours - 400 Points
            if (combinations[6].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 4)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (dice[n].Id != dice[i].Id)
                                {
                                    if (!dice[n].Saved)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                            {
                                                if (!dice[m].Saved)
                                                {
                                                    if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value)
                                                    {
                                                        dice[i].Saved = true;
                                                        dice[n].Saved = true;
                                                        dice[m].Saved = true;
                                                        dice[i].image = Image.FromFile("Images/4c.png");
                                                        dice[n].image = Image.FromFile("Images/4c.png");
                                                        dice[m].image = Image.FromFile("Images/4c.png");
                                                        picGameDice[i].Image = dice[i].image;
                                                        picGameDice[n].Image = dice[n].image;
                                                        picGameDice[m].Image = dice[m].image;
                                                        player.canClaim = true;
                                                        player.Turn_Score += 400;
                                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                        done = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (done) { break; }
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //3 x Fives - 500 Points
            if (combinations[7].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 5)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (dice[n].Id != dice[i].Id)
                                {
                                    if (!dice[n].Saved)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                            {
                                                if (!dice[m].Saved)
                                                {
                                                    if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value)
                                                    {
                                                        dice[i].Saved = true;
                                                        dice[n].Saved = true;
                                                        dice[m].Saved = true;
                                                        dice[i].image = Image.FromFile("Images/5c.png");
                                                        dice[n].image = Image.FromFile("Images/5c.png");
                                                        dice[m].image = Image.FromFile("Images/5c.png");
                                                        picGameDice[i].Image = dice[i].image;
                                                        picGameDice[n].Image = dice[n].image;
                                                        picGameDice[m].Image = dice[m].image;
                                                        player.canClaim = true;
                                                        player.Turn_Score += 500;
                                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                        done = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (done) { break; }
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //2 Pairs of Any 2 Numbers - 500 Points
            if (combinations[8].Checked)
            {
                bool firstPair = false;
                bool secondPair = false;
                int[] firstIds = { 6, 6 };
                int[] secondIds = { 6, 6 };
                bool done = false;
                bool done2 = false;

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    if (dice[i].Value == dice[n].Value)
                                    {
                                        firstPair = true;
                                        firstIds[0] = i;
                                        firstIds[1] = n;
                                        done = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }

                for (int m = 0; m < Total_Dice; m++)
                {
                    if (dice[m].Id != firstIds[0] && dice[m].Id != firstIds[1])
                    {
                        if (!dice[m].Saved)
                        {
                            for (int o = 0; o < Total_Dice; o++)
                            {
                                if (dice[o].Id != dice[m].Id && dice[o].Id != firstIds[0] && dice[o].Id != firstIds[1])
                                {
                                    if (!dice[o].Saved)
                                    {
                                        if (dice[o].Value == dice[m].Value)
                                        {
                                            secondPair = true;
                                            secondIds[0] = m;
                                            secondIds[1] = o;
                                            done2 = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (done2) { break; }
                }

                if (firstPair && secondPair)
                {
                    int i = firstIds[0];
                    int n = firstIds[1];
                    int m = secondIds[0];
                    int o = secondIds[1];

                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                    dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                    dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                    dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;
                    player.canClaim = true;
                    player.Turn_Score += 500;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //Straight One-Two-Three-Four - 500 Points
            if (combinations[9].Checked)
            {
                bool one = false;
                bool two = false;
                bool three = false;
                bool four = false;
                int[] ids = { 6, 6, 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!dice[n].Saved)
                    {
                        if (n != ids[0])
                        {
                            if (dice[n].Value == 2)
                            {
                                two = true;
                                ids[1] = n;
                                break;
                            }
                        }
                    }
                }

                for (int m = 0; m < Total_Dice; m++)
                {
                    if (!dice[m].Saved)
                    {
                        if (m != ids[1])
                        {
                            if (dice[m].Value == 3)
                            {
                                three = true;
                                ids[2] = m;
                                break;
                            }
                        }
                    }
                }

                for (int o = 0; o < Total_Dice; o++)
                {
                    if (!dice[o].Saved)
                    {
                        if (o != ids[2])
                        {
                            if (dice[o].Value == 4)
                            {
                                four = true;
                                ids[3] = o;
                                break;
                            }
                        }
                    }
                }

                if (one && two && three && four)
                {
                    int i = ids[0];
                    int n = ids[1];
                    int m = ids[2];
                    int o = ids[3];
                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[i].image = Image.FromFile("Images/1c.png");
                    dice[n].image = Image.FromFile("Images/2c.png");
                    dice[m].image = Image.FromFile("Images/3c.png");
                    dice[o].image = Image.FromFile("Images/4c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;

                    player.canClaim = true;
                    player.Turn_Score += 500;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //3 x Sixes - 600 Points
            if (combinations[10].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 6)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (dice[n].Id != dice[i].Id)
                                {
                                    if (!dice[n].Saved)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                            {
                                                if (!dice[m].Saved)
                                                {
                                                    if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value)
                                                    {
                                                        dice[i].Saved = true;
                                                        dice[n].Saved = true;
                                                        dice[m].Saved = true;
                                                        dice[i].image = Image.FromFile("Images/6c.png");
                                                        dice[n].image = Image.FromFile("Images/6c.png");
                                                        dice[m].image = Image.FromFile("Images/6c.png");
                                                        picGameDice[i].Image = dice[i].image;
                                                        picGameDice[n].Image = dice[n].image;
                                                        picGameDice[m].Image = dice[m].image;
                                                        player.canClaim = true;
                                                        player.Turn_Score += 600;
                                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                        done = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (done) { break; }
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //3 x Ones - 1000 Points
            if (combinations[11].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 1)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (dice[n].Id != dice[i].Id)
                                {
                                    if (!dice[n].Saved)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                            {
                                                if (!dice[m].Saved)
                                                {
                                                    if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value)
                                                    {
                                                        dice[i].Saved = true;
                                                        dice[n].Saved = true;
                                                        dice[m].Saved = true;
                                                        dice[i].image = Image.FromFile("Images/1c.png");
                                                        dice[n].image = Image.FromFile("Images/1c.png");
                                                        dice[m].image = Image.FromFile("Images/1c.png");
                                                        picGameDice[i].Image = dice[i].image;
                                                        picGameDice[n].Image = dice[n].image;
                                                        picGameDice[m].Image = dice[m].image;
                                                        player.canClaim = true;
                                                        player.Turn_Score += 1000;
                                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                        done = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (done) { break; }
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //4 Set Any Number - 1000 Points
            if (combinations[12].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                        {
                                            if (!dice[m].Saved)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (dice[o].Id != dice[m].Id && dice[o].Id != dice[n].Id && dice[o].Id != dice[i].Id)
                                                    {
                                                        if (!dice[o].Saved)
                                                        {
                                                            if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value && dice[o].Value == dice[i].Value)
                                                            {
                                                                dice[i].Saved = true;
                                                                dice[n].Saved = true;
                                                                dice[m].Saved = true;
                                                                dice[o].Saved = true;
                                                                dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                                                                dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                                                                dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                                                                dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                                                                picGameDice[i].Image = dice[i].image;
                                                                picGameDice[n].Image = dice[n].image;
                                                                picGameDice[m].Image = dice[m].image;
                                                                picGameDice[o].Image = dice[o].image;
                                                                player.canClaim = true;
                                                                player.Turn_Score += 1000;
                                                                lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                                done = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                if (done) { break; }
                                            }
                                        }
                                    }
                                    if (done) { break; }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //Full House Set Of 3 and 2 Pair - 1000 Points
            if (combinations[13].Checked)
            {
                bool done = false;
                bool done2 = false;
                bool threeSet = false;
                bool pair = false;
                int[] firstIds = { 6, 6, 6 };
                int[] secondIds = { 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                        {
                                            if (!dice[m].Saved)
                                            {
                                                if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value)
                                                {
                                                    threeSet = true;
                                                    firstIds[0] = i;
                                                    firstIds[1] = n;
                                                    firstIds[2] = m;
                                                    done = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (done) { break; }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }

                for (int o = 0; o < Total_Dice; o++)
                {
                    if (!dice[o].Saved)
                    {
                        for (int p = 0; p < Total_Dice; p++)
                        {
                            if (dice[p].Id != dice[o].Id)
                            {
                                if (!dice[p].Saved)
                                {
                                    if (dice[p].Value == dice[o].Value)
                                    {
                                        pair = true;
                                        secondIds[0] = o;
                                        secondIds[1] = p;
                                        done2 = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (done2) { break; }
                }

                if (threeSet && pair)
                {
                    int i = firstIds[0];
                    int n = firstIds[1];
                    int m = firstIds[2];
                    int o = secondIds[0];
                    int p = secondIds[1];

                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[p].Saved = true;
                    dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                    dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                    dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                    dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                    dice[p].image = Image.FromFile("Images/" + dice[p].Value + "c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;
                    picGameDice[p].Image = dice[p].image;
                    player.canClaim = true;
                    player.Turn_Score += 1000;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //Straight One-Two-Three-Four-Five - 1000 Points
            if (combinations[14].Checked)
            {
                bool one = false;
                bool two = false;
                bool three = false;
                bool four = false;
                bool five = false;
                int[] ids = { 6, 6, 6, 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!dice[n].Saved)
                    {
                        if (n != ids[0])
                        {
                            if (dice[n].Value == 2)
                            {
                                two = true;
                                ids[1] = n;
                                break;
                            }
                        }
                    }
                }

                for (int m = 0; m < Total_Dice; m++)
                {
                    if (!dice[m].Saved)
                    {
                        if (m != ids[1])
                        {
                            if (dice[m].Value == 3)
                            {
                                three = true;
                                ids[2] = m;
                                break;
                            }
                        }
                    }
                }

                for (int o = 0; o < Total_Dice; o++)
                {
                    if (!dice[o].Saved)
                    {
                        if (o != ids[2])
                        {
                            if (dice[o].Value == 4)
                            {
                                four = true;
                                ids[3] = o;
                                break;
                            }
                        }
                    }
                }

                for (int p = 0; p < Total_Dice; p++)
                {
                    if (!dice[p].Saved)
                    {
                        if (p != ids[3])
                        {
                            if (dice[p].Value == 5)
                            {
                                five = true;
                                ids[4] = p;
                                break;
                            }
                        }
                    }
                }

                if (one && two && three && four && five)
                {
                    int i = ids[0];
                    int n = ids[1];
                    int m = ids[2];
                    int o = ids[3];
                    int p = ids[4];
                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[p].Saved = true;
                    dice[i].image = Image.FromFile("Images/1c.png");
                    dice[n].image = Image.FromFile("Images/2c.png");
                    dice[m].image = Image.FromFile("Images/3c.png");
                    dice[o].image = Image.FromFile("Images/4c.png");
                    dice[p].image = Image.FromFile("Images/5c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;
                    picGameDice[p].Image = dice[p].image;
                    player.canClaim = true;
                    player.Turn_Score += 1000;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //5 Set Any Number - 2000 Points
            if (combinations[15].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                        {
                                            if (!dice[m].Saved)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (dice[o].Id != dice[m].Id && dice[o].Id != dice[n].Id && dice[o].Id != dice[i].Id)
                                                    {
                                                        if (!dice[o].Saved)
                                                        {
                                                            for (int p = 0; p < Total_Dice; p++)
                                                            {
                                                                if (dice[o].Id != dice[m].Id && dice[o].Id != dice[n].Id && dice[o].Id != dice[i].Id && dice[p].Id != dice[i].Id)
                                                                {
                                                                    if (!dice[p].Saved)
                                                                    {
                                                                        if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value && dice[o].Value == dice[i].Value && dice[p].Value == dice[i].Value)
                                                                        {
                                                                            dice[i].Saved = true;
                                                                            dice[n].Saved = true;
                                                                            dice[m].Saved = true;
                                                                            dice[o].Saved = true;
                                                                            dice[p].Saved = true;
                                                                            dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                                                                            dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                                                                            dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                                                                            dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                                                                            dice[p].image = Image.FromFile("Images/" + dice[p].Value + "c.png");
                                                                            picGameDice[i].Image = dice[i].image;
                                                                            picGameDice[n].Image = dice[n].image;
                                                                            picGameDice[m].Image = dice[m].image;
                                                                            picGameDice[o].Image = dice[o].image;
                                                                            picGameDice[p].Image = dice[p].image;
                                                                            player.canClaim = true;
                                                                            player.Turn_Score += 2000;
                                                                            lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                                            done = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (done) { break; }
                                            }
                                        }
                                    }
                                    if (done) { break; }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //3 Set and 3 Set Any Number - 2000 Points
            if (combinations[16].Checked)
            {
                bool firstPair = false;
                bool secondPair = false;
                int[] firstIds = { 6, 6, 6 };
                int[] secondIds = { 6, 6, 6 };
                bool done = false;
                bool done2 = false;

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (dice[m].Id != dice[i].Id && dice[m].Id != dice[n].Id)
                                        {
                                            if (!dice[m].Saved)
                                            {
                                                if (dice[i].Value == dice[n].Value && dice[i].Value == dice[m].Value)
                                                {
                                                    firstPair = true;
                                                    firstIds[0] = i;
                                                    firstIds[1] = n;
                                                    firstIds[2] = m;
                                                    done = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }

                for (int o = 0; o < Total_Dice; o++)
                {
                    if (!dice[o].Saved)
                    {
                        for (int p = 0; p < Total_Dice; p++)
                        {
                            if (dice[p].Id != dice[o].Id)
                            {
                                if (!dice[p].Saved)
                                {
                                    for (int r = 0; r < Total_Dice; r++)
                                    {
                                        if (dice[r].Id != dice[o].Id && dice[r].Id != dice[p].Id)
                                        {
                                            if (!dice[r].Saved)
                                            {
                                                if (dice[o].Value == dice[p].Value && dice[o].Value == dice[r].Value)
                                                {
                                                    secondPair = true;
                                                    secondIds[0] = o;
                                                    secondIds[1] = p;
                                                    secondIds[2] = r;
                                                    done2 = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (done2) { break; }
                }

                if (firstPair && secondPair)
                {
                    int i = firstIds[0];
                    int n = firstIds[1];
                    int m = firstIds[2];
                    int o = secondIds[0];
                    int p = secondIds[1];
                    int r = secondIds[2];
                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[p].Saved = true;
                    dice[r].Saved = true;
                    dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                    dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                    dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                    dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                    dice[p].image = Image.FromFile("Images/" + dice[p].Value + "c.png");
                    dice[r].image = Image.FromFile("Images/" + dice[r].Value + "c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;
                    picGameDice[p].Image = dice[p].image;
                    picGameDice[r].Image = dice[r].image;
                    player.canClaim = true;
                    player.Turn_Score += 2000;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //3 Pairs of 2 Any Number - 2000 Points
            if (combinations[17].Checked)
            {
                bool firstPair = false;
                bool secondPair = false;
                bool thirdPair = false;
                int[] firstIds = { 6, 6 };
                int[] secondIds = { 6, 6 };
                int[] thirdIds = { 6, 6 };
                bool done = false;
                bool done2 = false;
                bool done3 = false;

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    if (dice[i].Value == dice[n].Value)
                                    {
                                        firstPair = true;
                                        firstIds[0] = i;
                                        firstIds[1] = n;
                                        done = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }

                for (int m = 0; m < Total_Dice; m++)
                {
                    if (dice[m].Id != firstIds[0] && dice[m].Id != firstIds[1])
                    {
                        if (!dice[m].Saved)
                        {
                            for (int o = 0; o < Total_Dice; o++)
                            {
                                if (dice[o].Id != dice[m].Id && dice[o].Id != firstIds[0] && dice[o].Id != firstIds[1])
                                {
                                    if (!dice[o].Saved)
                                    {
                                        if (dice[o].Value == dice[m].Value)
                                        {
                                            secondPair = true;
                                            secondIds[0] = m;
                                            secondIds[1] = o;
                                            done2 = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (done2) { break; }
                }

                for (int p = 0; p < Total_Dice; p++)
                {
                    if (dice[p].Id != firstIds[0] && dice[p].Id != firstIds[1] && dice[p].Id != secondIds[0] && dice[p].Id != secondIds[1])
                    {
                        if (!dice[p].Saved)
                        {
                            for (int r = 0; r < Total_Dice; r++)
                            {
                                if (dice[r].Id != dice[p].Id && dice[r].Id != firstIds[0] && dice[r].Id != firstIds[1] && dice[r].Id != secondIds[0] && dice[r].Id != secondIds[1])
                                {
                                    if (!dice[r].Saved)
                                    {
                                        if (dice[r].Value == dice[p].Value)
                                        {
                                            thirdPair = true;
                                            thirdIds[0] = p;
                                            thirdIds[1] = r;
                                            done3 = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (done3) { break; }
                }

                if (firstPair && secondPair && thirdPair)
                {
                    int i = firstIds[0];
                    int n = firstIds[1];
                    int m = secondIds[0];
                    int o = secondIds[1];
                    int p = thirdIds[0];
                    int r = thirdIds[1];
                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[p].Saved = true;
                    dice[r].Saved = true;
                    dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                    dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                    dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                    dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                    dice[p].image = Image.FromFile("Images/" + dice[p].Value + "c.png");
                    dice[r].image = Image.FromFile("Images/" + dice[r].Value + "c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;
                    picGameDice[p].Image = dice[p].image;
                    picGameDice[r].Image = dice[r].image;
                    player.canClaim = true;
                    player.Turn_Score += 2000;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //Straight One-Two-Three-Four-Five-Six - 3000 Points
            if (combinations[18].Checked)
            {
                bool one = false;
                bool two = false;
                bool three = false;
                bool four = false;
                bool five = false;
                bool six = false;
                int[] ids = { 6, 6, 6, 6, 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        if (dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!dice[n].Saved)
                    {
                        if (n != ids[0])
                        {
                            if (dice[n].Value == 2)
                            {
                                two = true;
                                ids[1] = n;
                                break;
                            }
                        }
                    }
                }

                for (int m = 0; m < Total_Dice; m++)
                {
                    if (!dice[m].Saved)
                    {
                        if (m != ids[1])
                        {
                            if (dice[m].Value == 3)
                            {
                                three = true;
                                ids[2] = m;
                                break;
                            }
                        }
                    }
                }

                for (int o = 0; o < Total_Dice; o++)
                {
                    if (!dice[o].Saved)
                    {
                        if (o != ids[2])
                        {
                            if (dice[o].Value == 4)
                            {
                                four = true;
                                ids[3] = o;
                                break;
                            }
                        }
                    }
                }

                for (int p = 0; p < Total_Dice; p++)
                {
                    if (!dice[p].Saved)
                    {
                        if (p != ids[2])
                        {
                            if (dice[p].Value == 4)
                            {
                                five = true;
                                ids[4] = p;
                                break;
                            }
                        }
                    }
                }

                for (int r = 0; r < Total_Dice; r++)
                {
                    if (!dice[r].Saved)
                    {
                        if (r != ids[4])
                        {
                            if (dice[r].Value == 6)
                            {
                                six = true;
                                ids[5] = r;
                                break;
                            }
                        }
                    }
                }

                if (one && two && three && four && five && six)
                {
                    int i = ids[0];
                    int n = ids[1];
                    int m = ids[2];
                    int o = ids[3];
                    int p = ids[4];
                    int r = ids[5];
                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[p].Saved = true;
                    dice[r].Saved = true;
                    dice[i].image = Image.FromFile("Images/1c.png");
                    dice[n].image = Image.FromFile("Images/2c.png");
                    dice[m].image = Image.FromFile("Images/3c.png");
                    dice[o].image = Image.FromFile("Images/4c.png");
                    dice[p].image = Image.FromFile("Images/5c.png");
                    dice[r].image = Image.FromFile("Images/6c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;
                    picGameDice[p].Image = dice[p].image;
                    picGameDice[r].Image = dice[r].image;
                    player.canClaim = true;
                    player.Turn_Score += 3000;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                }
            }
            //6 Set Any Number - 3000 Points
            if (combinations[19].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                        {
                                            if (!dice[m].Saved)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (dice[o].Id != dice[m].Id && dice[o].Id != dice[n].Id && dice[o].Id != dice[i].Id)
                                                    {
                                                        if (!dice[o].Saved)
                                                        {
                                                            for (int p = 0; p < Total_Dice; p++)
                                                            {
                                                                if (dice[o].Id != dice[m].Id && dice[o].Id != dice[n].Id && dice[o].Id != dice[i].Id && dice[p].Id != dice[i].Id)
                                                                {
                                                                    if (!dice[p].Saved)
                                                                    {
                                                                        for (int r = 0; r < Total_Dice; r++)
                                                                        {
                                                                            if (dice[o].Id != dice[m].Id && dice[o].Id != dice[n].Id && dice[o].Id != dice[i].Id && dice[p].Id != dice[i].Id && dice[r].Id != dice[i].Id)
                                                                            {
                                                                                if (!dice[r].Saved)
                                                                                {
                                                                                    if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value && dice[o].Value == dice[i].Value && dice[p].Value == dice[i].Value && dice[r].Value == dice[i].Value)
                                                                                    {
                                                                                        dice[i].Saved = true;
                                                                                        dice[n].Saved = true;
                                                                                        dice[m].Saved = true;
                                                                                        dice[o].Saved = true;
                                                                                        dice[p].Saved = true;
                                                                                        dice[r].Saved = true;
                                                                                        dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                                                                                        dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                                                                                        dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                                                                                        dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                                                                                        dice[p].image = Image.FromFile("Images/" + dice[p].Value + "c.png");
                                                                                        dice[r].image = Image.FromFile("Images/" + dice[r].Value + "c.png");
                                                                                        picGameDice[i].Image = dice[i].image;
                                                                                        picGameDice[n].Image = dice[n].image;
                                                                                        picGameDice[m].Image = dice[m].image;
                                                                                        picGameDice[o].Image = dice[o].image;
                                                                                        picGameDice[p].Image = dice[p].image;
                                                                                        picGameDice[r].Image = dice[r].image;
                                                                                        player.canClaim = true;
                                                                                        player.Turn_Score += 3000;
                                                                                        lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
                                                                                        done = true;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        if (done) { break; }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (done) { break; }
                                            }
                                        }
                                    }
                                    if (done) { break; }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }
            }
            //4 Set Any Number And 2 Pair Any Number - 3000 Points
            if (combinations[20].Checked)
            {
                bool done = false;
                bool done2 = false;
                bool fourSet = false;
                bool pair = false;
                int[] firstIds = { 6, 6, 6, 6 };
                int[] secondIds = { 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!dice[i].Saved)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (dice[n].Id != dice[i].Id)
                            {
                                if (!dice[n].Saved)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (dice[m].Id != dice[n].Id && dice[m].Id != dice[i].Id)
                                        {
                                            if (!dice[m].Saved)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (dice[o].Id != dice[n].Id && dice[o].Id != dice[i].Id && dice[o].Id != dice[m].Id)
                                                    {
                                                        if (!dice[o].Saved)
                                                        {
                                                            if (dice[n].Value == dice[i].Value && dice[m].Value == dice[i].Value && dice[o].Value == dice[i].Value)
                                                            {
                                                                fourSet = true;
                                                                firstIds[0] = i;
                                                                firstIds[1] = n;
                                                                firstIds[2] = m;
                                                                firstIds[3] = o;
                                                                done = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                if (done) { break; }
                                            }
                                        }
                                    }
                                    if (done) { break; }
                                }
                            }
                        }
                    }
                    if (done) { break; }
                }

                for (int p = 0; p < Total_Dice; p++)
                {
                    if (!dice[p].Saved)
                    {
                        for (int r = 0; r < Total_Dice; r++)
                        {
                            if (dice[p].Id != dice[r].Id)
                            {
                                if (!dice[r].Saved)
                                {
                                    if (dice[p].Value == dice[r].Value)
                                    {
                                        pair = true;
                                        secondIds[0] = p;
                                        secondIds[1] = r;
                                        done2 = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (done2) { break; }
                }

                if (fourSet && pair)
                {
                    int i = firstIds[0];
                    int n = firstIds[1];
                    int m = firstIds[2];
                    int o = firstIds[3];
                    int p = secondIds[0];
                    int r = secondIds[1];
                    dice[i].Saved = true;
                    dice[n].Saved = true;
                    dice[m].Saved = true;
                    dice[o].Saved = true;
                    dice[p].Saved = true;
                    dice[r].Saved = true;
                    dice[i].image = Image.FromFile("Images/" + dice[i].Value + "c.png");
                    dice[n].image = Image.FromFile("Images/" + dice[n].Value + "c.png");
                    dice[m].image = Image.FromFile("Images/" + dice[m].Value + "c.png");
                    dice[o].image = Image.FromFile("Images/" + dice[o].Value + "c.png");
                    dice[p].image = Image.FromFile("Images/" + dice[p].Value + "c.png");
                    dice[r].image = Image.FromFile("Images/" + dice[r].Value + "c.png");
                    picGameDice[i].Image = dice[i].image;
                    picGameDice[n].Image = dice[n].image;
                    picGameDice[m].Image = dice[m].image;
                    picGameDice[o].Image = dice[o].image;
                    picGameDice[p].Image = dice[p].image;
                    picGameDice[r].Image = dice[r].image;
                    player.canClaim = true;
                    player.Turn_Score += 3000;
                    lblTurnScore.Text = "Turn Score: " + player.Turn_Score;
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

                bool checksaved = IsHotDice();
                if (checksaved) { lblHotDice.Visible = true; player.hotDice = true; ResetDice(); }

                lblProjectedScore.Text = "Projected Score: " + (player.Total_Score + player.Turn_Score);

                btnRoll.Enabled = true;
                btnClaim.Enabled = false;
                btnEndTurn.Enabled = true;
            }
            else
            {
                DialogResult answer = MessageBox.Show("You havent selected any combinations. Do you want to end your turn and claim 0? Press no to chance!", "Invalid Selection", MessageBoxButtons.YesNoCancel);
                if (answer == DialogResult.Yes)
                {
                    player.Turn_Score = 0;
                    lblTurnScore.Text = "Turn Score: 0";
                    lblProjectedScore.Text = "Projected Score: 0";
                    EndTurn();
                    return;
                }
                else if (answer == DialogResult.No)
                {
                    return;
                }
            }
        }

        private bool IsHotDice()
        {
            int taken = 0;
            for (int i = 0; i < Total_Dice; i++)
            {
                if (dice[i].Saved)
                {
                    taken += 1;
                }
            }

            if (taken == Total_Dice) { return true; } else { return false; }
        }

        private void ResetDice()
        {
            for (int i = 0; i < Total_Dice; i++)
            {
                dice[i].Saved = false;
                dice[i].image = Image.FromFile("Images/" + dice[i].Value + "u.png");
                picGameDice[i].Image = dice[i].image;
            }
        }

        private void EndTurn()
        {
            for (int i = 0; i < Total_Dice; i++)
            {
                dice[i].Saved = false;
                dice[i].image = Image.FromFile("Images/" + dice[i].Value + "u.png");
                picGameDice[i].Image = dice[i].image;
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
            lblProjectedScore.Text = "Projected Score: 0";
            player.hotDice = false;
            btnRoll.Enabled = true;
            btnClaim.Enabled = false;
            btnEndTurn.Enabled = false;
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            EndTurn();
        }

        private void Garbage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                if (!btnRoll.Enabled) { btnRoll.Enabled = true; }
            }

            if (e.KeyCode == Keys.N)
            {
                NewGame();
            }

            if (e.KeyCode == Keys.Escape)
            {
                ExitGame();
            }
        }
    }
}
