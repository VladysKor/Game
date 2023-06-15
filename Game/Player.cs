using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Player
    {
        public string name;
        public int health,healthMax;
        public int power, powerMax;
        public inventory inventory;
        public int damage;
        public int Armor;

        public Player()
        {
            inventory = new inventory();



            healthMax = 100;
            powerMax = 100;
            damage = 15;
            Armor= 2;

            health = healthMax;
            power = powerMax;
        }
    }
    class inventory
    {
        public List<item> items = new List<item>();
        public void AddItem(item item)
        {
            if (items.Count > 0)
            {

                for (int i = 0; i < items.Count; i++)
                {

                    if (item.id == items[i].id && items[i].stack)
                    {
                        items[i].count += item.count;
                        break;
                    }
                    else if (i == items.Count - 1)
                    {
                        items.Add(item);
                        break;
                    }
                }
            }
            else
            {
                items.Add(item);
            }
        }
        public void GetAllItems()
        {
            for (int i = 0; i < items.Count; ++i)
            {
                Console.WriteLine($"{i}: {items[i].name}, количество: {items[i].count}");
            }
        }
    }
}
