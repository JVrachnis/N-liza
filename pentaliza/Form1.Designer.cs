namespace triliza
{
    partial class Form1
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
            this.ScoreX = new System.Windows.Forms.Label();
            this.ScoreO = new System.Windows.Forms.Label();
            this.currentPlayerOnScreen = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ResetScore = new System.Windows.Forms.Button();
            this.ResetGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScoreX
            // 
            this.ScoreX.Location = new System.Drawing.Point(150, 13);
            this.ScoreX.Name = "ScoreX";
            this.ScoreX.Size = new System.Drawing.Size(142, 13);
            this.ScoreX.TabIndex = 0;
            this.ScoreX.Text = "Score X:0";
            // 
            // ScoreO
            // 
            this.ScoreO.Location = new System.Drawing.Point(150, 0);
            this.ScoreO.Name = "ScoreO";
            this.ScoreO.Size = new System.Drawing.Size(142, 13);
            this.ScoreO.TabIndex = 1;
            this.ScoreO.Text = "Score O:0";
            // 
            // currentPlayerOnScreen
            // 
            this.currentPlayerOnScreen.AutoSize = true;
            this.currentPlayerOnScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.currentPlayerOnScreen.Location = new System.Drawing.Point(2, 0);
            this.currentPlayerOnScreen.Name = "currentPlayerOnScreen";
            this.currentPlayerOnScreen.Size = new System.Drawing.Size(25, 24);
            this.currentPlayerOnScreen.TabIndex = 2;
            this.currentPlayerOnScreen.Text = "Ο";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(36, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(52, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "O bot";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(93, 0);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(51, 17);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "X bot";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(129, 128);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // ResetScore
            // 
            this.ResetScore.Location = new System.Drawing.Point(122, 29);
            this.ResetScore.Name = "ResetScore";
            this.ResetScore.Size = new System.Drawing.Size(75, 23);
            this.ResetScore.TabIndex = 6;
            this.ResetScore.Text = "Reset Score";
            this.ResetScore.UseVisualStyleBackColor = true;
            this.ResetScore.Click += new System.EventHandler(this.ResetScore_Click);
            // 
            // ResetGame
            // 
            this.ResetGame.Location = new System.Drawing.Point(207, 29);
            this.ResetGame.Name = "ResetGame";
            this.ResetGame.Size = new System.Drawing.Size(75, 23);
            this.ResetGame.TabIndex = 7;
            this.ResetGame.Text = "Reset Game";
            this.ResetGame.UseVisualStyleBackColor = true;
            this.ResetGame.Click += new System.EventHandler(this.ResetGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 285);
            this.Controls.Add(this.ResetGame);
            this.Controls.Add(this.ResetScore);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.currentPlayerOnScreen);
            this.Controls.Add(this.ScoreO);
            this.Controls.Add(this.ScoreX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScoreX;
        private System.Windows.Forms.Label ScoreO;
        private System.Windows.Forms.Label currentPlayerOnScreen;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ResetScore;
        private System.Windows.Forms.Button ResetGame;
    }
}

