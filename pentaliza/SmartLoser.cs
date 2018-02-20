using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bots
{
    class SmartLoser:Bot//same us smartBot but returns the worst move
    {
        public SmartLoser(int ID, int EnemyId, int EmptyId)
        {
            id = ID;
            enemyId = EnemyId;
            emptyId = EmptyId;
        }
        override public Point CalculateMove(int[,] Board)
        {
            int Player = id;
            Move move;
            List<Move> moves = new List<Move>();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == emptyId)
                    {
                        move = new Move(Board, new Point(i, j), Player);
                        if (checkWin(move))
                        {
                            return move.location;
                        }
                        move.score = CloseToWinScore(move);

                        moves.Add(move);
                    }
                }
            }
            return BestMove(moves).location;
        }
        public double CloseToWinScore(Move move)
        {
            int win = 100, empty = 3, enemyOccupied = 4;
            int Player = move.Player;
            int deapth = move.deapth;
            int[,] boardInt = move.Board;
            int x = move.location.X, y = move.location.Y;
            double[] Win = { 0, 0, 0, 0 };
            int rank = boardInt.GetLength(0) * boardInt.GetLength(1) - deapth + 1;
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                if (i != x)
                {
                    if (boardInt[i, y] == Player)
                    {
                        Win[0] += win;
                    }
                    else if (boardInt[i, y] == nextTurn(Player))
                    {
                        Win[0] += enemyOccupied * 2;
                    }
                    else
                    {
                        Win[0] += empty;
                    }
                }
                if (i != y)
                {
                    if (boardInt[x, i] == Player)
                    {
                        Win[1] += win;
                    }
                    else if (boardInt[x, i] == nextTurn(Player))
                    {
                        Win[1] += enemyOccupied * 2;
                    }
                    else
                    {
                        Win[1] += empty;
                    }
                }
                if (i != y && x == y)
                {
                    if (boardInt[i, i] == Player)
                    {
                        Win[2] += win;
                    }
                    else if (boardInt[i, i] == nextTurn(Player))
                    {
                        Win[2] += enemyOccupied;
                    }
                    else
                    {
                        Win[2] += empty * 2;
                    }
                }
                if (i != y && boardInt.GetLength(0) - 1 - x == y)
                {
                    if (boardInt[boardInt.GetLength(0) - 1 - i, i] == Player)
                    {
                        Win[3] += win;
                    }
                    else
                    if (boardInt[boardInt.GetLength(0) - 1 - i, i] == nextTurn(Player))
                    {
                        Win[3] += enemyOccupied;
                    }
                    else
                    {
                        Win[3] += empty * 2;
                    }
                }
            }
            int t = 0;
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                if (boardInt[Math.Abs(y - i), y] == nextTurn(Player) && boardInt[x, Math.Abs(x - i)] == nextTurn(Player))
                {
                    t++;

                }
            }
            if (t == 1)
            {
                Win[0] = 0;
                Win[1] = 0;
            }
            return -(Win[0] + Win[1] + Win[2] + Win[3] - 100000 * checkDefeat(move));
        }
        private int checkDefeat(Move move)
        {
            int Player = move.Player;
            int[,] boardInt = move.Board;
            bool[] defeatTB = new bool[boardInt.GetLength(0)];
            bool[] defeatLRB = new bool[boardInt.GetLength(0)];
            bool[] defeatUDB = new bool[boardInt.GetLength(1)];
            bool[] defeatDB = { false, false };
            int[] defeatT = new int[boardInt.GetLength(0)];
            int[] defeatLR = new int[boardInt.GetLength(0)];
            int[] defeatUD = new int[boardInt.GetLength(1)];
            int[] defeatD = { 0, 0 };
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                for (int j = 0; j < boardInt.GetLength(1); j++)
                {
                    if (boardInt[i, j] == nextTurn(Player) && !defeatLRB[j])
                    {
                        defeatLR[j]++;
                    }
                    else if (boardInt[i, j] == Player)
                    {
                        defeatLR[j] = 0;
                        defeatLRB[j] = true;
                    }
                    if (boardInt[i, j] == nextTurn(Player) && !defeatUDB[i])
                    {
                        defeatUD[i]++;
                    }
                    else if (boardInt[i, j] == Player)
                    {
                        defeatUD[i] = 0;
                        defeatUDB[i] = true;
                    }
                }
                if (boardInt[i, i] == nextTurn(Player) && !defeatDB[0])
                {
                    defeatD[0]++;
                }
                else
                if (boardInt[i, i] == Player)
                {
                    defeatD[0] = 0;
                    defeatDB[0] = true;
                }
                if (boardInt[boardInt.GetLength(0) - 1 - i, i] == nextTurn(Player) && !defeatDB[1])
                {
                    defeatD[1]++;
                }
                else if (boardInt[boardInt.GetLength(0) - 1 - i, i] == Player)
                {
                    defeatD[1] = 0;
                    defeatDB[1] = true;
                }
            }

            int score = 0;
            if (defeatD[0] == boardInt.GetLength(0) - 1)
            {
                score += defeatD[0];
            }
            if (defeatD[1] == boardInt.GetLength(0) - 1)
            {
                score += defeatD[1];
            }
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                if (defeatLR[i] == boardInt.GetLength(0) - 1)
                {
                    score += defeatLR[i];
                }
                if (defeatUD[i] == boardInt.GetLength(0) - 1)
                {
                    score += defeatUD[i];
                }
            }
            return score;
        }
    }
}
