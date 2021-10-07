using System;

namespace FirstApp
{
    class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        /// <param name="args">Массив параметров</param>
        static int Main(string[] args)
        {            
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }

            // Создание нового объекта
            var board = new ChessBoard(8);
            // Решение задачи
            board.Solve();

            Console.WriteLine("Hello World!");
            return 1;
        }
    }
}
