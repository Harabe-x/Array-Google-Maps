namespace SchoolProject.Core
{
    internal class Resolve
    {

        #region Fields


        private bool Solved { get; set; }
        /// <summary>
        /// Moves count
        /// </summary>
        public int Moves { get; set; }
        /// <summary>
        ///  Total cost
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Array of chars which contains board to solve
        /// </summary>
        private Char[,] _board;

        /// <summary>
        /// List that stores visited places 
        /// </summary>
        private readonly List<KeyValuePair<int, int>> _visited;

        private List<Char[,]> _moveshistory;
        #endregion
        #region ctor

        /// <summary>
        /// CTOR LOL 
        /// </summary>
        /// <param name="board"></param>
        internal Resolve(char[,] board)
        {
            _board = board;
            _visited = new List<KeyValuePair<int, int>>();
            _moveshistory = new List<char[,]>();
        }

        #endregion
        #region Methods

        internal void ShowMoveHistory()
        {

            Console.Clear();
            foreach (char[,] item in _moveshistory)
            {
                BoardMethods.Show(item);
                Console.ReadKey();
                Console.Clear();
            }
        }

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
                { }
            }

            return false;
        }
        /// <summary>
        /// Chceks  if specified pos was visited
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool VisitedCheck(int key, int value)
        {
            foreach (KeyValuePair<int, int> item in _visited)
            {
                if (item.Key == key && item.Value == value)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Adds visited place to list 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddVisitedPlace(int key, int value)
        {
            _visited.Add(new KeyValuePair<int, int>(key, value));
        }


        /// <summary>
        /// Resolves the board  
        /// </summary>
        internal void Start()
        {

            KeyValuePair<int, int> endCharPos = GetEndCharPos();
            Solved = false;
            //  Console.WriteLine("SOLVING ...");
            Console.Clear();
            while (!Solved)
            {

                Console.SetCursorPosition(0, 0);
                Thread.Sleep(500);
                KeyValuePair<int, int> currentpos = GetStartCharPos();
                if (VisitedCheck(endCharPos.Key, endCharPos.Value))
                {
                    Solved = true;
                }

                if (currentpos.Key != endCharPos.Key && currentpos.Key > endCharPos.Key)
                {
                    MoveUp();
                    continue;
                }
                if (currentpos.Key != endCharPos.Key && currentpos.Key < endCharPos.Key)
                {
                    MoveDown();
                    continue;
                }
                if (currentpos.Value != endCharPos.Value && currentpos.Value > endCharPos.Value)
                {
                    MoveLeft();

                    continue;
                }
                if (currentpos.Value != endCharPos.Value && currentpos.Value < endCharPos.Value)
                {
                    MoveRight();
                }

            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"SOLVED !!!\nTotal Cost : {Cost}\nTotal Moves : {Moves}");
            Console.ReadKey();
        }
        #endregion
        #region GetPosMethods

        /// <summary>
        /// Finds the Start Char 
        /// Start Char = &
        /// </summary>
        private KeyValuePair<int, int> GetStartCharPos()
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == '&')
                    {
                        a = i;
                        b = j;
                    }
                }
            }
            return new KeyValuePair<int, int>(a, b);
        }

        /// <summary>
        /// Finds the End Char
        /// End char = $
        /// </summary>
        private KeyValuePair<int, int> GetEndCharPos()
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == '$')
                    {
                        a = i;
                        b = j;
                    }
                }
            }
            return new KeyValuePair<int, int>(a, b);
        }

        #endregion
        #region MoveMethods

        internal List<Char[,]> retList()
        {
            return _moveshistory;
        }
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
        /// <summary>
        /// Moves start Character UP
        /// </summary>
        internal void MoveUp()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            if (_board[currentpos.Key - 1, currentpos.Value] == '$')
            {

                return;
            }
            if (!BorderCheck(_board[currentpos.Key - 1, currentpos.Value]))
            {
                if (!VisitedCheck(currentpos.Key - 1, currentpos.Value))
                {
                    Cost += _board[currentpos.Key - 1, currentpos.Value] - '0';
                    AddVisitedPlace(currentpos.Key - 1, currentpos.Value);

                }
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key - 1, currentpos.Value] = '&';
                Moves++;
                BoardMethods.Show(_board);
            }
        }

        /// <summary>
        /// Moves start Character DOWN
        /// </summary>
        internal void MoveDown()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();

            if (_board[currentpos.Key + 1, currentpos.Value] == '$')
            {
                return;
            }
            if (!BorderCheck(_board[currentpos.Key + 1, currentpos.Value]))
            {
                if (!VisitedCheck(currentpos.Key + 1, currentpos.Value))
                {
                    Cost += _board[currentpos.Key + 1, currentpos.Value] - '0';
                    AddVisitedPlace(currentpos.Key + 1, currentpos.Value);
                }
                _board[currentpos.Key + 1, currentpos.Value] = '&';
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                Moves++;
                BoardMethods.Show(_board);
            }
        }

        /// <summary>
        /// Moves start Character LEFT
        /// </summary>
        internal void MoveLeft()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            if (_board[currentpos.Key, currentpos.Value - 1] == '$')
            {
                return;
            }
            if (!BorderCheck(_board[currentpos.Key, currentpos.Value - 1]))
            {

                if (!VisitedCheck(currentpos.Key, currentpos.Value - 1))
                {
                    Cost += _board[currentpos.Key, currentpos.Value - 1] - '0';
                    AddVisitedPlace(currentpos.Key, currentpos.Value + 1);
                }

                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key, currentpos.Value - 1] = '&';
                Moves++;

                BoardMethods.Show(_board);
            }
        }

        /// <summary>
        /// Moves start Character RIGHT
        /// </summary>
        internal void MoveRight()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            if (_board[currentpos.Key, currentpos.Value + 1] == '$')
            {
                return;
            }
            AddVisitedPlace(currentpos.Key + 1, currentpos.Value);
            if (!BorderCheck(_board[currentpos.Key, currentpos.Value + 1]))
            {
                if (!VisitedCheck(currentpos.Key, currentpos.Value + 1))
                {
                    Cost += _board[currentpos.Key, currentpos.Value + 1] - '0';
                    AddVisitedPlace(currentpos.Key, currentpos.Value + 1);

                }
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key, currentpos.Value + 1] = '&';
                Moves++;

                BoardMethods.Show(_board);
            }
        }

        #endregion
    }
}