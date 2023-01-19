namespace SchoolProject.Core
{
    internal static class BoardMethods
    {
        /// <summary>
        /// Generate empty array of chars in specified size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static string[,] Generate(int size)
        {
            var board = new string[size, size];
            return board;

        }
        /// <summary>
        /// Fiils board with numbers 0-9 , this method also adds borders to the board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        internal static string[,] FillBoard(string[,] board)
        {
            // & = Start Char
            // $ = End Char

            Random random = new Random();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i == 0 || i == board.GetLength(0) - 1 || j == 0 || j == board.GetLength(1) - 1) { board[i, j] = "+"; }
                    else { board[i, j] = random.Next(0, 10).ToString(); }

                }
            }
            while (true)
            {
                int a = random.Next(board.GetLength(0) - 1);
                int b = random.Next(board.GetLength(0) - 1);
                int x = random.Next(board.GetLength(0) - 1);
                int y = random.Next(board.GetLength(0) - 1);
                if (!Resolve.BorderCheck(board[x, y]) && !Resolve.BorderCheck(board[a, b]) && a != x)
                {
                    board[a, b] = "&";
                    board[x, y] = "$";
                    break;
                }
            }

            return board;
        }
        /// <summary>
        /// Prints board to console.
        /// </summary>
        /// <param name="board"></param>
        internal static void Show(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == "&") Console.ForegroundColor = ConsoleColor.Red;
                    if (board[i, j] == "$") Console.ForegroundColor = ConsoleColor.Green;
                    if (board[i, j] == "■") Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write($"{board[i, j]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

    }
}
