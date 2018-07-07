namespace Garbage
{
    partial class Garbage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highscoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpCombinations = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.lblTurnScore = new System.Windows.Forms.Label();
            this.lblProjectedScore = new System.Windows.Forms.Label();
            this.lblChances = new System.Windows.Forms.Label();
            this.lblCurrentTurn = new System.Windows.Forms.Label();
            this.grpPlayerCard = new System.Windows.Forms.GroupBox();
            this.grpScoreboard = new System.Windows.Forms.GroupBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHotDice = new System.Windows.Forms.Label();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.btnClaim = new System.Windows.Forms.Button();
            this.btnRoll = new System.Windows.Forms.Button();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAdds = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.grpPlayerCard.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(648, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.highscoresToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // highscoresToolStripMenuItem
            // 
            this.highscoresToolStripMenuItem.Name = "highscoresToolStripMenuItem";
            this.highscoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.highscoresToolStripMenuItem.Text = "Highscores";
            this.highscoresToolStripMenuItem.Click += new System.EventHandler(this.highscoresToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // grpCombinations
            // 
            this.grpCombinations.Enabled = false;
            this.grpCombinations.Location = new System.Drawing.Point(330, 43);
            this.grpCombinations.Name = "grpCombinations";
            this.grpCombinations.Size = new System.Drawing.Size(306, 578);
            this.grpCombinations.TabIndex = 1;
            this.grpCombinations.TabStop = false;
            this.grpCombinations.Text = "Combinations";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name: None";
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Location = new System.Drawing.Point(19, 42);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(74, 13);
            this.lblTotalScore.TabIndex = 1;
            this.lblTotalScore.Text = "Total Score: 0";
            // 
            // lblTurnScore
            // 
            this.lblTurnScore.AutoSize = true;
            this.lblTurnScore.Location = new System.Drawing.Point(19, 63);
            this.lblTurnScore.Name = "lblTurnScore";
            this.lblTurnScore.Size = new System.Drawing.Size(72, 13);
            this.lblTurnScore.TabIndex = 2;
            this.lblTurnScore.Text = "Turn Score: 0";
            // 
            // lblProjectedScore
            // 
            this.lblProjectedScore.AutoSize = true;
            this.lblProjectedScore.Location = new System.Drawing.Point(19, 84);
            this.lblProjectedScore.Name = "lblProjectedScore";
            this.lblProjectedScore.Size = new System.Drawing.Size(95, 13);
            this.lblProjectedScore.TabIndex = 3;
            this.lblProjectedScore.Text = "Projected Score: 0";
            // 
            // lblChances
            // 
            this.lblChances.AutoSize = true;
            this.lblChances.Location = new System.Drawing.Point(19, 105);
            this.lblChances.Name = "lblChances";
            this.lblChances.Size = new System.Drawing.Size(109, 13);
            this.lblChances.TabIndex = 4;
            this.lblChances.Text = "Chances This Turn: 0";
            // 
            // lblCurrentTurn
            // 
            this.lblCurrentTurn.AutoSize = true;
            this.lblCurrentTurn.Location = new System.Drawing.Point(19, 127);
            this.lblCurrentTurn.Name = "lblCurrentTurn";
            this.lblCurrentTurn.Size = new System.Drawing.Size(78, 13);
            this.lblCurrentTurn.TabIndex = 5;
            this.lblCurrentTurn.Text = "Current Turn: 1";
            // 
            // grpPlayerCard
            // 
            this.grpPlayerCard.Controls.Add(this.lblAdds);
            this.grpPlayerCard.Controls.Add(this.lblCurrentTurn);
            this.grpPlayerCard.Controls.Add(this.lblChances);
            this.grpPlayerCard.Controls.Add(this.lblProjectedScore);
            this.grpPlayerCard.Controls.Add(this.lblTurnScore);
            this.grpPlayerCard.Controls.Add(this.lblTotalScore);
            this.grpPlayerCard.Controls.Add(this.lblName);
            this.grpPlayerCard.Location = new System.Drawing.Point(12, 255);
            this.grpPlayerCard.Name = "grpPlayerCard";
            this.grpPlayerCard.Size = new System.Drawing.Size(184, 178);
            this.grpPlayerCard.TabIndex = 8;
            this.grpPlayerCard.TabStop = false;
            this.grpPlayerCard.Text = "Player Card";
            // 
            // grpScoreboard
            // 
            this.grpScoreboard.Location = new System.Drawing.Point(12, 440);
            this.grpScoreboard.Name = "grpScoreboard";
            this.grpScoreboard.Size = new System.Drawing.Size(312, 181);
            this.grpScoreboard.TabIndex = 29;
            this.grpScoreboard.TabStop = false;
            this.grpScoreboard.Text = "Scoreboard";
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.btnAdd);
            this.grpOptions.Controls.Add(this.lblHotDice);
            this.grpOptions.Controls.Add(this.btnEndTurn);
            this.grpOptions.Controls.Add(this.btnClaim);
            this.grpOptions.Controls.Add(this.btnRoll);
            this.grpOptions.Location = new System.Drawing.Point(203, 255);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(121, 178);
            this.grpOptions.TabIndex = 30;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(4, 81);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 23);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHotDice
            // 
            this.lblHotDice.AutoSize = true;
            this.lblHotDice.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotDice.ForeColor = System.Drawing.Color.Red;
            this.lblHotDice.Location = new System.Drawing.Point(14, 103);
            this.lblHotDice.Name = "lblHotDice";
            this.lblHotDice.Size = new System.Drawing.Size(92, 29);
            this.lblHotDice.TabIndex = 32;
            this.lblHotDice.Text = "Hot Dice!";
            this.lblHotDice.Visible = false;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Enabled = false;
            this.btnEndTurn.Location = new System.Drawing.Point(4, 135);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(111, 23);
            this.btnEndTurn.TabIndex = 31;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // btnClaim
            // 
            this.btnClaim.Enabled = false;
            this.btnClaim.Location = new System.Drawing.Point(4, 51);
            this.btnClaim.Name = "btnClaim";
            this.btnClaim.Size = new System.Drawing.Size(111, 23);
            this.btnClaim.TabIndex = 30;
            this.btnClaim.Text = "Claim Dice";
            this.btnClaim.UseVisualStyleBackColor = true;
            this.btnClaim.Click += new System.EventHandler(this.btnClaim_Click);
            // 
            // btnRoll
            // 
            this.btnRoll.Enabled = false;
            this.btnRoll.Location = new System.Drawing.Point(4, 22);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(111, 23);
            this.btnRoll.TabIndex = 29;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.CheckOnClick = true;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // lblAdds
            // 
            this.lblAdds.AutoSize = true;
            this.lblAdds.Location = new System.Drawing.Point(19, 146);
            this.lblAdds.Name = "lblAdds";
            this.lblAdds.Size = new System.Drawing.Size(43, 13);
            this.lblAdds.TabIndex = 6;
            this.lblAdds.Text = "Adds: 2";
            // 
            // Garbage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 636);
            this.ControlBox = false;
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpScoreboard);
            this.Controls.Add(this.grpPlayerCard);
            this.Controls.Add(this.grpCombinations);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "Garbage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garbage";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Garbage_KeyDown);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.grpPlayerCard.ResumeLayout(false);
            this.grpPlayerCard.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpCombinations;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTotalScore;
        private System.Windows.Forms.Label lblTurnScore;
        private System.Windows.Forms.Label lblProjectedScore;
        private System.Windows.Forms.Label lblChances;
        private System.Windows.Forms.Label lblCurrentTurn;
        private System.Windows.Forms.GroupBox grpPlayerCard;
        private System.Windows.Forms.GroupBox grpScoreboard;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label lblHotDice;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Button btnClaim;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.ToolStripMenuItem highscoresToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.Label lblAdds;
    }
}

