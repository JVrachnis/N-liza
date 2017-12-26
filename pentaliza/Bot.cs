using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace triliza
{
    abstract class Bot
    {
        abstract public Point CalculateMove(int[,] Board,int Player);
    }
}
