using System;

namespace FirstApp
{
    class ChessBoard
    {
        /// <summary>
        /// Положение фигур в горизонталях шахматной доски
        /// <para>Положение - число от 0 до size-1</para>
        /// </summary>
        private int[] row;

        /// <summary>
        /// Конструктор
        /// </summary>
        internal ChessBoard(int size)
        {
            row = new int[size];
            // Инициализация массива
            for (int i = 0; i < size; i++)
            {
                row[i] = -1; // начальная позиция (ферзи за полем)
            }
        }

        /// <summary>
        /// Найти решение
        /// </summary>
        internal void Solve()
        {
            Run(0);
        }

        /// <summary>
        /// Печать доски
        /// </summary>
        private void Print()
        {
            foreach (int i in row)
            {
                /*
                 * Варианты печати строки
                Console.Write(i.ToString() + " ");
                Console.Write(string.Format("{0} ", i));
                Console.Write("{0} ", i);
                */
                Console.Write($"{i} ");             
            }
            Console.WriteLine();

            for (int y = 0; y < row.Length; y++)
            {
                for (int x = 0; x < row.Length; x++)
                {
                    var backColor = Console.BackgroundColor;
                    var foreColor = Console.ForegroundColor;
                    Console.BackgroundColor = ((x + y) % 2 == 1) ? ConsoleColor.Black : ConsoleColor.Gray;
                    Console.ForegroundColor = ((x + y) % 2 != 1) ? ConsoleColor.Black : ConsoleColor.Gray;
                    string s = (row[y] == x) ? "<>" : "  ";
                    Console.Write(s);
                    Console.BackgroundColor = backColor;
                    Console.ForegroundColor = foreColor;
                }
                Console.WriteLine();
            }          
            Console.WriteLine();
        }

        /// <summary>
        /// Проверка корректности положения ферзя с индексом index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool Allowed(int index)
        {
            for (int i = 0; i < index; i++)
            {
                if (row[i] == row[index]) // Ферзи на одной вертикали
                {
                    return false;
                }
                if (Math.Abs(row[index] - row[i]) == (index - i)) // Ферзи на одной диагонали
                {
                    return false;
                }
            }
            return true; // Комбинация разрешена
        }

        internal void Run(int index)
        {
            for (int position = 0; position < row.Length; position++)
            {
                row[index] = position;
                if (!Allowed(index)) // Проверка на разрешенную комбинацию
                {
                    continue;
                }
                 
                if (index == (row.Length - 1))
                {
                    // мы дошли до конца
                    Print();
                }
                else
                {
                    Run(index + 1);
                }
            }
        }
    }
}
