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
        public static Player Get(int type,int id,int enemyId,int emptyId)//will return the player that is asked
        {
            switch (type)
            {
                case 0:
                    return new SmartLoser(id, enemyId, emptyId);
                case 1:
                    return new RandomBot(id, enemyId, emptyId);
                case 2:
                    return new MinMaxBot(id, enemyId, emptyId, 0);
                case 3:
                    return new MinMaxBot(id, enemyId, emptyId,1);
                case 4:
                    return new MinMaxBot(id, enemyId, emptyId,2);
                case 5:
                    return new SmartBot(id, enemyId, emptyId);
                case 6:
                    return new MiniMaxWithSmart(id, enemyId, emptyId);
                default:
                    return new Human(id, enemyId, emptyId);
                    
            }
        }
        public static Player[] GetAllTypes(int id, int enemyId, int emptyId)//will return a list with players that is asked
        {
            Player[] temp = { new RandomBot(id, enemyId, emptyId), new MinMaxBot(id, enemyId, emptyId, 0),
                new MinMaxBot(id, enemyId, emptyId, 1), new MinMaxBot(id, enemyId, emptyId, 2),
                 new MinMaxBot(id, enemyId, emptyId,4),new SmartBot(id, enemyId, emptyId),
                  new MinMaxBot(id, enemyId, emptyId),new Human(id, enemyId, emptyId)
            };
            return temp;
        }
    }    
    public abstract class Player//abstract for human and bots
    {
        public int id;
        public int enemyId;
        public int emptyId;
    }
    public class Human:Player//this type of player is handled dirfendly from the Nliza than the others
    {
        public Human(int ID, int EnemyId, int EmptyId)
        {
            id = ID;
            enemyId = EnemyId;
            emptyId = EmptyId;
        }
    }
}
