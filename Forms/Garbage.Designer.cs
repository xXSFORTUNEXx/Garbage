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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpCombinations = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.lblTurnScore = new System.Windows.Forms.Label();
            this.lblProjectedScore = new System.Windows.Forms.Label();
            this.lblAdds = new System.Windows.Forms.Label();
            this.lblChancesTaken = new System.Windows.Forms.Label();
            this.grpPlayerCard = new System.Windows.Forms.GroupBox();
            this.lblHotDice = new System.Windows.Forms.Label();
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnClaim = new System.Windows.Forms.Button();
            this.btnChance = new System.Windows.Forms.Button();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.mnuMain.SuspendLayout();
            this.grpPlayerCard.SuspendLayout();
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
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
            this.lblName.Location = new System.Drawing.Point(26, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name: None";
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Location = new System.Drawing.Point(26, 50);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(74, 13);
            this.lblTotalScore.TabIndex = 1;
            this.lblTotalScore.Text = "Total Score: 0";
            // 
            // lblTurnScore
            // 
            this.lblTurnScore.AutoSize = true;
            this.lblTurnScore.Location = new System.Drawing.Point(26, 73);
            this.lblTurnScore.Name = "lblTurnScore";
            this.lblTurnScore.Size = new System.Drawing.Size(72, 13);
            this.lblTurnScore.TabIndex = 2;
            this.lblTurnScore.Text = "Turn Score: 0";
            // 
            // lblProjectedScore
            // 
            this.lblProjectedScore.AutoSize = true;
            this.lblProjectedScore.Location = new System.Drawing.Point(26, 96);
            this.lblProjectedScore.Name = "lblProjectedScore";
            this.lblProjectedScore.Size = new System.Drawing.Size(95, 13);
            this.lblProjectedScore.TabIndex = 3;
            this.lblProjectedScore.Text = "Projected Score: 0";
            // 
            // lblAdds
            // 
            this.lblAdds.AutoSize = true;
            this.lblAdds.Location = new System.Drawing.Point(26, 119);
            this.lblAdds.Name = "lblAdds";
            this.lblAdds.Size = new System.Drawing.Size(96, 13);
            this.lblAdds.TabIndex = 4;
            this.lblAdds.Text = "Remaining Adds: 0";
            // 
            // lblChancesTaken
            // 
            this.lblChancesTaken.AutoSize = true;
            this.lblChancesTaken.Location = new System.Drawing.Point(26, 142);
            this.lblChancesTaken.Name = "lblChancesTaken";
            this.lblChancesTaken.Size = new System.Drawing.Size(143, 13);
            this.lblChancesTaken.TabIndex = 5;
            this.lblChancesTaken.Text = "Chances Taken This Turn: 0";
            // 
            // grpPlayerCard
            // 
            this.grpPlayerCard.Controls.Add(this.lblHotDice);
            this.grpPlayerCard.Controls.Add(this.lblChancesTaken);
            this.grpPlayerCard.Controls.Add(this.lblAdds);
            this.grpPlayerCard.Controls.Add(this.lblProjectedScore);
            this.grpPlayerCard.Controls.Add(this.lblTurnScore);
            this.grpPlayerCard.Controls.Add(this.lblTotalScore);
            this.grpPlayerCard.Controls.Add(this.lblName);
            this.grpPlayerCard.Location = new System.Drawing.Point(12, 255);
            this.grpPlayerCard.Name = "grpPlayerCard";
            this.grpPlayerCard.Size = new System.Drawing.Size(312, 178);
            this.grpPlayerCard.TabIndex = 8;
            this.grpPlayerCard.TabStop = false;
            this.grpPlayerCard.Text = "Player Card";
            // 
            // lblHotDice
            // 
            this.lblHotDice.AutoSize = true;
            this.lblHotDice.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotDice.ForeColor = System.Drawing.Color.Red;
            this.lblHotDice.Location = new System.Drawing.Point(181, 16);
            this.lblHotDice.Name = "lblHotDice";
            this.lblHotDice.Size = new System.Drawing.Size(125, 37);
            this.lblHotDice.TabIndex = 28;
            this.lblHotDice.Text = "Hot Dice!";
            this.lblHotDice.Visible = false;
            // 
            // btnRoll
            // 
            this.btnRoll.Enabled = false;
            this.btnRoll.Location = new System.Drawing.Point(12, 439);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(144, 23);
            this.btnRoll.TabIndex = 9;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // btnClaim
            // 
            this.btnClaim.Enabled = false;
            this.btnClaim.Location = new System.Drawing.Point(12, 468);
            this.btnClaim.Name = "btnClaim";
            this.btnClaim.Size = new System.Drawing.Size(144, 23);
            this.btnClaim.TabIndex = 10;
            this.btnClaim.Text = "Claim Dice";
            this.btnClaim.UseVisualStyleBackColor = true;
            this.btnClaim.Click += new System.EventHandler(this.btnClaim_Click);
            // 
            // btnChance
            // 
            this.btnChance.Enabled = false;
            this.btnChance.Location = new System.Drawing.Point(180, 569);
            this.btnChance.Name = "btnChance";
            this.btnChance.Size = new System.Drawing.Size(144, 23);
            this.btnChance.TabIndex = 27;
            this.btnChance.Text = "Chance";
            this.btnChance.UseVisualStyleBackColor = true;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Enabled = false;
            this.btnEndTurn.Location = new System.Drawing.Point(180, 598);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(144, 23);
            this.btnEndTurn.TabIndex = 26;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // Garbage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 636);
            this.ControlBox = false;
            this.Controls.Add(this.btnChance);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.btnClaim);
            this.Controls.Add(this.btnRoll);
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
        private System.Windows.Forms.Label lblAdds;
        private System.Windows.Forms.Label lblChancesTaken;
        private System.Windows.Forms.GroupBox grpPlayerCard;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnClaim;
        private System.Windows.Forms.Button btnChance;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Label lblHotDice;
    }
}

