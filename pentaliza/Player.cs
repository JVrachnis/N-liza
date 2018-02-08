using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Bots;
namespace player
{
    public class PFactory
    {
        public static Player Get(int type,int id,int enemyId,int emptyId)
        {
            switch (type)
            {
                //return new Perceptron(id, enemyId, emptyId);
                case 0:
                    return new RandomBot(id, enemyId, emptyId);
                case 1:
                    return new MinMaxBot(id, enemyId, emptyId, 0);
                case 2:
                    return new MinMaxBot(id, enemyId, emptyId, 1);
                case 3:
                    return new MinMaxBot(id, enemyId, emptyId,2);
                case 4:
                    return new MinMaxBot(id, enemyId, emptyId,4);
                case 5:
                    return new SmartBot(id, enemyId, emptyId);
                case 6:
                    return new MinMaxBot(id, enemyId, emptyId);
                default:
                    return new Human(id, enemyId, emptyId);
                    
            }
        }
    }    
    public abstract class Player
    {
        public int id;
        public int enemyId;
        public int emptyId;
    }
    public class Human:Player
    {
        public Human(int ID, int EnemyId, int EmptyId)
        {
            id = ID;
            enemyId = EnemyId;
            emptyId = EmptyId;
        }
    }
}
