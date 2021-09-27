using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3_10
{
    /// <summary>
    /// Задание 1. Создание игры на два игрока
    /// </summary>
    class Game1
    {
        /// <summary>
        /// вывод правил к игрке номер 1
        /// </summary>
        public static void PrintLogo()
        {

            Console.WriteLine("\nПоздравляем вы выбрали простую игру на два игрока. Правила игры:");

            Console.WriteLine("Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.");

            Console.WriteLine("Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.");

            Console.WriteLine("UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.");

            Console.WriteLine("Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.");


        }

        private string User1 { get; set;  }
        private string User2 { get; set;  }
        private int gameNumber { get; set; }

        public void StartGame(Game1 game1)
        {

            int limit = 4;

            while (game1.gameNumber>0)
            {
    
                limit = Limit(limit, game1.gameNumber);

                Console.Write($"\nВведите число уважаемый {game1.User1} :");
                
                GameMaster(game1, limit);

                Console.WriteLine($"теперь gameNumber = { game1.gameNumber}");
               
                if (game1.gameNumber == 0)
                {        
                    Console.WriteLine($"Поздравляем тебя {User1} ты победил!");
                    NewGame(game1);
                    break;
                }

                limit = Limit(limit, game1.gameNumber);

                Console.Write($"\nВведите число уважаемый {game1.User2} :");
                
                GameMaster(game1, limit);

                Console.WriteLine($"теперь gameNumber = { game1.gameNumber}");
                if (game1.gameNumber == 0)
                {
                    Console.WriteLine($"Поздравляем тебя {User2} ты победил!");
                    NewGame(game1);
                    break;
                }
            }
        }

        



        /// <summary>
        /// Узнать допустимый лимит выбора числа 
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="gameNumber"></param>
        /// <returns></returns>
        public int Limit(int limit, int gameNumber)
        {
            if (gameNumber <= limit)
            {
                limit = gameNumber;
            }
             return limit;
        }

        private void GameMaster (Game1 game1, int limit)
        {
            bool flag = true;
            String str = "";
            while (flag)
            {
                str = Console.ReadLine();
                flag = GameModule.ItIsNumber(str, limit);
            }
            game1.gameNumber = game1.gameNumber - int.Parse(str);

        }
        

        private void NewGame (Game1 game1)
        {
            Console.WriteLine($"\nПоздравляем вы выйграли !!! " +
                 $"если хотите сыграть реваншь нажмите Y, при нажатии другой клавиши игра закончиться!");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                game1 = new Game1(User1, User2);
                StartGame(game1);
            }
        }
        public Game1 (string user1, string user2)
        {
            Random random = new Random();
            User1 = user1;
            User2 = user2;
            gameNumber = random.Next(12, 120);
            Console.WriteLine($"\nВеликолепно!!! игра началась, gameNumber = {gameNumber}");
            Console.WriteLine($"ходим по очереди первый {user1}, затем {user2}");
        }





    }
}
