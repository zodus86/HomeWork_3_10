using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3_10
{
    class Game2 
    {
        public static void PrintLogo()
        {
            Console.WriteLine("Задание 2. Повышение уровня сложности игры или увеличение числа игроков" +
                "\nПравила игра: загадывается некое случайное число в диапозоне выбранного вами уровня сложности" +
                "\nкаждый игрок выбирает на сколько его уменьшить в свой ход в зависимотси от выброного уровня сложности" +
                "\nвыйграет тот, кто первый дойдет до 0");
            Console.WriteLine("\nА теперь решим по каким правилам будем играть, " +
                "ответьте на несколько вопросов цифрами");
        }

        private List<string> Users { get; set; }
        private int gameNumber { get; set; }

        private int userTryMin { get; set; }

        private int userTryMax { get; set; }

        public Game2(List<string> users, int maxRandomNumber, int minRandomNumber ,int userTryMin, int userTryMax)
        {
            Random random = new Random();
            Users = users;

            int[] array = { maxRandomNumber , minRandomNumber };
            Array.Sort(array);

            this.gameNumber = random.Next(array[0], array[1]);
            
            array = new int[]{ userTryMin, userTryMax };
            Array.Sort(array);
            
            this.userTryMin = array[0];
            this.userTryMax = array[1];
            
            Console.WriteLine("\nЗамечательно! Все правила установлены начинаем игру");
            Console.WriteLine($"Вы выбрали допустимый шаг от {array[0]} до {array[1]} " +
                $"gameNumber = {this.gameNumber} число игроков = {users.Count}\n");
            int count = 0;
            foreach(string str in users)
            {
                count++;
                Console.Write($"Игрок № {count} - {str} ");
            } 
        }

        

        public static void Installation()
        {
            Console.WriteLine("Пожалуйста укажите сколько человек планирует играть Доступно от 2 до 5 ");
            int limit = 5;
            int minLimit = 2;
            bool flag = true;
            String line = "";

            while (flag)
            {
                line = Console.ReadLine();
                flag = GameModule.ItIsNumber(line, limit, minLimit); //проверим на число игроков 2 - 5 

            }

            Console.WriteLine($"Замечательно будет игать {line} - игрока(оф)");
            Console.WriteLine("Пожалуйста представьтесь по очерди, что бы я мог к вам обращаться");
           
            limit = int.Parse(line);
            List<string> users = new List<string>();

            for (int i = 0; i<limit;  i++)
            {
                users.Add(GameModule.CreateUser());
            }

            Console.WriteLine("Введите диапазон для Загадываемого числа");
           
            flag = true;
            while (flag) //определим предел gameNumber
            {
                line = Console.ReadLine();
                flag = GameModule.ItIsNumber(line, int.MaxValue, int.MinValue);
            }

            Console.WriteLine($"Значение {line} установлено! введите следующую границу значения");
            int gameNumberMin = int.Parse(line);
            
            flag = true;
            while (flag) //определим предел gameNumber
            {
                line = Console.ReadLine();
                flag = GameModule.ItIsNumber(line, int.MaxValue, int.MinValue);
            }

            int gameNumberMax = int.Parse(line);
            Console.WriteLine("Замечательно остался последний шаг, до старта игры! " +
                "\nВведите минимальный и максимальный диапазон шага для уменьшения ");

            flag = true;
            while (flag) //определим  userTryMin
            {
                line = Console.ReadLine();
                flag = GameModule.ItIsNumber(line, int.MaxValue, int.MinValue);
            }
            int userTryMin = int.Parse(line);
            Console.WriteLine("" + line + " Успешно установлено, введите следующее значение");
            flag = true;
            while (flag) //определим  userTryMax
            {
                line = Console.ReadLine();
                flag = GameModule.ItIsNumber(line, int.MaxValue, int.MinValue);
            }
            int userTryMax = int.Parse(line);

            

            Game2 game2 = new Game2(users, gameNumberMax, gameNumberMin, userTryMin, userTryMax);
            
            StartGame(game2);
            
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        /// <param name="game2"></param>
        static void StartGame(Game2 game2)
        {
            int count = 0;
            int limit = game2.userTryMax;
            Console.WriteLine("Приятной игры!!");

            while (game2.gameNumber > 0)
            {
                limit = Limit(game2.userTryMax, game2.gameNumber);

                foreach (string user in game2.Users)
                {
                    Console.Write($"\nВведите число уважаемый {user} :");

                    GameMaster(game2, game2.userTryMin , limit);

                    Console.WriteLine($"теперь gameNumber = { game2.gameNumber}");

                    if (game2.gameNumber == 0 && count != 0 )
                    {
                        Console.WriteLine($"\nПобедил игрок - {user}");
                        break;
                    } else
                    {
                        Console.WriteLine("Ничья! Дожен каждый игрок попробовать сыграть");
                        break;
                    }
                }
                count ++;
            }    
        }

        /// <summary>
        /// /проверка шага для игры на максимально доступный
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="gameNumber"></param>
        /// <returns></returns>
        private static int Limit(int limit, int gameNumber)
        {
            if (gameNumber <= limit)
            {
                limit = gameNumber;
            }
            return limit;
        }

        private static void GameMaster(Game2 game2, int userTryMin, int userTryMax)
        {
            bool flag = true;
            String str = "";
            while (flag)
            {
                str = Console.ReadLine();
                flag = GameModule.ItIsNumber(str, userTryMax, userTryMin);
            }
            game2.gameNumber = game2.gameNumber - int.Parse(str);


        }


    }
}
