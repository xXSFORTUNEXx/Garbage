using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Garbage.Classes;

namespace Garbage
{
    public partial class Garbage : Form
    {
        private Player Game_Player;
        private Dice[] Game_Dice = new Dice[6];
        private PictureBox[] picGameDice = new PictureBox[6];
        private CheckBox[] chkCombos = new CheckBox[21];
        private Label[] lblScoreboard = new Label[10];
        const int Total_Dice = 6;
        const int Total_Combos = 21;
        const int Total_Turns = 10;

        public Garbage()
        {
            InitializeComponent();
            CreateCombinations();
            CreateDice();
            CreateScoreboard();
            for (int i = 0; i < Total_Dice; i++)
            {
                Game_Dice[i] = new Dice(i);
                picGameDice[i].Image = Game_Dice[i].Dice_Image;
            }
            Highscore.LoadHighschores();
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
                chkCombos[i] = new CheckBox();
                chkCombos[i].Location = new Point(12, ((i + 1) * 22));
                chkCombos[i].Size = new Size(290, 20);
                grpCombinations.Controls.Add(chkCombos[i]);
            }

            chkCombos[0].Text = "3 x Twos - 200 Points";
            chkCombos[1].Text = "Straight One-Two-Three - 250 Points";
            chkCombos[2].Text = "3 x Threes - 300 Points";
            chkCombos[3].Text = "3 x Fours - 400 Points";
            chkCombos[4].Text = "3 x Fives - 500 Points";
            chkCombos[5].Text = "2 Pairs of Any 2 Numbers - 500 Points";
            chkCombos[6].Text = "Straight One-Two-Three-Four - 500 Points";
            chkCombos[7].Text = "3 x Sixes - 600 Points";
            chkCombos[8].Text = "3 x Ones - 1000 Points";
            chkCombos[9].Text = "4 Set Any Number - 1000 Points";
            chkCombos[10].Text = "Full House Set Of 3 and 2 Pair - 1000 Points";
            chkCombos[11].Text = "Straight One-Two-Three-Four-Five - 1000 Points";
            chkCombos[12].Text = "5 Set Any Number - 2000 Points";
            chkCombos[13].Text = "3 Set and 3 Set Any Number - 2000 Points";
            chkCombos[14].Text = "3 Pairs of 2 Any Number - 2000 Points";
            chkCombos[15].Text = "Straight One-Two-Three-Four-Five-Six - 3000 Points";
            chkCombos[16].Text = "6 Set Any Number - 3000 Points";
            chkCombos[17].Text = "4 Set Any Number And 2 Pair Any Number - 3000 Points";
            chkCombos[18].Text = "1 Pair Any Number - 50 Points";
            chkCombos[19].Text = "One - 100 Points";
            chkCombos[20].Text = "Five - 50 Points";
        }

        private void CreateScoreboard()
        {
            for (int i = 0; i < 7; i++)
            {
                lblScoreboard[i] = new Label();
                lblScoreboard[i].Location = new Point(12, ((i + 1) * 22));
                lblScoreboard[i].Size = new Size(100, 20);
                grpScoreboard.Controls.Add(lblScoreboard[i]);
                lblScoreboard[i].Text = (i + 1) + ": ";
            }

            int n = 0;
            for (int i = 7; i < 10; i++)
            {
                lblScoreboard[i] = new Label();
                lblScoreboard[i].Location = new Point(115, ((n + 1) * 22));
                n += 1;
                lblScoreboard[i].Size = new Size(75, 20);
                grpScoreboard.Controls.Add(lblScoreboard[i]);
                lblScoreboard[i].Text = (i + 1) + ": ";
            }
        }

        private void ExitGame()
        {
            DialogResult answer = MessageBox.Show("Are you sure you wish to exit?", "Exit", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes) { Application.Exit(); }
        }

        private void NewGame()
        {
            string name = Interaction.InputBox("Please enter your name: ", "Enter Name", "John Doe");
            Game_Player = new Player(name);
            lblName.Text = "Name: " + name;
            lblChances.Text = "Chances This Turn: " + Game_Player.Chances;           
            btnRoll.Enabled = true;
        }

