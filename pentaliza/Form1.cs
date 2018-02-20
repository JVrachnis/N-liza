using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using Bots;
using Coloredsymbol;
using nliza;
using player;
namespace triliza
{
    public partial class Form1 : Form
    {
        static int size = 5;
        static ColoredSymbol[] symbols = { new ColoredSymbol('O', Color.Green), new ColoredSymbol('X', Color.Red) };
        static int[] score = { 0, 0 };
        static Button[,] ButtonBoard;
        Nliza N3liza;
        bool autoMoveBots = true;
        void outPut(Nliza.OutCome outCome)//funcion to use as output halder of N3liza
        {
            if (outCome.succesfull)
            {
                ButtonBoard[outCome.pointplayed.X, outCome.pointplayed.Y].Text = symbols[parseID(outCome.player.id)].SymbolS;
                ButtonBoard[outCome.pointplayed.X, outCome.pointplayed.Y].ForeColor = symbols[parseID(outCome.player.id)].Color;
                N3liza.nextTurn();
                changeCurrentPlayerOnScreen(parseID(N3liza.currentPlayer.id));
                if (outCome.victory)
                {
                    victory(parseID(outCome.player.id));
                    return;
                }
                else
                if (outCome.ended)
                {
                    draw();
                    return;
                }
                if (N3liza.currentPlayer.GetType() != typeof(player.Human)&& autoMoveBots)
                {
                    N3liza.play();
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            N3liza = new Nliza(size, 1, 7, -1, 7, 0, 1, outPut);
            initializeUserSelection();
            InitializeBoardArray();
            NextStep.Hide();
            AutoPlayBot.Checked = true;
            changeCurrentPlayerOnScreen(parseID(N3liza.currentPlayer.id));
            if (N3liza.currentPlayer.GetType() != typeof(player.Human) && autoMoveBots)
            {
                N3liza.play();
            }
        }
        private void initializeUserSelection()//initialize the UserSelection
        {
            UserO.Items.Add("Easyest");
            UserO.Items.Add("Easyer");
            UserO.Items.Add("Easy");
            UserO.Items.Add("Normal");
            UserO.Items.Add("Hard");
            UserO.Items.Add("Harder");
            UserO.Items.Add("Hardest");
            UserO.Items.Add("Human");
            UserO.SelectedIndex = 7;
            UserX.Items.Add("Easyest");
            UserX.Items.Add("Easyer");
            UserX.Items.Add("Easy");
            UserX.Items.Add("Normal");
            UserX.Items.Add("Hard");
            UserX.Items.Add("Harder");
            UserX.Items.Add("Hardest");
            UserX.Items.Add("Human");
            UserX.SelectedIndex = 7;
        }
        private int parseID(int id)//parsing the id of a player to mean there position in a list
        {
            if (N3liza.players[1].id==id)
            {
                return 1;
            }
            return 0;
        }
        private void InitializeBoardArray()//initialize the array of buttons
        {
            ButtonBoard = new Button[size, size];
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Size = new Size(50 * (size), 50 * (size));
            N3liza = new Nliza(size, 1, UserO.SelectedIndex, -1, UserX.SelectedIndex, 0, 1, outPut);
            for (int i = 0; i < ButtonBoard.GetLength(0); i++)
            {
                for (int j = 0; j < ButtonBoard.GetLength(1); j++)
                {

                    ButtonBoard[i, j] = new Button();

                    ButtonBoard[i, j].Location = new System.Drawing.Point(35 * i, 35 * j);
                    ButtonBoard[i, j].Name = "/" + i + "/" + j;
                    ButtonBoard[i, j].Size = new System.Drawing.Size(50, 50);
                    ButtonBoard[i, j].TabIndex = 0;
                    ButtonBoard[i, j].Margin = new System.Windows.Forms.Padding(0);
                    ButtonBoard[i, j].UseVisualStyleBackColor = true;
                    ButtonBoard[i, j].Text = "";
                    ButtonBoard[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 27.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
                    ButtonBoard[i, j].Click += new System.EventHandler(possitionClicked);
                    flowLayoutPanel1.Controls.Add(ButtonBoard[i, j]);
                }
            }
            
        }
        private void ReInitializeBoardArray()//restart the button array ,the N3liza , the displaed player, and plays the N3liza if the player is bot
        {
            if (ButtonBoard!=null) {
                for (int i = 0; i < ButtonBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < ButtonBoard.GetLength(1); j++)
                    {
                        ButtonBoard[i, j].Name = "/" + i + "/" + j;
                        ButtonBoard[i, j].Text = "";
                    }
                }
                N3liza.initializetion();
                changeCurrentPlayerOnScreen(parseID(N3liza.currentPlayer.id));
                if (N3liza.currentPlayer.GetType() != typeof(player.Human) && autoMoveBots)
                {
                    N3liza.play();
                }
            }
        }
        private void possitionClicked(object sender, EventArgs e)//a fuction that hadles the clicked button array
        {
            Button possition = (Button)sender;
            string[] test = possition.Name.Split('/');
            int x = int.Parse(test[1]), y = int.Parse(test[2]);
            if (N3liza.boardInt[x, y] == N3liza.empty)
            {
                N3liza.play(new Point(x, y));
            }
        }
        private void draw()//a fuction that hadles the draw outcome
        {
            DialogResult dialogResult = MessageBox.Show("continue?", "Draw", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                AutoPlayBot.Checked = false;
            }
            ReInitializeBoardArray();
        }
        private void victory(int currentPlayer)//a fuction that hadles the victory outcome
        {
            DialogResult dialogResult = MessageBox.Show("continue?", "Winner: " + symbols[currentPlayer].SymbolS, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                autoMoveBots = false;
                AutoPlayBot.Checked = false;
            }
            score[currentPlayer]++;
            updateScore();
            ReInitializeBoardArray();
        }
        private void updateScore()//updates the displaed score
        {
            ScoreX.Text = "Score X:" + score[1];
            ScoreO.Text = "Score O:" + score[0];
        }
        private void ResetScore_Click(object sender, EventArgs e)//it resets the score
        {
            score[0] = 0;
            score[1] = 0;
            updateScore();
        }
        private void ResetGame_Click(object sender, EventArgs e)//it restarts the game
        {
            resetGame();
        }
        private void resetGame()
        {
            N3liza.Restart();
            ReInitializeBoardArray();
            score[0] = 0;
            score[1] = 0;
            updateScore();
        }
        private void UserO_SelectedItemChanged(object sender, EventArgs e)//it handles the changes of player O
        {
            autoMoveBots = false;
            AutoPlayBot.Checked = false;
            int i = UserO.SelectedIndex;
            if (i>=0) {
                N3liza.changePlayerType(0, i);
            }
            resetGame();
        }
        private void UserX_SelectedItemChanged(object sender, EventArgs e)//it handles the changes of player X (changes the player type)
        {
            autoMoveBots = false;
            AutoPlayBot.Checked = false;
            int i = UserX.SelectedIndex;
            if (i >= 0)
            {
                N3liza.changePlayerType(1, i);
            }
            resetGame();
        }
        private void AutoPlayBot_CheckedChanged(object sender, EventArgs e)//it handles the changes of autoplay for the bot (if it is posible playes playes the bot)
        {
            autoMoveBots = AutoPlayBot.Checked;
            if (AutoPlayBot.Checked)
            {
                NextStep.Hide();
            }
            else
            {
                NextStep.Show();
            }
            if (N3liza.currentPlayer.GetType() != typeof(player.Human) && autoMoveBots)
            {
                N3liza.play();
            }
        }
        private void NextStep_Click(object sender, EventArgs e)//it playes the bot it AutoPlayBot isnt on
        {
            if (!autoMoveBots)
            {
                N3liza.play();
            }
        }
        private void currentPlayerOnScreen_Click(object sender, EventArgs e)
        {
            N3liza.nextTurn();
            
            changeCurrentPlayerOnScreen(parseID(N3liza.currentPlayer.id));
            if (autoMoveBots)
            {
                N3liza.play();
            }
        }
        private void changeCurrentPlayerOnScreen(int index)
        {
            currentPlayerOnScreen.Text = symbols[index].SymbolS;
            currentPlayerOnScreen.ForeColor = symbols[index].Color;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)//it handles the changes of numericUpDown1 (changes the board size and restarts the game)
        {
            size = (int)numericUpDown1.Value;
            InitializeBoardArray();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
