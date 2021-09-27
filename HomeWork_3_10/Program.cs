using System;


namespace HomeWork_3_10
{
    class Program
    {
        static void Main(string[] args)
        {
            // выводим приветсвие
            GameModule.PrintLogo(); 
            
            // запрашиваем игру у пользователя
            GameModule.ReadKeyModule();

        }
    }
}
