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
namespace triliza
{
    
    public partial class Form1 : Form
    {

        static Size board2DSize = new Size(3,3);
        ColoredSymbol[] symbols = {new ColoredSymbol('O',Color.Green), new ColoredSymbol('X', Color.Red) };
        int currentPlayer = 0;
        Bot[] bot = { new MinMaxBot() , new MinMaxBot() };
        int[,] boardInt =new int[board2DSize.Width, board2DSize.Height];
        int[] score = {0,0 };
        Button[,] ButtonBoard = new Button[board2DSize.Width, board2DSize.Height];
        bool[] usingBot = { false , false };
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.Size = new Size(35* (ButtonBoard.GetLength(0)+1), 35 * (ButtonBoard.GetLength(1)+1));
            InitializeBoardArray();
            currentPlayerOnScreen.Text = symbols[currentPlayer].SymbolS;
            currentPlayerOnScreen.ForeColor = symbols[currentPlayer].Color;
        }
        private void InitializeBoardArray()
        {
            for (int i=0;i< boardInt.GetLength(0); i++)
            {
                for (int j = 0; j < boardInt.GetLength(1); j++)
                {
                    
                    ButtonBoard[i, j] = new Button();

                    ButtonBoard[i,j].Location = new System.Drawing.Point(35*i, 35*j);
                    ButtonBoard[i, j].Name = "/"+i+"/"+j;
                    ButtonBoard[i, j].Size = new System.Drawing.Size(30, 30);
                    ButtonBoard[i, j].TabIndex = 0;
                    ButtonBoard[i, j].UseVisualStyleBackColor = true;
                    ButtonBoard[i, j].Text = "";
                    ButtonBoard[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
                    ButtonBoard[i, j].Click += new System.EventHandler(possitionClicked);
                    flowLayoutPanel1.Controls.Add(ButtonBoard[i, j]);
                    boardInt[i, j] = 3;
                }
            }
        }
        private void ReInitializeBoardArray()
        {
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                for (int j = 0; j < boardInt.GetLength(1); j++)
                {
                    ButtonBoard[i, j].Name = "/" + i + "/" + j;
                    ButtonBoard[i, j].Text = "";
                    boardInt[i, j] = 3;
                }
            }
        }
        private void nextTurn()
        {
            if (currentPlayer==0)
            {
                currentPlayer = 1;
            }
            else
            {
                currentPlayer = 0;
            }
            currentPlayerOnScreen.Text = symbols[currentPlayer].SymbolS;
            currentPlayerOnScreen.ForeColor= symbols[currentPlayer].Color;
            playBotIfPossible();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void possitionClicked(object sender, EventArgs e)
        {
            Button possition = (Button)sender;
            string[] test = possition.Name.Split('/');
            int x=int.Parse(test[1]), y = int.Parse(test[2]);
            if (boardInt[x, y] ==3)
            {
                possitionPlayed(x,y);
            }
        }
        private void possitionPlayed(int x,int y)
        {
            ButtonBoard[x,y].Text = symbols[currentPlayer].SymbolS;
            ButtonBoard[x,y].ForeColor = symbols[currentPlayer].Color;
            boardInt[x, y] = currentPlayer;
            outPutStateToCVS();
            outPutMoveToCVS(x, y, currentPlayer);
            if (checkWin(x,y))
            {
                victory();
            }
            if (checkdraw())
            {
                draw();
            }
            nextTurn();
        }
        private void draw()
        {
            DialogResult dialogResult = MessageBox.Show("continue?", "Draw", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                usingBot[0] = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                usingBot[0] = false;
            }
            ReInitializeBoardArray();
        }
        private bool checkdraw()
        {
            foreach (int i in boardInt)
            {
                if (i==3)
                {
                    return false;
                }
            }
            return true;
        }
        private void victory()
        {
            DialogResult dialogResult = MessageBox.Show("continue?", "Winner: " + symbols[currentPlayer].SymbolS, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                usingBot[0] =false;
                usingBot[0] = false;
            }
            score[currentPlayer]++;
            updateScore();
            ReInitializeBoardArray();
        }
        private void updateScore()
        {
            ScoreX.Text = "Score X:" + score[1];
            ScoreO.Text = "Score O:" + score[0];
        }
        private bool checkWin(int x, int y)
        {
            bool[] Win = {true, true, true, true };
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                if (ButtonBoard[i, y].Text != symbols[currentPlayer].SymbolS)
                {
                    Win[0] = false;
                }
                if (ButtonBoard[x, i].Text != symbols[currentPlayer].SymbolS)
                {
                    Win[1] = false;
                }
                if (ButtonBoard[i, i].Text != symbols[currentPlayer].SymbolS)
                {
                    Win[2] = false;
                }
                if (ButtonBoard[boardInt.GetLength(0)-1 - i, i].Text != symbols[currentPlayer].SymbolS)
                {
                    Win[3] = false;
                }
            }

            return Win.Contains(true);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            usingBot[0] = checkBox1.Checked;
            playBotIfPossible();
        }
        private void playBotIfPossible()
        {
            if (usingBot[currentPlayer])
            {
                Point p = bot[currentPlayer].CalculateMove(boardInt, currentPlayer);
                possitionPlayed(p.X, p.Y);
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            usingBot[1] = checkBox2.Checked;
            playBotIfPossible();
        }

        private void ResetScore_Click(object sender, EventArgs e)
        {
            score[0] = 0;
            score[1] = 0;
            updateScore();
        }

        private void ResetGame_Click(object sender, EventArgs e)
        {
            ReInitializeBoardArray();
            score[0] = 0;
            score[1] = 0;
            updateScore();
        }
        
        private void outPutStateToCVS()
        {
            int[] board1D = new int[boardInt.GetLength(0)*boardInt.GetLength(1)];
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                for (int j = 0; j < boardInt.GetLength(1); j++)
                {
                    board1D[i * boardInt.GetLength(0)+ j] = translateInt(boardInt[i,j]);
                }
            }
            writeToCSV(board1D, ".\\state" + boardInt.GetLength(0) + "X" + boardInt.GetLength(1) + ".csv");
        }
        private void outPutMoveToCVS(int x,int y,int player)
        {
            int[] board1D = new int[boardInt.GetLength(0) * boardInt.GetLength(1)];
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                for (int j = 0; j < boardInt.GetLength(1); j++)
                {
                    board1D[i * boardInt.GetLength(0)+ j] = 0;
                }
            }
            board1D[x * y] = translateInt(player);
            writeToCSV(board1D, ".\\move"+ boardInt.GetLength(0) + "X"+ boardInt.GetLength(1) + ".csv");
        }
        private void writeToCSV(int[] board, string path)
        {

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    writeIntToCSV(sw, board);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    writeIntToCSV(sw, board);
                }
            }
        }
        private void writeIntToCSV(StreamWriter sw, int[] board)
        {
            sw.WriteLine(string.Join(",", board));
        }
        private int translateInt(int i)
        {
            if (i==0)
            {
                return -1;
            }else if(i==3){
                return 0;
            }
            return i;
        }
    }
}
