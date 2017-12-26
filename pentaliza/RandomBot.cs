using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace triliza
{
    class RandomBot:Bot
    {
        Random rnd = new Random();
        public RandomBot()
        {
        }
        override public Point CalculateMove(int[,] Board, int Player)
        {
            int x, y;
            do {
                x = rnd.Next(Board.GetLength(0));
                y = rnd.Next(Board.GetLength(1));
            } while (Board[x,y]!=3);
            return new Point(x,y);
        }
    }
}
