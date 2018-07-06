namespace Garbage
{
    partial class Highscores
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
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.lblHighscores = new System.Windows.Forms.Label();
            this.grpTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.lblHighscores);
            this.grpTop.Location = new System.Drawing.Point(13, 13);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(227, 259);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            this.grpTop.Text = "Top 5 Highscores";
            // 
            // lblHighscores
            // 
            this.lblHighscores.AutoSize = true;
            this.lblHighscores.Location = new System.Drawing.Point(18, 31);
            this.lblHighscores.Name = "lblHighscores";
            this.lblHighscores.Size = new System.Drawing.Size(56, 117);
            this.lblHighscores.TabIndex = 0;
            this.lblHighscores.Text = "1. First\r\n\r\n2. Second\r\n\r\n3. Third\r\n\r\n4. Fourth\r\n\r\n5. Fifth";
            // 
            // Highscores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 292);
            this.Controls.Add(this.grpTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Highscores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Highscores";
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Label lblHighscores;
    }
}