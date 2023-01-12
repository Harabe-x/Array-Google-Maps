using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    internal static class BoardMethods
    {
        /// <summary>
        /// Generate empty array of chars in specified size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static Char[,]? Generate(int size)
        {
            char[,] board = new Char[size, size];
            return board;

        }
        /// <summary>
        /// Fiils board with numbers 0-9 , this method also adds borders to the board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        internal static Char[,] FillBoard(Char[,] board)
        {          
            // & = Start Char
            // $ = End Char

            Random _random = new Random();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i == 0 || i == board.GetLength(0) - 1 || j == 0 || j == board.GetLength(1) - 1) { board[i, j] = '+'; }
                    else { board[i, j] = (Char)( 0x30 | _random.Next(0, 10)); }

                }
            }
            while (true)
            {
                int a = _random.Next(board.GetLength(0) - 1);
                int b = _random.Next(board.GetLength(0) - 1);
                int x = _random.Next(board.GetLength(0) - 1);
                int y = _random.Next(board.GetLength(0) - 1);
                if (!Resolve.BorderCheck(board[x, y]) && !Resolve.BorderCheck(board[a, b]) && a != x   )
                {
                    board[a, b] = '&';
                    board[x, y] = '$';
                    break;
                }
            }
          
            return board;
        }
        /// <summary>
        /// Prints board to console.
        /// </summary>
        /// <param name="board"></param>
        internal static void Show(Char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '&') Console.ForegroundColor = ConsoleColor.Red;
                    if (board[i, j] == '$') Console.ForegroundColor = ConsoleColor.Green;
                    if (board[i, j] == (char)9632) Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write($"{board[i,j]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        
    }
}
