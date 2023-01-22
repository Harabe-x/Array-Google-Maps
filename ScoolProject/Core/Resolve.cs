using System.Diagnostics;

namespace SchoolProject.Core
{
    internal class Resolve
    {
        #region Fields

        /// <summary>
        /// StopWatch 
        /// </summary>
        Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Number of total checked combinations
        /// </summary>
        private int TotalCombinations { get; set; }

        /// <summary>
        /// Recursion DepthLimit
        ///
        /// </summary>
        private const int DepthLimit = 15;

        /// <summary>
        ///  Total cost
        /// </summary>
        internal int Cost { get; set; }

        /// <summary>
        /// Array of chars which contains board to solve
        /// </summary>
        private readonly string[,] _board;

        /// <summary>
        /// List that stores visited places 
        /// </summary>
        private readonly List<PathCost> _visited;

        #endregion

        #region Ctor

        /// <summary>
        /// CTOR LOL 
        /// </summary>
        /// <param name="board"></param>
        internal Resolve(string[,] board)
        {
            _board = board;
            _visited = new List<PathCost>();
            _stopwatch.Start();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if the specified position is board border 
        /// </summary>
        /// <param name="drawnIndex"></param>
        /// <returns></returns>
        internal static bool BorderCheck(string drawnIndex)
        {
            if (drawnIndex == "+")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Resolves the board  
        /// </summary>
        private void Start()
        {
            KeyValuePair<int, int> start = GetStartCharPos(_board);
            KeyValuePair<int, int> end = GetEndCharPos();
            FindPaths(start.Key, start.Value, end.Key, end.Value, "", 0, 0);
            var x = _visited.MinBy(pc => pc.Cost);
        }

        /// <summary>
        /// Returns Board
        /// </summary>
        /// <returns></returns>
        internal KeyValuePair<PathCost?, string[,]> ReturnPair()
        {
            Start();
            return new KeyValuePair<PathCost?, string[,]>(_visited.MinBy(pc => pc.Cost), _board);
        }
        #endregion
        #region GetPosMethods

        /// <summary>
        /// Finds the Start Char 
        /// Start Char = &
        /// </summary>
        internal static KeyValuePair<int, int> GetStartCharPos(string[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == "&")
                    {
                        return new KeyValuePair<int, int>(i, j);
                    }
                }
            }

            return new KeyValuePair<int, int>(-1, -1);
        }

        /// <summary>
        /// Finds the End Char
        /// End char = $
        /// </summary>
        private KeyValuePair<int, int> GetEndCharPos()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == "$")
                    {
                        return new KeyValuePair<int, int>(i, j);
                    }
                }
            }

            return new KeyValuePair<int, int>(-1, -1);
        }

        #endregion

        #region Resolve

        /// <summary>
        /// Finds all ways from point a to b 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="goalX"></param>
        /// <param name="goalY"></param>
        /// <param name="path"></param>
        /// <param name="depth"></param>
        /// <param name="cost"></param>
        private void FindPaths(int x, int y, int goalX, int goalY, string path, int depth, int cost)
        {

            if (depth == DepthLimit)
            {
                return;
            }


            if (x == goalX && y == goalY)
            {
                TotalCombinations++;
                Console.Title = $" Elapsed Time: {(int)_stopwatch.ElapsedMilliseconds / 1000}s                                                                                             Total combinations: {TotalCombinations} \n ";
                _visited.Add(new PathCost(path, cost));
                return;
            }


            // Move UP
            if (x > 0 && _board[x - 1, y] != "+")
            {
                int.TryParse(_board[x + 1, y], out var parsed);
                FindPaths(x - 1, y, goalX, goalY, path + "U", depth + 1, cost + parsed);
            }

            // Move DOWN
            if (x < _board.GetLength(0) - 1 && _board[x + 1, y] != "+")
            {
                int.TryParse(_board[x + 1, y], out var parsed);
                FindPaths(x + 1, y, goalX, goalY, path + "D", depth + 1, cost + parsed);
            }

            // MOVE LEFT 
            if (y > 0 && _board[x, y - 1] != "+")
            {
                int.TryParse(_board[x, y - 1], out var parsed);
                FindPaths(x, y - 1, goalX, goalY, path + "L", depth + 1, cost + parsed);
            }

            //MOVE RIGHT
            if (y < _board.GetLength(1) - 1 && _board[x, y + 1] != "+")
            {
                int.TryParse(_board[x, y + 1], out var parsed);
                FindPaths(x, y + 1, goalX, goalY, path + "R", depth + 1, cost + parsed);
            }
        }

        #endregion

    }
}
