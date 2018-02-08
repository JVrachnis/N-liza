using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Bots
{
    public class Move
    {
        public List<Point> pointEmptyList;
        public Point location;
        public int[,] Board;
        public int Player;
        public int deapth;
        public double score = 0;
        public Move()
        {
        }
        public Move(int[,] board, List<Point> pointEmptyList, Point location, int Player, int deapth)
        {
            this.deapth = deapth;
            this.Player = Player;
            this.pointEmptyList = new List<Point>(pointEmptyList);
            this.pointEmptyList.RemoveAll(m => m.X == location.X && m.Y == location.Y);
            this.Board = board.Clone() as int[,];
            this.location = location;
            Board[location.X, location.Y] = Player;
        }
        public Move(int[,] board, Point location, int Player)
        {
            this.Player = Player;
            this.Board = board.Clone() as int[,];
            this.location = location;
            Board[location.X, location.Y] = Player;
        }
    }
}