        private void CheckCombinations()
        {
            Game_Player.Can_Claim = false;
            //3 x Twos - 200 Points
            if (chkCombos[0].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 2)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (Game_Dice[n].Id != Game_Dice[i].Id)
                                {
                                    if (!Game_Dice[n].Claimed)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                            {
                                                if (!Game_Dice[m].Claimed)
                                                {
                                                    if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value)
                                                    {
                                                        Game_Dice[i].Claimed = true;
                                                        Game_Dice[n].Claimed = true;
                                                        Game_Dice[m].Claimed = true;
                                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/2c.png");
                                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/2c.png");
                                                        Game_Dice[m].Dice_Image = Image.FromFile("Images/2c.png");
                                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                        picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                        Game_Player.Can_Claim = true;
                                                        Game_Player.Current_Turn_Score += 200;
                                                        Game_Player.Current_Roll_Score += 200;
                                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[1].Checked)
            {
                bool one = false;
                bool two = false;
                bool three = false;
                int[] ids = { 6, 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!Game_Dice[n].Claimed)
                    {
                        if (n != ids[0])
                        {
                            if (Game_Dice[n].Value == 2)
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
                    if (!Game_Dice[m].Claimed)
                    {
                        if (m != ids[1])
                        {
                            if (Game_Dice[m].Value == 3)
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
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/1c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/2c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/3c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 250;
                    Game_Player.Current_Roll_Score += 250;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //3 x Threes - 300 Points
            if (chkCombos[2].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 3)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (Game_Dice[n].Id != Game_Dice[i].Id)
                                {
                                    if (!Game_Dice[n].Claimed)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                            {
                                                if (!Game_Dice[m].Claimed)
                                                {
                                                    if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value)
                                                    {
                                                        Game_Dice[i].Claimed = true;
                                                        Game_Dice[n].Claimed = true;
                                                        Game_Dice[m].Claimed = true;
                                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/3c.png");
                                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/3c.png");
                                                        Game_Dice[m].Dice_Image = Image.FromFile("Images/3c.png");
                                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                        picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                        Game_Player.Can_Claim = true;
                                                        Game_Player.Current_Turn_Score += 300;
                                                        Game_Player.Current_Roll_Score += 300;
                                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[3].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 4)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (Game_Dice[n].Id != Game_Dice[i].Id)
                                {
                                    if (!Game_Dice[n].Claimed)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                            {
                                                if (!Game_Dice[m].Claimed)
                                                {
                                                    if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value)
                                                    {
                                                        Game_Dice[i].Claimed = true;
                                                        Game_Dice[n].Claimed = true;
                                                        Game_Dice[m].Claimed = true;
                                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/4c.png");
                                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/4c.png");
                                                        Game_Dice[m].Dice_Image = Image.FromFile("Images/4c.png");
                                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                        picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                        Game_Player.Can_Claim = true;
                                                        Game_Player.Current_Turn_Score += 400;
                                                        Game_Player.Current_Roll_Score += 400;
                                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[4].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 5)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (Game_Dice[n].Id != Game_Dice[i].Id)
                                {
                                    if (!Game_Dice[n].Claimed)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                            {
                                                if (!Game_Dice[m].Claimed)
                                                {
                                                    if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value)
                                                    {
                                                        Game_Dice[i].Claimed = true;
                                                        Game_Dice[n].Claimed = true;
                                                        Game_Dice[m].Claimed = true;
                                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/5c.png");
                                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/5c.png");
                                                        Game_Dice[m].Dice_Image = Image.FromFile("Images/5c.png");
                                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                        picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                        Game_Player.Can_Claim = true;
                                                        Game_Player.Current_Turn_Score += 500;
                                                        Game_Player.Current_Roll_Score += 500;
                                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[5].Checked)
            {
                bool firstPair = false;
                bool secondPair = false;
                int[] firstIds = { 6, 6 };
                int[] secondIds = { 6, 6 };
                bool done = false;
                bool done2 = false;

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    if (Game_Dice[i].Value == Game_Dice[n].Value)
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
                    if (Game_Dice[m].Id != firstIds[0] && Game_Dice[m].Id != firstIds[1])
                    {
                        if (!Game_Dice[m].Claimed)
                        {
                            for (int o = 0; o < Total_Dice; o++)
                            {
                                if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != firstIds[0] && Game_Dice[o].Id != firstIds[1])
                                {
                                    if (!Game_Dice[o].Claimed)
                                    {
                                        if (Game_Dice[o].Value == Game_Dice[m].Value)
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

                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 500;
                    Game_Player.Current_Roll_Score += 500;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //Straight One-Two-Three-Four - 500 Points
            if (chkCombos[6].Checked)
            {
                bool one = false;
                bool two = false;
                bool three = false;
                bool four = false;
                int[] ids = { 6, 6, 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!Game_Dice[n].Claimed)
                    {
                        if (n != ids[0])
                        {
                            if (Game_Dice[n].Value == 2)
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
                    if (!Game_Dice[m].Claimed)
                    {
                        if (m != ids[1])
                        {
                            if (Game_Dice[m].Value == 3)
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
                    if (!Game_Dice[o].Claimed)
                    {
                        if (o != ids[2])
                        {
                            if (Game_Dice[o].Value == 4)
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
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/1c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/2c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/3c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/4c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;

                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 500;
                    Game_Player.Current_Roll_Score += 500;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //3 x Sixes - 600 Points
            if (chkCombos[7].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 6)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (Game_Dice[n].Id != Game_Dice[i].Id)
                                {
                                    if (!Game_Dice[n].Claimed)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                            {
                                                if (!Game_Dice[m].Claimed)
                                                {
                                                    if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value)
                                                    {
                                                        Game_Dice[i].Claimed = true;
                                                        Game_Dice[n].Claimed = true;
                                                        Game_Dice[m].Claimed = true;
                                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/6c.png");
                                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/6c.png");
                                                        Game_Dice[m].Dice_Image = Image.FromFile("Images/6c.png");
                                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                        picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                        Game_Player.Can_Claim = true;
                                                        Game_Player.Current_Turn_Score += 600;
                                                        Game_Player.Current_Roll_Score += 600;
                                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[8].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 1)
                        {
                            for (int n = 0; n < Total_Dice; n++)
                            {
                                if (Game_Dice[n].Id != Game_Dice[i].Id)
                                {
                                    if (!Game_Dice[n].Claimed)
                                    {
                                        for (int m = 0; m < Total_Dice; m++)
                                        {
                                            if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                            {
                                                if (!Game_Dice[m].Claimed)
                                                {
                                                    if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value)
                                                    {
                                                        Game_Dice[i].Claimed = true;
                                                        Game_Dice[n].Claimed = true;
                                                        Game_Dice[m].Claimed = true;
                                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/1c.png");
                                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/1c.png");
                                                        Game_Dice[m].Dice_Image = Image.FromFile("Images/1c.png");
                                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                        picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                        Game_Player.Can_Claim = true;
                                                        Game_Player.Current_Turn_Score += 1000;
                                                        Game_Player.Current_Roll_Score += 1000;
                                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[9].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                        {
                                            if (!Game_Dice[m].Claimed)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != Game_Dice[n].Id && Game_Dice[o].Id != Game_Dice[i].Id)
                                                    {
                                                        if (!Game_Dice[o].Claimed)
                                                        {
                                                            if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value && Game_Dice[o].Value == Game_Dice[i].Value)
                                                            {
                                                                Game_Dice[i].Claimed = true;
                                                                Game_Dice[n].Claimed = true;
                                                                Game_Dice[m].Claimed = true;
                                                                Game_Dice[o].Claimed = true;
                                                                Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                                                                Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                                                                Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                                                                Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                                                                picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                                picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                                picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                                picGameDice[o].Image = Game_Dice[o].Dice_Image;
                                                                Game_Player.Can_Claim = true;
                                                                Game_Player.Current_Turn_Score += 1000;
                                                                Game_Player.Current_Roll_Score += 1000;
                                                                lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[10].Checked)
            {
                bool done = false;
                bool done2 = false;
                bool threeSet = false;
                bool pair = false;
                int[] firstIds = { 6, 6, 6 };
                int[] secondIds = { 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                        {
                                            if (!Game_Dice[m].Claimed)
                                            {
                                                if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value)
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
                    if (Game_Dice[o].Id != firstIds[0] && Game_Dice[o].Id != firstIds[1] && Game_Dice[o].Id != firstIds[2])
                    {
                        if (!Game_Dice[o].Claimed)
                        {
                            for (int p = 0; p < Total_Dice; p++)
                            {
                                if (Game_Dice[p].Id != firstIds[0] && Game_Dice[p].Id != firstIds[1] && Game_Dice[p].Id != firstIds[2])
                                {
                                    if (Game_Dice[p].Id != Game_Dice[o].Id)
                                    {
                                        if (!Game_Dice[p].Claimed)
                                        {
                                            if (Game_Dice[p].Value == Game_Dice[o].Value)
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
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[p].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                    Game_Dice[p].Dice_Image = Image.FromFile("Images/" + Game_Dice[p].Value + "c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;
                    picGameDice[p].Image = Game_Dice[p].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 1000;
                    Game_Player.Current_Roll_Score += 1000;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //Straight One-Two-Three-Four-Five - 1000 Points
            if (chkCombos[11].Checked)
            {
                bool one = false;
                bool two = false;
                bool three = false;
                bool four = false;
                bool five = false;
                int[] ids = { 6, 6, 6, 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!Game_Dice[n].Claimed)
                    {
                        if (n != ids[0])
                        {
                            if (Game_Dice[n].Value == 2)
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
                    if (!Game_Dice[m].Claimed)
                    {
                        if (m != ids[1])
                        {
                            if (Game_Dice[m].Value == 3)
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
                    if (!Game_Dice[o].Claimed)
                    {
                        if (o != ids[2])
                        {
                            if (Game_Dice[o].Value == 4)
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
                    if (!Game_Dice[p].Claimed)
                    {
                        if (p != ids[3])
                        {
                            if (Game_Dice[p].Value == 5)
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
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[p].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/1c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/2c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/3c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/4c.png");
                    Game_Dice[p].Dice_Image = Image.FromFile("Images/5c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;
                    picGameDice[p].Image = Game_Dice[p].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 1000;
                    Game_Player.Current_Roll_Score += 1000;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //5 Set Any Number - 2000 Points
            if (chkCombos[12].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                        {
                                            if (!Game_Dice[m].Claimed)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != Game_Dice[n].Id && Game_Dice[o].Id != Game_Dice[i].Id)
                                                    {
                                                        if (!Game_Dice[o].Claimed)
                                                        {
                                                            for (int p = 0; p < Total_Dice; p++)
                                                            {
                                                                if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != Game_Dice[n].Id && Game_Dice[o].Id != Game_Dice[i].Id && Game_Dice[p].Id != Game_Dice[i].Id)
                                                                {
                                                                    if (!Game_Dice[p].Claimed)
                                                                    {
                                                                        if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value && Game_Dice[o].Value == Game_Dice[i].Value && Game_Dice[p].Value == Game_Dice[i].Value)
                                                                        {
                                                                            Game_Dice[i].Claimed = true;
                                                                            Game_Dice[n].Claimed = true;
                                                                            Game_Dice[m].Claimed = true;
                                                                            Game_Dice[o].Claimed = true;
                                                                            Game_Dice[p].Claimed = true;
                                                                            Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                                                                            Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                                                                            Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                                                                            Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                                                                            Game_Dice[p].Dice_Image = Image.FromFile("Images/" + Game_Dice[p].Value + "c.png");
                                                                            picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                                            picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                                            picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                                            picGameDice[o].Image = Game_Dice[o].Dice_Image;
                                                                            picGameDice[p].Image = Game_Dice[p].Dice_Image;
                                                                            Game_Player.Can_Claim = true;
                                                                            Game_Player.Current_Turn_Score += 2000;
                                                                            Game_Player.Current_Roll_Score += 2000;
                                                                            lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[13].Checked)
            {
                bool firstPair = false;
                bool secondPair = false;
                int[] firstIds = { 6, 6, 6 };
                int[] secondIds = { 6, 6, 6 };
                bool done = false;
                bool done2 = false;

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (Game_Dice[m].Id != Game_Dice[i].Id && Game_Dice[m].Id != Game_Dice[n].Id)
                                        {
                                            if (!Game_Dice[m].Claimed)
                                            {
                                                if (Game_Dice[i].Value == Game_Dice[n].Value && Game_Dice[i].Value == Game_Dice[m].Value)
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
                    if (Game_Dice[o].Id != firstIds[0] && Game_Dice[o].Id != firstIds[1] && Game_Dice[o].Id != firstIds[2])
                    {
                        if (!Game_Dice[o].Claimed)
                        {
                            for (int p = 0; p < Total_Dice; p++)
                            {
                                if (Game_Dice[p].Id != firstIds[0] && Game_Dice[p].Id != firstIds[1] && Game_Dice[p].Id != firstIds[2])
                                {
                                    if (Game_Dice[p].Id != Game_Dice[o].Id)
                                    {
                                        if (!Game_Dice[p].Claimed)
                                        {
                                            for (int r = 0; r < Total_Dice; r++)
                                            {
                                                if (Game_Dice[r].Id != firstIds[0] && Game_Dice[r].Id != firstIds[1] && Game_Dice[r].Id != firstIds[2])
                                                {
                                                    if (Game_Dice[r].Id != Game_Dice[o].Id && Game_Dice[r].Id != Game_Dice[p].Id)
                                                    {
                                                        if (!Game_Dice[r].Claimed)
                                                        {
                                                            if (Game_Dice[o].Value == Game_Dice[p].Value && Game_Dice[o].Value == Game_Dice[r].Value)
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
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[p].Claimed = true;
                    Game_Dice[r].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                    Game_Dice[p].Dice_Image = Image.FromFile("Images/" + Game_Dice[p].Value + "c.png");
                    Game_Dice[r].Dice_Image = Image.FromFile("Images/" + Game_Dice[r].Value + "c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;
                    picGameDice[p].Image = Game_Dice[p].Dice_Image;
                    picGameDice[r].Image = Game_Dice[r].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 2000;
                    Game_Player.Current_Roll_Score += 2000;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //3 Pairs of 2 Any Number - 2000 Points
            if (chkCombos[14].Checked)
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
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    if (Game_Dice[i].Value == Game_Dice[n].Value)
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
                    if (Game_Dice[m].Id != firstIds[0] && Game_Dice[m].Id != firstIds[1])
                    {
                        if (!Game_Dice[m].Claimed)
                        {
                            for (int o = 0; o < Total_Dice; o++)
                            {
                                if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != firstIds[0] && Game_Dice[o].Id != firstIds[1])
                                {
                                    if (!Game_Dice[o].Claimed)
                                    {
                                        if (Game_Dice[o].Value == Game_Dice[m].Value)
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
                    if (Game_Dice[p].Id != firstIds[0] && Game_Dice[p].Id != firstIds[1] && Game_Dice[p].Id != secondIds[0] && Game_Dice[p].Id != secondIds[1])
                    {
                        if (!Game_Dice[p].Claimed)
                        {
                            for (int r = 0; r < Total_Dice; r++)
                            {
                                if (Game_Dice[r].Id != Game_Dice[p].Id && Game_Dice[r].Id != firstIds[0] && Game_Dice[r].Id != firstIds[1] && Game_Dice[r].Id != secondIds[0] && Game_Dice[r].Id != secondIds[1])
                                {
                                    if (!Game_Dice[r].Claimed)
                                    {
                                        if (Game_Dice[r].Value == Game_Dice[p].Value)
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
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[p].Claimed = true;
                    Game_Dice[r].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                    Game_Dice[p].Dice_Image = Image.FromFile("Images/" + Game_Dice[p].Value + "c.png");
                    Game_Dice[r].Dice_Image = Image.FromFile("Images/" + Game_Dice[r].Value + "c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;
                    picGameDice[p].Image = Game_Dice[p].Dice_Image;
                    picGameDice[r].Image = Game_Dice[r].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 2000;
                    Game_Player.Current_Roll_Score += 2000;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //Straight One-Two-Three-Four-Five-Six - 3000 Points
            if (chkCombos[15].Checked)
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
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 1)
                        {
                            one = true;
                            ids[0] = i;
                            break;
                        }
                    }
                }

                for (int n = 0; n < Total_Dice; n++)
                {
                    if (!Game_Dice[n].Claimed)
                    {
                        if (n != ids[0])
                        {
                            if (Game_Dice[n].Value == 2)
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
                    if (!Game_Dice[m].Claimed)
                    {
                        if (m != ids[1])
                        {
                            if (Game_Dice[m].Value == 3)
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
                    if (!Game_Dice[o].Claimed)
                    {
                        if (o != ids[2])
                        {
                            if (Game_Dice[o].Value == 4)
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
                    if (!Game_Dice[p].Claimed)
                    {
                        if (p != ids[2])
                        {
                            if (Game_Dice[p].Value == 4)
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
                    if (!Game_Dice[r].Claimed)
                    {
                        if (r != ids[4])
                        {
                            if (Game_Dice[r].Value == 6)
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
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[p].Claimed = true;
                    Game_Dice[r].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/1c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/2c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/3c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/4c.png");
                    Game_Dice[p].Dice_Image = Image.FromFile("Images/5c.png");
                    Game_Dice[r].Dice_Image = Image.FromFile("Images/6c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;
                    picGameDice[p].Image = Game_Dice[p].Dice_Image;
                    picGameDice[r].Image = Game_Dice[r].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 3000;
                    Game_Player.Current_Roll_Score += 3000;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //6 Set Any Number - 3000 Points
            if (chkCombos[16].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                        {
                                            if (!Game_Dice[m].Claimed)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != Game_Dice[n].Id && Game_Dice[o].Id != Game_Dice[i].Id)
                                                    {
                                                        if (!Game_Dice[o].Claimed)
                                                        {
                                                            for (int p = 0; p < Total_Dice; p++)
                                                            {
                                                                if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != Game_Dice[n].Id && Game_Dice[o].Id != Game_Dice[i].Id && Game_Dice[p].Id != Game_Dice[i].Id)
                                                                {
                                                                    if (!Game_Dice[p].Claimed)
                                                                    {
                                                                        for (int r = 0; r < Total_Dice; r++)
                                                                        {
                                                                            if (Game_Dice[o].Id != Game_Dice[m].Id && Game_Dice[o].Id != Game_Dice[n].Id && Game_Dice[o].Id != Game_Dice[i].Id && Game_Dice[p].Id != Game_Dice[i].Id && Game_Dice[r].Id != Game_Dice[i].Id)
                                                                            {
                                                                                if (!Game_Dice[r].Claimed)
                                                                                {
                                                                                    if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value && Game_Dice[o].Value == Game_Dice[i].Value && Game_Dice[p].Value == Game_Dice[i].Value && Game_Dice[r].Value == Game_Dice[i].Value)
                                                                                    {
                                                                                        Game_Dice[i].Claimed = true;
                                                                                        Game_Dice[n].Claimed = true;
                                                                                        Game_Dice[m].Claimed = true;
                                                                                        Game_Dice[o].Claimed = true;
                                                                                        Game_Dice[p].Claimed = true;
                                                                                        Game_Dice[r].Claimed = true;
                                                                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                                                                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                                                                                        Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                                                                                        Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                                                                                        Game_Dice[p].Dice_Image = Image.FromFile("Images/" + Game_Dice[p].Value + "c.png");
                                                                                        Game_Dice[r].Dice_Image = Image.FromFile("Images/" + Game_Dice[r].Value + "c.png");
                                                                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                                                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                                                                        picGameDice[m].Image = Game_Dice[m].Dice_Image;
                                                                                        picGameDice[o].Image = Game_Dice[o].Dice_Image;
                                                                                        picGameDice[p].Image = Game_Dice[p].Dice_Image;
                                                                                        picGameDice[r].Image = Game_Dice[r].Dice_Image;
                                                                                        Game_Player.Can_Claim = true;
                                                                                        Game_Player.Current_Turn_Score += 3000;
                                                                                        Game_Player.Current_Roll_Score += 3000;
                                                                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[17].Checked)
            {
                bool done = false;
                bool done2 = false;
                bool fourSet = false;
                bool pair = false;
                int[] firstIds = { 6, 6, 6, 6 };
                int[] secondIds = { 6, 6 };

                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    for (int m = 0; m < Total_Dice; m++)
                                    {
                                        if (Game_Dice[m].Id != Game_Dice[n].Id && Game_Dice[m].Id != Game_Dice[i].Id)
                                        {
                                            if (!Game_Dice[m].Claimed)
                                            {
                                                for (int o = 0; o < Total_Dice; o++)
                                                {
                                                    if (Game_Dice[o].Id != Game_Dice[n].Id && Game_Dice[o].Id != Game_Dice[i].Id && Game_Dice[o].Id != Game_Dice[m].Id)
                                                    {
                                                        if (!Game_Dice[o].Claimed)
                                                        {
                                                            if (Game_Dice[n].Value == Game_Dice[i].Value && Game_Dice[m].Value == Game_Dice[i].Value && Game_Dice[o].Value == Game_Dice[i].Value)
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
                    if (Game_Dice[p].Id != firstIds[0] && Game_Dice[p].Id != firstIds[1] && Game_Dice[p].Id != firstIds[2] && Game_Dice[p].Id != firstIds[3])
                    {
                        if (!Game_Dice[p].Claimed)
                        {
                            for (int r = 0; r < Total_Dice; r++)
                            {
                                if (Game_Dice[p].Id != Game_Dice[r].Id)
                                {
                                    if (Game_Dice[r].Id != firstIds[0] && Game_Dice[r].Id != firstIds[1] && Game_Dice[r].Id != firstIds[2] && Game_Dice[r].Id != firstIds[3])
                                    {
                                        if (!Game_Dice[r].Claimed)
                                        {
                                            if (Game_Dice[p].Value == Game_Dice[r].Value)
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
                    }
                }

                if (fourSet && pair)
                {
                    int i = firstIds[0];
                    int n = firstIds[1];
                    int m = firstIds[2];
                    int o = firstIds[3];
                    int p = secondIds[0];
                    int r = secondIds[1];
                    Game_Dice[i].Claimed = true;
                    Game_Dice[n].Claimed = true;
                    Game_Dice[m].Claimed = true;
                    Game_Dice[o].Claimed = true;
                    Game_Dice[p].Claimed = true;
                    Game_Dice[r].Claimed = true;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                    Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                    Game_Dice[m].Dice_Image = Image.FromFile("Images/" + Game_Dice[m].Value + "c.png");
                    Game_Dice[o].Dice_Image = Image.FromFile("Images/" + Game_Dice[o].Value + "c.png");
                    Game_Dice[p].Dice_Image = Image.FromFile("Images/" + Game_Dice[p].Value + "c.png");
                    Game_Dice[r].Dice_Image = Image.FromFile("Images/" + Game_Dice[r].Value + "c.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                    picGameDice[n].Image = Game_Dice[n].Dice_Image;
                    picGameDice[m].Image = Game_Dice[m].Dice_Image;
                    picGameDice[o].Image = Game_Dice[o].Dice_Image;
                    picGameDice[p].Image = Game_Dice[p].Dice_Image;
                    picGameDice[r].Image = Game_Dice[r].Dice_Image;
                    Game_Player.Can_Claim = true;
                    Game_Player.Current_Turn_Score += 3000;
                    Game_Player.Current_Roll_Score += 3000;
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                }
            }
            //1 Pair Any Number - 50 Points
            if (chkCombos[18].Checked)
            {
                bool done = false;
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        for (int n = 0; n < Total_Dice; n++)
                        {
                            if (Game_Dice[n].Id != Game_Dice[i].Id)
                            {
                                if (!Game_Dice[n].Claimed)
                                {
                                    if (Game_Dice[i].Value == Game_Dice[n].Value)
                                    {
                                        Game_Dice[i].Claimed = true;
                                        Game_Dice[n].Claimed = true;
                                        Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "c.png");
                                        Game_Dice[n].Dice_Image = Image.FromFile("Images/" + Game_Dice[n].Value + "c.png");
                                        picGameDice[i].Image = Game_Dice[i].Dice_Image;
                                        picGameDice[n].Image = Game_Dice[n].Dice_Image;
                                        Game_Player.Can_Claim = true;
                                        Game_Player.Current_Turn_Score += 50;
                                        Game_Player.Current_Roll_Score += 50;
                                        lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
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
            if (chkCombos[19].Checked)
            {
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 1)
                        {
                            Game_Dice[i].Claimed = true;
                            Game_Dice[i].Dice_Image = Image.FromFile("Images/1c.png");
                            picGameDice[i].Image = Game_Dice[i].Dice_Image;
                            Game_Player.Can_Claim = true;
                            Game_Player.Current_Turn_Score += 100;
                            Game_Player.Current_Roll_Score += 100;
                            lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                            break;
                        }
                    }
                }
            }
            //Five - 50 Points
            if (chkCombos[20].Checked)
            {
                for (int i = 0; i < Total_Dice; i++)
                {
                    if (!Game_Dice[i].Claimed)
                    {
                        if (Game_Dice[i].Value == 5)
                        {
                            Game_Dice[i].Claimed = true;
                            Game_Dice[i].Dice_Image = Image.FromFile("Images/5c.png");
                            picGameDice[i].Image = Game_Dice[i].Dice_Image;
                            Game_Player.Can_Claim = true;
                            Game_Player.Current_Turn_Score += 50;
                            Game_Player.Current_Roll_Score += 50;
                            lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                            break;
                        }
                    }
                }
            }

            //Can we claim something? If not then we need to or claim a 0, or chance it...
            if (Game_Player.Can_Claim)
            {
                for (int i = 0; i < Total_Combos; i++)
                {
                    chkCombos[i].Checked = false;
                    grpCombinations.Enabled = false;
                }

                bool checksaved = IsHotDice();
                if (checksaved) { lblHotDice.Visible = true; Game_Player.Hot_Dice = true; Game_Player.Current_Roll_Score = 0; ResetDice(); }

                lblProjectedScore.Text = "Projected Score: " + (Game_Player.Total_Score + Game_Player.Current_Turn_Score);
                Game_Player.Taking_Chance = false;
                btnRoll.Enabled = true;
                btnClaim.Enabled = false;
                btnEndTurn.Enabled = true;
                btnAdd.Enabled = false;
            }
            else
            {
                if (Game_Player.Taking_Chance)
                {
                    Game_Player.Current_Turn_Score = (-500 * Game_Player.Chances);
                    MessageBox.Show("You have lost " + Game_Player.Current_Turn_Score + " points from failing on a chance!", "Chance Failed", MessageBoxButtons.OK);
                    lblTurnScore.Text = "Turn Score: 0";
                    lblProjectedScore.Text = "Projected Score: 0";
                    EndTurn();
                    return;
                }

                DialogResult answer = MessageBox.Show("You havent selected any combinations. Do you want to end your turn and claim 0? Press no to chance!", "Invalid Selection", MessageBoxButtons.YesNoCancel);
                if (answer == DialogResult.Yes)
                {
                    Game_Player.Current_Turn_Score = 0;
                    Game_Player.Current_Roll_Score = 0;
                    lblTurnScore.Text = "Turn Score: 0";
                    lblProjectedScore.Text = "Projected Score: 0";
                    EndTurn();
                    return;
                }
                else if (answer == DialogResult.No)
                {
                    Game_Player.Taking_Chance = true;
                    Game_Player.Chances += 1;
                    lblChances.Text = "Chances This Turn: " + Game_Player.Chances;
                    btnRoll.Enabled = true;
                    btnClaim.Enabled = false;
                    return;
                }
            }
        }

        private bool IsHotDice()
        {
            int taken = 0;
            for (int i = 0; i < Total_Dice; i++)
            {
                if (Game_Dice[i].Claimed)
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
                Game_Dice[i].Claimed = false;
                Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "u.png");
                picGameDice[i].Image = Game_Dice[i].Dice_Image;
            }
        }

        private void EndTurn()
        {
            if (Game_Player.Turn < Total_Turns)
            {
                for (int i = 0; i < Total_Dice; i++)
                {
                    Game_Dice[i].Claimed = false;
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "u.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                }

                for (int i = 0; i < Total_Combos; i++)
                {
                    chkCombos[i].Checked = false;
                    grpCombinations.Enabled = false;
                }

                Game_Player.Total_Score += Game_Player.Current_Turn_Score;
                Game_Player.Turn_Scores[Game_Player.Turn - 1] = Game_Player.Current_Turn_Score;
                Game_Player.Current_Turn_Score = 0;
                Game_Player.Current_Roll_Score = 0;
                Game_Player.Taking_Chance = false;
                Game_Player.Chances = 0;
                lblChances.Text = "Chances This Turn: " + Game_Player.Chances;
                lblTotalScore.Text = "Total Score: " + Game_Player.Total_Score;
                lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                lblProjectedScore.Text = "Projected Score: 0";
                lblCurrentTurn.Text = "Current Turn: " + Game_Player.Turn;
                lblScoreboard[Game_Player.Turn - 1].Text = Game_Player.Turn + ": " + Game_Player.Turn_Scores[Game_Player.Turn - 1];
                Game_Player.Turn += 1;
                Game_Player.Hot_Dice = false;
                Game_Player.Using_Add = false;
                btnRoll.Enabled = true;
                btnClaim.Enabled = false;
                btnEndTurn.Enabled = false;
            }
            else
            {
                Game_Player.Total_Score += Game_Player.Current_Turn_Score;
                Game_Player.Turn_Scores[Game_Player.Turn - 1] = Game_Player.Current_Turn_Score;
                Game_Player.Current_Turn_Score = 0;
                Game_Player.Current_Roll_Score = 0;
                Game_Player.Taking_Chance = false;
                Game_Player.Chances = 0;
                lblChances.Text = "Chances This Turn: " + Game_Player.Chances;
                lblTotalScore.Text = "Total Score: " + Game_Player.Total_Score;
                lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                lblProjectedScore.Text = "Projected Score: 0";
                lblCurrentTurn.Text = "Current Turn: " + Game_Player.Turn;
                lblScoreboard[Game_Player.Turn - 1].Text = Game_Player.Turn + ": " + Game_Player.Turn_Scores[Game_Player.Turn - 1];
                Game_Player.Turn += 1;
                Game_Player.Hot_Dice = false;
                Game_Player.Using_Add = false;
                btnRoll.Enabled = false;
                btnClaim.Enabled = false;
                btnEndTurn.Enabled = false;

                bool newhighscore = false;
                for (int i = 0; i < 5; i++)
                {
                    if (Highscore.Name[i] == "None" && Highscore.Score[i] == 0)
                    {
                        newhighscore = true;
                        Highscore.Name[i] = Game_Player.Name;
                        Highscore.Score[i] = Game_Player.Total_Score;
                        Highscore.SaveHighscores();
                        break;
                    }
                }

                if (!newhighscore)
                {
                    for (int n = 0; n < 5; n++)
                    {
                        if (Game_Player.Total_Score > Highscore.Score[n])
                        {
                            newhighscore = true;
                            Highscore.Name[n] = Game_Player.Name;
                            Highscore.Score[n] = Game_Player.Total_Score;
                            Highscore.SaveHighscores();
                            break;
                        }
                    }
                }

                DialogResult result;
                if (newhighscore) { result = MessageBox.Show("Game over! New highscore! Your total score was: " + Game_Player.Total_Score + "! Play again?", "Game Over", MessageBoxButtons.YesNo); }                
                else { result = MessageBox.Show("Game over! Your total score was: " + Game_Player.Total_Score + "! Play again?", "Game Over", MessageBoxButtons.YesNo); }

                if (result == DialogResult.Yes) { NewGame(); }
                else { ExitGame(); }
            }
        }

        private void ClaimDice()
        {
            bool anything = false;
            for (int i = 0; i < Total_Combos; i++)
            {
                if (chkCombos[i].Checked)
                {
                    anything = true;
                    break;
                }
            }

            if (Game_Player.Using_Add)
            {
                if (!anything) { MessageBox.Show("You havent selected any combinations.", "Add", MessageBoxButtons.OK); return; }
                lblTurnScore.Text = "Turn Score: 0";
                lblProjectedScore.Text = "Projected Score: 0";
                CheckCombinations();
                EndTurn();
                return;
            }

            if (!anything)
            {
                if (Game_Player.Taking_Chance)
                {
                    Game_Player.Current_Turn_Score = (-500 * Game_Player.Chances);
                    MessageBox.Show("You have lost " + Game_Player.Current_Turn_Score + " points from failing on a chance!", "Chance Failed", MessageBoxButtons.OK);
                    lblTurnScore.Text = "Turn Score: 0";
                    lblProjectedScore.Text = "Projected Score: 0";
                    EndTurn();
                    return;
                }

                DialogResult answer = MessageBox.Show("You havent selected any combinations. Do you want to end your turn and claim 0? Press no to chance!", "Invalid Selection", MessageBoxButtons.YesNoCancel);
                if (answer == DialogResult.Yes)
                {
                    Game_Player.Current_Turn_Score = 0;
                    Game_Player.Current_Roll_Score = 0;
                    lblTurnScore.Text = "Turn Score: 0";
                    lblProjectedScore.Text = "Projected Score: 0";
                    EndTurn();
                    return;
                }
                else if (answer == DialogResult.No)
                {
                    Game_Player.Taking_Chance = true;
                    Game_Player.Chances += 1;
                    lblChances.Text = "Chances This Turn: " + Game_Player.Chances;
                    btnRoll.Enabled = true;
                    btnClaim.Enabled = false;
                    return;
                }
            }

            CheckCombinations();
        }

        private void RollDice()
        {
            var random = new Random();

            for (int i = 0; i < Total_Dice; i++)
            {
                if (!Game_Dice[i].Claimed)
                {
                    Game_Dice[i].Value = random.Next(1, 6);
                    Game_Dice[i].Dice_Image = Image.FromFile("Images/" + Game_Dice[i].Value + "u.png");
                    picGameDice[i].Image = Game_Dice[i].Dice_Image;
                }
            }

            //For testing
            /*Game_Dice[0].Value = 3;
            Game_Dice[1].Value = 3;
            Game_Dice[2].Value = 3;
            Game_Dice[3].Value = 4;
            Game_Dice[4].Value = 4;
            Game_Dice[5].Value = 4;
            Game_Dice[0].Dice_Image = Image.FromFile("Images/" + Game_Dice[0].Value + "u.png");
            picGameDice[0].Image = Game_Dice[0].Dice_Image;
            Game_Dice[1].Dice_Image = Image.FromFile("Images/" + Game_Dice[1].Value + "u.png");
            picGameDice[1].Image = Game_Dice[1].Dice_Image;
            Game_Dice[2].Dice_Image = Image.FromFile("Images/" + Game_Dice[2].Value + "u.png");
            picGameDice[2].Image = Game_Dice[2].Dice_Image;
            Game_Dice[3].Dice_Image = Image.FromFile("Images/" + Game_Dice[3].Value + "u.png");
            picGameDice[3].Image = Game_Dice[3].Dice_Image;
            Game_Dice[4].Dice_Image = Image.FromFile("Images/" + Game_Dice[4].Value + "u.png");
            picGameDice[4].Image = Game_Dice[4].Dice_Image;
            Game_Dice[5].Dice_Image = Image.FromFile("Images/" + Game_Dice[5].Value + "u.png");
            picGameDice[5].Image = Game_Dice[5].Dice_Image;*/

            btnRoll.Enabled = false;
            btnClaim.Enabled = true;
            grpCombinations.Enabled = true;
            btnEndTurn.Enabled = false;
            lblHotDice.Visible = false;
            btnAdd.Enabled = true;
        }

        private void CheckKeys(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R) { OpenRules(); }

            if (e.KeyCode == Keys.N) { NewGame(); }

            if (e.KeyCode == Keys.H) { OpenHighScores(); }

            if (e.KeyCode == Keys.End) { ExitGame(); }
        }

        private void InitAdd()
        {
            if (btnRoll.Enabled) { MessageBox.Show("You are currently able to roll! You can only select an add after rolling!", "Add", MessageBoxButtons.OK); return; }
            if (Game_Player.Taking_Chance) { MessageBox.Show("You are currently taking a chance and cannot add during chances!", "Add", MessageBoxButtons.OK); return; }

            bool arediceclaimed = false;
            for (int i = 0; i < Total_Dice; i++)
            {
                if (Game_Dice[i].Claimed) { arediceclaimed = true; break; }
            }

            if (!arediceclaimed) { MessageBox.Show("No dice claimed!", "Add", MessageBoxButtons.OK); return; }

            if (Game_Player.Adds > 0)
            {
                DialogResult answer = MessageBox.Show("Do you wish to use an add? If so select yes and choose a combination.", "Add", MessageBoxButtons.YesNo);

                if (answer == DialogResult.Yes)
                {
                    Game_Player.Using_Add = true;
                    Game_Player.Adds -= 1;
                    btnRoll.Enabled = false;
                    btnClaim.Enabled = true;
                    btnEndTurn.Enabled = false;
                    btnAdd.Enabled = false;
                    Game_Player.Current_Turn_Score -= Game_Player.Current_Roll_Score;
                    Game_Player.Current_Roll_Score = 0;
                    lblProjectedScore.Text = "Projected Score: " + (Game_Player.Total_Score + Game_Player.Current_Turn_Score);
                    lblTurnScore.Text = "Turn Score: " + Game_Player.Current_Turn_Score;
                    lblAdds.Text = "Adds: " + Game_Player.Adds;
                    ResetDice();
                }
            }
            else
            {
                MessageBox.Show("You have no adds remaining!", "Add", MessageBoxButtons.OK);
                return;
            }
        }

        private void OpenRules()
        {
            Rules rules = new Rules();
            rules.ShowDialog();
        }

        private void OpenHighScores()
        {
            Highscores highscores = new Highscores();
            highscores.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitGame();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenRules();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void Garbage_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeys(e);
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            RollDice();
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            ClaimDice();
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            EndTurn();
        }

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHighScores();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InitAdd();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (debugToolStripMenuItem.Checked)
            {
                btnAdd.Visible = true;
            }
        }
    }
}
