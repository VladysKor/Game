using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Fight
    {
        static Player player
        {
            get { return Program.player; }
            set { Program.player = value; }
        }

        public static void FightEnemy(enemy enemy)
        {
            Console.WriteLine($"На вас напал {enemy.Name}:\nурон - {enemy.Damage}\nзащита - {enemy.Armor}\nHP - {enemy.MaxHealth}");
            Console.WriteLine("Нажмите Enter, что бы продолжить...");
            Console.ReadLine();
            Console.Clear();

        go:
            Console.WriteLine($"{enemy.Name}: {enemy.Health} HP");
            Console.WriteLine($"{player.name}: {player.health} HP");

            Console.WriteLine("1 : Ударить\n2 : Убежать");

            var key = Program.GetButton();

            if(key == ConsoleKey.D1)
            {
                enemy.Health -= Math.Max(player.damage -= enemy.Armor, 1);
            }
            else if(key == ConsoleKey.D2)
            {
                int r = Program.random.Next(5,15);
                if(r == 9)
                {
                    Console.WriteLine("Вы смогли сбежать.");
                    goto run;
                }
                else
                {
                    Console.WriteLine("Вам не удалось сбежать!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого варианта не существует. \n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█\r\n█░██░██░██░██░██░██░██░██░██░░░░░░░░░░█\r\n█░██░██░██░██░██░██░██░██░██░░░░░░░░░░█\r\n█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█\r\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n░░█░░░░█▀▀▀█░█▀▀█░█▀▀▄░▀█▀░█▄░░█░█▀▀█░░\r\n░░█░░░░█░░░█░█▄▄█░█░░█░░█░░█░█░█░█░▄▄░░\r\n░░█▄▄█░█▄▄▄█░█░░█░█▄▄▀░▄█▄░█░░▀█░█▄▄█░░\r\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Thread.Sleep(2500);
                goto go;
            }

            if (enemy.Health > 0)
            {
                player.health -= enemy.Health -= Math.Max(enemy.Damage -= player.Armor, 1);
            }

            if (player.health <=0)
            {
                goto lose;
            }
            else if (enemy.Health <= 0)
            {
                goto win;
            }
            else
            {
                Console.Clear();
                goto go;
            }

        win:
            Console.Clear();
            Console.WriteLine("Вы выйграли!");
            Console.WriteLine("Вы получили опыт");
            return;
        lose:
            Console.Clear();
            Console.WriteLine("Вы проиграли!");
            return;
        run:
            return;
        }
    }
}
