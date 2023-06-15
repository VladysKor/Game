using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Program
    {
        public static Player player;
        public static Random random;

        static void Main(string[] args)
        {
            random = new Random();
            player = new Player();
            DataBase.Load();

            go:
            Console.Clear();
            Console.WriteLine("==========\"Название игры типа\"==========");
            Console.WriteLine("\n1------------Начать играть--------------\n2--------------Загрузить----------------\n3----------------Выйти------------------");

            ConsoleKey key = GetButton();

            Console.Clear();

            if(key == ConsoleKey.D1)
            {
                Console.Write("Введите имя - ");

                player.name = Console.ReadLine();

                Game();
            }
            else if (key == ConsoleKey.D2)
            {

            }
            else  if (key == ConsoleKey.D3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Такого варианта не существует. \n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█\r\n█░██░██░██░██░██░██░██░██░██░░░░░░░░░░█\r\n█░██░██░██░██░██░██░██░██░██░░░░░░░░░░█\r\n█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█\r\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n░░█░░░░█▀▀▀█░█▀▀█░█▀▀▄░▀█▀░█▄░░█░█▀▀█░░\r\n░░█░░░░█░░░█░█▄▄█░█░░█░░█░░█░█░█░█░▄▄░░\r\n░░█▄▄█░█▄▄▄█░█░░█░█▄▄▀░▄█▄░█░░▀█░█▄▄█░░\r\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Thread.Sleep(2500);
                goto go;
            }
        }

        public static void Game()
        {
            Console.Clear();
            Console.WriteLine("Очь крутая предыстория");
            Console.ReadKey();

        go:

            Console.Clear();
            Console.WriteLine("==========Меню==========");
            Console.WriteLine("\n1---------О вас---------\n2-------Инвентарь--------\n3-----Исследование------\n4---------Охота---------");

            ConsoleKey key = GetButton();

            if(key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine($"Ваше имя - {player.name}");
                Console.WriteLine($"Жизнь - {player.health}/{player.healthMax}");
                Console.WriteLine($"Степень усталости - {player.power}/{player.powerMax}");
                Console.WriteLine("Нажмите на любую кнопку для возврата к меню действий...");
                Console.ReadKey();
                goto go;
            }
            else if (key == ConsoleKey.D2)
            {
                Console.Clear();
                player.inventory.GetAllItems();
            }
            else if (key == ConsoleKey.D3)
            {
                Console.Clear();
                if (player.power > 15)
                {
                    player.power = player.power - 15;
                    explore();
                }
                else
                {
                    Console.WriteLine("Вы устали!");
                }

            }
            else if (key == ConsoleKey.D4)
            {
                Console.Clear();
                Fight.FightEnemy(DataBase.GetEnemy(0));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого варианта не существует. \n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█\r\n█░██░██░██░██░██░██░██░██░██░░░░░░░░░░█\r\n█░██░██░██░██░██░██░██░██░██░░░░░░░░░░█\r\n█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█\r\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n░░█░░░░█▀▀▀█░█▀▀█░█▀▀▄░▀█▀░█▄░░█░█▀▀█░░\r\n░░█░░░░█░░░█░█▄▄█░█░░█░░█░░█░█░█░█░▄▄░░\r\n░░█▄▄█░█▄▄▄█░█░░█░█▄▄▀░▄█▄░█░░▀█░█▄▄█░░\r\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Thread.Sleep(2500);
                goto go;
            }
            Console.WriteLine("Нажмите на любую кнопку, что бы продолжить...");
            Console.ReadKey();
            goto go;
        }

        public static void explore()
        {
            int ran = random.Next(0, 100);

            if(ran <= 5)
            {
                Console.WriteLine("Вы нашли пещеру");
            }
            else if(ran <= 10)
            {
                Console.WriteLine("Вы нашли сундук");
            }
            else if (ran <= 15)
            {
                Console.WriteLine("Вы нашли кристалл");
            }
            else
            {
                Console.WriteLine("Вы ничего не нашли");
            }
        }

        public static ConsoleKey GetButton()
        {
            var but = Console.ReadKey(true).Key;
            return but;
        }
    }
}