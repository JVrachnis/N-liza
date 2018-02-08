using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using player;
using Bots;
namespace nliza
{
    class Nliza
    {
        public Player[] players = { PFactory.Get(4,1,-1,0), PFactory.Get(4, -1, 1, 0) };
        public Player currentPlayer;
        public int empty = 3;
        public int BoardSize = 3;
        public int movesAvelable =9;
        public Size board2DSize;
        public int[,] boardInt;
        public int[] score = { 0, 0 };
        public int startingPlayer;
        //int maxDifficulty;
        public void changePlayerType(int player,int type)
        {
            if(currentPlayer== players[player])
            {
                currentPlayer= PFactory.Get(type, players[player].id, players[player].enemyId, players[player].emptyId);
            }
            players[player] = PFactory.Get(type, players[player].id, players[player].enemyId, players[player].emptyId);
        }
        public struct OutCome
        {
            public Player player;
            public Point pointplayed;
            public int[,] boardState;
            public bool victory;
            public bool ended;
            public bool succesfull;
            public OutCome(Player player,
            int[,] boardState,
            bool victory,
            bool ended,
            bool succesfull,
            Point pointplayed)
            {
                this.pointplayed = pointplayed;
                this.succesfull = succesfull;
                this.player = player;
                this.boardState = boardState;
                this.victory = victory;
                this.ended = ended;
            }
        }
        
        public delegate void OutPut(OutCome outCome);
        OutPut output;
        public Nliza(int BoardSize, int playerID1, int player1Type, int playerID2, int player2Type, int empty, int startingPlayer, OutPut output)
        {
            this.BoardSize = BoardSize;
            this.empty = empty;
            this.output = output;
            players[0] = PFactory.Get(player1Type,playerID1,playerID2,empty);
            players[1] = PFactory.Get(player2Type, playerID2, playerID1, empty);
            this.startingPlayer = startingPlayer;
            if (startingPlayer == players[1].id)
            {
                currentPlayer = players[1];
            }
            else
            {
                currentPlayer = players[0];
            }
            checkData();
            initializetion();
        }
        private void checkData()
        {
            if (players[0].id == players[1].id|| players[0].id==empty|| players[1].id==empty)
            {
                throw new System.ArgumentException("data error", "original");
            }
        }
        public void initializetion()
        {
            board2DSize = new Size(BoardSize, BoardSize);
            boardInt = new int[board2DSize.Width, board2DSize.Height];
            movesAvelable = boardInt.Length;
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                for (int j = 0; j < boardInt.GetLength(1); j++)
                {
                    boardInt[i, j] = empty;
                }
            }
            
        }
        public void nextTurn()
        {
            if (currentPlayer == players[0])
            {
                currentPlayer = players[1];
            }
            else
            {
                currentPlayer = players[0];
            }
        }
        public int Emeny(int player)
        {
            if (player == players[0].id)
            {
                return players[1].id;
            }
            else
            {
                return players[0].id;
            }
        }
        public void play()
        {
            if (currentPlayer.GetType() != typeof(player.Human))
            {
                playPossitionIfEmpty(((Bot)currentPlayer).CalculateMove(boardInt));
            }
        }
        public void play(Point pointPlayed)
        {
            if (currentPlayer.GetType()==typeof(Human))
            {
                playPossitionIfEmpty(pointPlayed);
            }
            else
            {
                playPossitionIfEmpty(((Bot)currentPlayer).CalculateMove(boardInt));
            }
            
        }
        private void playPossitionIfEmpty(Point pointPlayed)
        {
            bool sucessfull=true;
            OutCome outCome = new OutCome();
            int x = pointPlayed.X, y = pointPlayed.Y;
            if (x<0||y<0||x>BoardSize|| y > BoardSize)
            {
                sucessfull = false;
            }
            if (boardInt[x, y] !=empty)
            {
                sucessfull = false;
            }
            movesAvelable--;
            boardInt[x, y] = currentPlayer.id;
            outCome = new OutCome(currentPlayer, boardInt, false, false,false, pointPlayed);
            if (checkWin(x, y))
            {
                outCome.victory = true;
                outCome.ended = true;
            }
            if (checkdraw())
            {
                outCome.ended = true;
            }
            sucessfull = true;
            outCome.succesfull = sucessfull;
            output(outCome);
        }
        public void Restart()
        {
            if (startingPlayer == players[1].id)
            {
                currentPlayer = players[1];
            }
            else
            {
                currentPlayer = players[0];
            }
            initializetion();
        }
        public bool checkdraw()
        {
            return movesAvelable == 0;
        }
        private bool checkWin(int x, int y)
        {
            bool[] Win = { true, true, true, true };
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                if (boardInt[i, y] != currentPlayer.id)
                {
                    Win[0] = false;
                }
                if (boardInt[x, i] != currentPlayer.id)
                {
                    Win[1] = false;
                }
                if (boardInt[i, i] != currentPlayer.id)
                {
                    Win[2] = false;
                }
                if (boardInt[boardInt.GetLength(0) - 1 - i, i] != currentPlayer.id)
                {
                    Win[3] = false;
                }
            }

            return Win.Contains(true);
        }
    }
}
