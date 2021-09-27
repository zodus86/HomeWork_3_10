using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3_10
{
    class Game3
    {
       
        private string UserName { get; set; }
        private int gameNumber { get; set; }
        private bool  gameMode { get; set; }
        private string nameComp { get; set; }
        public static void Installation ()
        {
            Console.WriteLine("Пожалуйста выбирете уровень сложности цифрой :" +
                "\n- 1 Простой уровень для новичка" +
                "\n- 2 Тут прийдется подумать");
             
            int limit = 4;
            String line = "";
            bool flag = true;
            
            while (flag)
            {
                line = Console.ReadLine();
                flag = GameModule.ItIsNumber(line, 2, 1);
            }
            
            int gameMode = int.Parse(line);

            Console.WriteLine($"Замечательно это то что нужно! Вы выбрали {gameMode} уровень сложности" +
                $"\nА теперь напишите пожалуйста как я к Вам обращаться могу?");

            line = GameModule.CreateUser();

            Game3 game3 = new Game3(gameMode, line);
            StartGame(game3);
   

        }

        Game3 (int gameMode, string user)
        {
            this.UserName = user;
            Random random = new Random();
            this.gameNumber = random.Next(15, 46);
            switch (gameMode)
            {
                case 1:
                    this.gameMode = false;
                    nameComp = "EasyComp";
                    break;
                case 2:
                    this.gameMode = true;
                    nameComp = "HARD_COMP";
                    break;
                
                default:
                    Console.WriteLine("Что то пошло не так!"); //в принцепе не должно быть
                    break;
            }

            Console.WriteLine($"Игра начинается меня зовут {nameComp} " +
                $"случайное число, которое необходимо обнулить = {this.gameNumber}");
        }


        private static void StartGame(Game3 game3)
        {
            int limit = 4;
            while (game3.gameNumber > 0)
            {
                limit = GameModule.Limit(limit, game3.gameNumber);

                Console.Write($"\nВведите число уважаемый {game3.UserName} :");

                GameMaster(game3, limit);

                Console.WriteLine($"теперь gameNumber = { game3.gameNumber}");

                if (game3.gameNumber == 0)
                {
                    Console.WriteLine($"Поздравляем тебя {game3.UserName} ты победил!");
                    break;
                }

                limit = GameModule.Limit(limit, game3.gameNumber);

                Console.WriteLine($"Теперь ходит {game3.nameComp}");
               
                GameMasterComp(game3, limit);
            }
        }

        private static void GameMaster(Game3 game3, int limit)
        {
            bool flag = true;
            String str = "";
            while (flag)
            {
                str = Console.ReadLine();
                flag = GameModule.ItIsNumber(str, limit);
            }
            game3.gameNumber = game3.gameNumber - int.Parse(str);

        }

        private static void GameMasterComp(Game3 game3, int limit)
        {
            int i;
            Random random = new Random();

            if (game3.gameMode) ///hard mode
            {
                
                if(game3.gameNumber > 12)
                {
                   
                    i = random.Next(1, limit);
                    
                }else if (game3.gameNumber == 4)
                {
                    i = 4;
                }else if (game3.gameNumber == 5)
                {
                    i = 4;
                }else if (game3.gameNumber == 6)
                {
                    i = 1;
                }else if (game3.gameNumber == 7)
                {
                    i = 2;
                }else if (game3.gameNumber == 8)
                {
                    i = 3;
                }else if (game3.gameNumber == 9) 
                {
                    i = random.Next(3, limit);
                }else 
                {
                    i = 1;
                }


                Console.WriteLine(i);
                game3.gameNumber = game3.gameNumber - i;
                Console.WriteLine($"теперь gameNumber = { game3.gameNumber}");

                if (game3.gameNumber == 0)
                {
                    Console.WriteLine($"GameOver - выйграл {game3.nameComp}");
                }

            }
            else
            {
                i = random.Next(1, 2);
                Console.WriteLine(i);
                game3.gameNumber = game3.gameNumber - i;

                Console.WriteLine($"теперь gameNumber = { game3.gameNumber}");

                if (game3.gameNumber == 0)
                {
                    Console.WriteLine($"GameOver - выйграл {game3.nameComp}");
                }
            }
        }



       public static void PrintLogo ()
        {
            Console.WriteLine("Правила игры: рандомно придумывается gameNumber от 15 до 46" +
                " вы пишете число от 1 до 4 кто первый обнулит gameNumber тот и выйграл" +
                "\nПротив вас будет выставлен один из компьютеров один с уровнем сложности новичок другой ПРО" +
                " выбор за вами !");
        }
    }



}
