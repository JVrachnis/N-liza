using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Bots
{
    public class RandomBot:Bot
    {
        Random rnd = new Random();
        public RandomBot()
        {
        }
        public RandomBot(int ID, int EnemyId, int EmptyId)
        {
            id = ID;
            enemyId = EnemyId;
            emptyId = EmptyId;
        }
        override public Point CalculateMove(int[,] Board)
        {
            int x, y;
            do {
                x = rnd.Next(Board.GetLength(0));
                y = rnd.Next(Board.GetLength(1));
            } while (Board[x,y]!=emptyId);
            return new Point(x,y);
        }
    }
}
