namespace SchoolProject.Core
{
    internal class Resolve
    {
        #region Fields


        internal int TotalCombinations { get; set; }

        /// <summary>
        /// Recursion DepthLimit
        /// </summary>
        internal int DepthLimit = 12;

        /// <summary>
        ///  Total cost
        /// </summary>
        internal int Cost { get; set; }

        /// <summary>
        /// Array of chars which contains board to solve
        /// </summary>
        internal readonly Char[,] _board;

        /// <summary>
        /// List that stores visited places 
        /// </summary>
        private readonly List<PathCost> _visited;

        #endregion

        #region ctor

        /// <summary>
        /// CTOR LOL 
        /// </summary>
        /// <param name="board"></param>
        internal Resolve(char[,] board)
        {
            _board = board;
            _visited = new List<PathCost>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if the specified position is board border 
        /// </summary>
        /// <param name="drawnindex"></param>
        /// <returns></returns>
        internal static bool BorderCheck(Char drawnindex)
        {
            if (drawnindex == '+')
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Resolves the board  
        /// </summary>
        internal void Start()
        {
            KeyValuePair<int, int> start = GetStartCharPos();
            KeyValuePair<int, int> end = GetEndCharPos();
            FindPaths(start.Key, start.Value, end.Key, end.Value, "", 0, 0);
            var minCostPath = _visited.OrderBy(pc => pc.Cost).FirstOrDefault();

            // foreach (var vis in _visited)
            // { //Console.WriteLine(vis);
            //     Console.WriteLine($"RUCHY:{vis.Key} ŁĄCZNY KOSZT:{vis.Value}");
            //     if (min > vis.Value )
            //     {
            //         min = vis.Value;
            //         asociatedstring = vis.Key;
            //     }
            // }



            Console.WriteLine($"MIN:{minCostPath.Cost} \nMOVES:{minCostPath.Path}");
            BoardMethods.Show(_board);

        }

        #endregion

        #region GetPosMethods

        /// <summary>
        /// Finds the Start Char 
        /// Start Char = &
        /// </summary>
        private KeyValuePair<int, int> GetStartCharPos()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == '&')
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
                    if (_board[i, j] == '$')
                    {
                        return new KeyValuePair<int, int>(i, j);
                    }
                }
            }

            return new KeyValuePair<int, int>(-1, -1);
        }

        #endregion

        #region MoveMethods

        /// <summary>
        /// Get cost of Move Up
        /// </summary>
        /// <returns></returns>
        internal int GetCostOfMoveUp()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            return _board[currentpos.Key - 1, currentpos.Value] - '0';
        }

        /// <summary>
        /// get cost of Move Down 
        /// </summary>
        /// <returns></returns>
        internal int GetCostOfMoveDown()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            return _board[currentpos.Key + 1, currentpos.Value] - '0';
        }

        /// <summary>
        /// Get cost of Move Right 
        /// </summary>
        /// <returns></returns>
        internal int GetCostOfMoveRight()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            return _board[currentpos.Key, currentpos.Value + 1] - '0';
        }

        /// <summary>
        /// Get cost of Move Left 
        /// </summary>
        /// <returns></returns>
        internal int GetCostOfMoveLeft()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            return _board[currentpos.Key, currentpos.Value - 1] - '0';
        }

        internal void FindPaths(int x, int y, int goalX, int goalY, string path, int depth, int cost)
        {
            if (depth == DepthLimit)
            {
                return;
            }

            // Sprawdź, czy jesteśmy na pozycji meta
            if (x == goalX && y == goalY)
            {
                TotalCombinations++;
                Console.Title = $"number of combinations: {TotalCombinations}";
                _visited.Add(new PathCost(path, cost));
                return;
            }


            // Przesuń się w górę
            if (x > 0 && _board[x - 1, y] != '+')
            {
                FindPaths(x - 1, y, goalX, goalY, path + "U", depth + 1, cost + _board[x - 1, y] - '0');
            }

            // Przesuń się w dół
            if (x < _board.GetLength(0) - 1 && _board[x + 1, y] != '+')
            {
                FindPaths(x + 1, y, goalX, goalY, path + "D", depth + 1, cost + _board[x + 1, y] - '0');
            }

            // Przesuń się w lewo
            if (y > 0 && _board[x, y - 1] != '+')
            {
                FindPaths(x, y - 1, goalX, goalY, path + "L", depth + 1, cost + _board[x, y - 1] - '0');
            }

            if (y < _board.GetLength(1) - 1 && _board[x, y + 1] != '+')
            {
                FindPaths(x, y + 1, goalX, goalY, path + "R", depth + 1, cost + _board[x, y + 1] - '0');
            }

            #endregion
        }
    }
}
