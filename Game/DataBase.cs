using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class DataBase
    {
        public static List<item> items;
        public static List<enemy> enemies;

        public static void Load()
        {
            items = new List<item>();
            enemies = new List<enemy>();

            items.Add(new item("Палка", 1, true));

            enemies.Add(new enemy("Зомби", 0, 20, 5, 0));
        }
        
        public static item GetItem(int ID, int count = 1)
        {
            item item = (item)items.Find(I => I.id == ID).Clone();
            if (item != null)
            {
                if (item.stack)
                {
                    item.count = count;
                }
                else
                {
                    item.count = 1;
                }
                return item;
            }
            else
            {
                return null;
            }
        }

        public static enemy GetEnemy(int ID)
        {
            enemy enemy = (enemy)enemies.Find(E => E.ID == ID).Clone();

            if(enemy != null)
            {
                return enemy;
            }
            else
            {
                return null;
            }
        }
    }
}
