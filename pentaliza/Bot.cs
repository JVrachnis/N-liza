using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using player;
namespace Bots
{
    public abstract class Bot: Player
    {
        static protected int currentPlayer;
        static protected Move BestMove(List<Move> moves)
        {
            Random rnd = new Random();
            Move bestmove = new Move();
            bool first = true;
            List<Move> bestMoves = new List<Move>();
            foreach (Move m in moves)
            {
                if (first)
                {
                    bestmove = m;
                    bestMoves.Add(m);
                    first = false;
                }
                else
                {
                    if (bestmove.score < m.score)
                    {
                        bestMoves = new List<Move>();
                        bestMoves.Add(m);
                        bestmove = m;
                    }
                    else if (bestmove.score == m.score)
                    {
                        bestMoves.Add(m);
                    }
                }
            }
            bestmove = bestMoves.ElementAt(rnd.Next(bestMoves.Count));

            return bestmove;
        }
        protected int nextTurn(int Player)
        {
            if (Player == id)
            {
                Player = enemyId;
            }
            else
            {
                Player = id;
            }
            return Player;
        }
        static protected bool checkWin(Move move)
        {
            int[,] boardInt = move.Board;
            int x = move.location.X, y = move.location.Y;
            int Player = move.Player;
            bool[] Win = { true, true, true, true };
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                if (boardInt[i, y] != Player)
                {
                    Win[0] = false;
                }
                if (boardInt[x, i] != Player)
                {
                    Win[1] = false;
                }
                if (boardInt[i, i] != Player)
                {
                    Win[2] = false;
                }
                if (boardInt[boardInt.GetLength(0) - 1 - i, i] != Player)
                {
                    Win[3] = false;
                }
            }
            return Win.Contains(true);
        }
        abstract public Point CalculateMove(int[,] Board);

    }
}
