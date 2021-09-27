using System;


namespace HomeWork_3_10
{
    class GameModule
    {
       /// <summary>
       /// Метод вывода приветсвия программы
       /// </summary>
        public static void PrintLogo()
        {
            Console.WriteLine("Добро пожаловать в мир игр!");
            Console.WriteLine("Пожалуйста введите цифру соответсвующую номеру игры (1-3) :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" 1 - Задание 1. Создание игры на два игрока");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" 2 - Задание 2. Повышение уровня сложности игры или увеличение числа игроков");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" 3 - Задание 3. Реализация игры с компьютером");
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        /// <summary>
        /// Метод выбора игры принимаются только 1, 2 или 3 
        /// </summary>
        public static void ReadKeyModule() 
        {
            bool flag = true; //flag выхода из цикла выбора игры, только при правильгном выборе

            while (flag)
            {
                int key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 1:  //выбор игры по заданию 1
                        flag = false;
                        Console.WriteLine("\nВыбрана игра 1, отличный выбор!");
                        
                        Game1.PrintLogo();

                        Console.WriteLine("\nДля начала игры представьтесь по очереди");

                        Game1 game1 = new Game1(CreateUser(), CreateUser());
                        game1.StartGame(game1);

                        break;

                    case 2: //выбор игры по заданию 2
                        flag = false;
                        Console.WriteLine("\nВыбрана игра 2, отличный выбор!");
                        Game2.PrintLogo();

                        Game2.Installation();

                        break;
                    case 3:
                        Console.WriteLine("\nВы выбрали игру с компьютером, отличный выбор когда нету живого партнера!");
                        Game3.PrintLogo();
                        Game3.Installation();
                        flag = false;
                        break;
                   
                    
                    default: //если не попали в 1-2-3
                        Console.WriteLine("\nпопробуйте выбрать еще раз доступные варианты от 1 до 3");
                        continue;
                }
            }
        }


        /// <summary>
        /// Создаем пользователей с консоли
        /// </summary>
        /// <returns></returns>
        public static string CreateUser()
        {
            String name = Console.ReadLine();
  
            Console.WriteLine($"Имя принято {name}");
            return name;
        }


        /// <summary>
        /// проверка значения на число 1-4 для 1 задания, для прерывания цикла
        /// вернет Ложь при нужном значении
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ItIsNumber(string number, int limit)
        {
            try
            {
               int x = int.Parse(number);
                if (x > 0 && x <= limit) return false;
            }
            catch (Exception)
            {
                Console.WriteLine($"\nНеобходимо ввести число от 1 до {limit} число");
                return true;
                throw;
            }
            Console.WriteLine("\nВы ввели недопустимое число, попробуйте еще раз");
            return true;
        }


        /// <summary>
        /// Узнать допустимый лимит выбора числа 
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="gameNumber"></param>
        /// <returns></returns>
        public static int Limit(int limit, int gameNumber)
        {
            if (gameNumber <= limit)
            {
                limit = gameNumber;
            }
            return limit;
        }

        public static bool ItIsNumber(string number, int maxLimit, int minLimit)
        {
            try
            {
                int x = int.Parse(number);
                if (x >= minLimit && x <= maxLimit) return false;
            }
            catch (Exception)
            {
                Console.WriteLine($"\nНеобходимо ввести число от {minLimit} до {maxLimit} число");
                return true;
                throw;
            }
            Console.WriteLine($"\nНеобходимо ввести число от {minLimit} до {maxLimit} число");
            return true;
        }

    }

}
