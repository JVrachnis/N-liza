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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ScoreX = new System.Windows.Forms.Label();
            this.ScoreO = new System.Windows.Forms.Label();
            this.currentPlayerOnScreen = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ResetScore = new System.Windows.Forms.Button();
            this.ResetGame = new System.Windows.Forms.Button();
            this.UserO = new System.Windows.Forms.DomainUpDown();
            this.UserX = new System.Windows.Forms.DomainUpDown();
            this.AutoPlayBot = new System.Windows.Forms.CheckBox();
            this.NextStep = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreX
            // 
            this.ScoreX.Location = new System.Drawing.Point(109, 97);
            this.ScoreX.Name = "ScoreX";
            this.ScoreX.Size = new System.Drawing.Size(94, 13);
            this.ScoreX.TabIndex = 0;
            this.ScoreX.Text = "Score X:0";
            // 
            // ScoreO
            // 
            this.ScoreO.Location = new System.Drawing.Point(3, 97);
            this.ScoreO.Name = "ScoreO";
            this.ScoreO.Size = new System.Drawing.Size(94, 13);
            this.ScoreO.TabIndex = 1;
            this.ScoreO.Text = "Score O:0";
            // 
            // currentPlayerOnScreen
            // 
            this.currentPlayerOnScreen.AutoSize = true;
            this.currentPlayerOnScreen.BackColor = System.Drawing.Color.Transparent;
            this.currentPlayerOnScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.currentPlayerOnScreen.Location = new System.Drawing.Point(188, 49);
            this.currentPlayerOnScreen.Name = "currentPlayerOnScreen";
            this.currentPlayerOnScreen.Size = new System.Drawing.Size(68, 61);
            this.currentPlayerOnScreen.TabIndex = 4;
            this.currentPlayerOnScreen.Text = "Ο";
            this.currentPlayerOnScreen.Click += new System.EventHandler(this.currentPlayerOnScreen_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 113);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(129, 128);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // ResetScore
            // 
            this.ResetScore.Location = new System.Drawing.Point(181, 3);
            this.ResetScore.Name = "ResetScore";
            this.ResetScore.Size = new System.Drawing.Size(75, 23);
            this.ResetScore.TabIndex = 6;
            this.ResetScore.Text = "Reset Score";
            this.ResetScore.UseVisualStyleBackColor = true;
            this.ResetScore.Click += new System.EventHandler(this.ResetScore_Click);
            // 
            // ResetGame
            // 
            this.ResetGame.Location = new System.Drawing.Point(100, 3);
            this.ResetGame.Name = "ResetGame";
            this.ResetGame.Size = new System.Drawing.Size(75, 23);
            this.ResetGame.TabIndex = 7;
            this.ResetGame.Text = "Reset Game";
            this.ResetGame.UseVisualStyleBackColor = true;
            this.ResetGame.Click += new System.EventHandler(this.ResetGame_Click);
            // 
            // UserO
            // 
            this.UserO.Location = new System.Drawing.Point(6, 29);
            this.UserO.Name = "UserO";
            this.UserO.ReadOnly = true;
            this.UserO.Size = new System.Drawing.Size(73, 20);
            this.UserO.TabIndex = 8;
            this.UserO.Text = "Select O";
            this.UserO.SelectedItemChanged += new System.EventHandler(this.UserO_SelectedItemChanged);
            // 
            // UserX
            // 
            this.UserX.Location = new System.Drawing.Point(181, 29);
            this.UserX.Name = "UserX";
            this.UserX.ReadOnly = true;
            this.UserX.Size = new System.Drawing.Size(73, 20);
            this.UserX.TabIndex = 9;
            this.UserX.Text = "Select X";
            this.UserX.SelectedItemChanged += new System.EventHandler(this.UserX_SelectedItemChanged);
            // 
            // AutoPlayBot
            // 
            this.AutoPlayBot.AutoSize = true;
            this.AutoPlayBot.Location = new System.Drawing.Point(85, 32);
            this.AutoPlayBot.Name = "AutoPlayBot";
            this.AutoPlayBot.Size = new System.Drawing.Size(90, 17);
            this.AutoPlayBot.TabIndex = 13;
            this.AutoPlayBot.Text = "Auto Play Bot";
            this.AutoPlayBot.UseVisualStyleBackColor = true;
            this.AutoPlayBot.CheckedChanged += new System.EventHandler(this.AutoPlayBot_CheckedChanged);
            // 
            // NextStep
            // 
            this.NextStep.Location = new System.Drawing.Point(101, 55);
            this.NextStep.Name = "NextStep";
            this.NextStep.Size = new System.Drawing.Size(63, 23);
            this.NextStep.TabIndex = 14;
            this.NextStep.Text = "Play bot";
            this.NextStep.UseVisualStyleBackColor = true;
            this.NextStep.Visible = false;
            this.NextStep.Click += new System.EventHandler(this.NextStep_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(57, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Grid Size:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(261, 285);
            this.Controls.Add(this.currentPlayerOnScreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.AutoPlayBot);
            this.Controls.Add(this.NextStep);
            this.Controls.Add(this.UserX);
            this.Controls.Add(this.UserO);
            this.Controls.Add(this.ResetGame);
            this.Controls.Add(this.ResetScore);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ScoreO);
            this.Controls.Add(this.ScoreX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nliza";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScoreX;
        private System.Windows.Forms.Label ScoreO;
        private System.Windows.Forms.Label currentPlayerOnScreen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ResetScore;
        private System.Windows.Forms.Button ResetGame;
        private System.Windows.Forms.DomainUpDown UserO;
        private System.Windows.Forms.DomainUpDown UserX;
        private System.Windows.Forms.CheckBox AutoPlayBot;
        private System.Windows.Forms.Button NextStep;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}

