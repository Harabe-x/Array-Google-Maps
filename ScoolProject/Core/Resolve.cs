using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolProject.Core.BoardMethods;

namespace SchoolProject.Core
{
    internal class Resolve
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        public int cost { get; set; }

        /// <summary>
        /// Array of chars which contains board to solve
        /// </summary>
        private char[,] _board;

        /// <summary>
        ///  Array thats stores visited places 
        /// </summary>
        private Dictionary<int, int> _visited;

        #endregion
        #region ctor

        /// <summary>
        /// CTOR LOL 
        /// </summary>
        /// <param name="board"></param>
        internal Resolve(char[,] board)
        {
            _board = board;
            _visited = new Dictionary<int, int>();
        }

        #endregion
        #region Private Methods
        /// <summary>
        /// Check if the specified position is board border 
        /// </summary>
        /// <param name="DrawnIndex"></param>
        /// <returns></returns>

       

        internal static bool BorderCheck(Char DrawnIndex)
        {
            if (DrawnIndex == '+')
            {
                return true;
            }

            return false;
        }

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

        private void AddVisitedPlace(int key , int value)
        {
            _visited.Add(key ,value);
        }
   

        /// <summary>
        /// Not implemented yet 
        /// </summary>
        internal void Start()
        {
        }
        #endregion
        #region GetPosMethods

        /// <summary>
        /// Finds the Start Char 
        /// Start Char = &
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private KeyValuePair<int, int> GetStartCharPos()
        {
            KeyValuePair<int, int> position;
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

            position = new KeyValuePair<int, int>(a, b);
            return position;
        }

        /// <summary>
        /// Finds the End Char
        /// End char = $
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private KeyValuePair<int, int> GetEndCharPos(char[,] board)
        {
            KeyValuePair<int, int> position;
            int a = 0;
            int b = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '$')
                    {
                        a = i;
                        b = j;
                    }
                }
            }

            position = new KeyValuePair<int, int>(a, b);
            return position;
        }

        #endregion
        #region MoveMethods

        /// <summary>
        /// Moves start Character UP
        /// </summary>
        internal void MoveUp()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            AddVisitedPlace(currentpos.Key - 1, currentpos.Value);
            if (!BorderCheck(_board[currentpos.Key - 1, currentpos.Value]))
            {
                if (!VisitedCheck(currentpos.Key - 1, currentpos.Value ))
                {
                    cost += _board[currentpos.Key - 1, currentpos.Value ] - '0';
                }
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key - 1, currentpos.Value] = '&';
                Console.WriteLine($"Total cost: {cost}");
                AddVisitedPlace(currentpos.Key - 1, currentpos.Value );

                BoardMethods.Show(_board);
            }
        }

        /// <summary>
        /// Moves start Character DOWN
        /// </summary>
        internal void MoveDown()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            AddVisitedPlace(currentpos.Key + 1, currentpos.Value);

            if (!BorderCheck(_board[currentpos.Key + 1, currentpos.Value]))
            {
                if (!VisitedCheck(currentpos.Key + 1, currentpos.Value ))
                {
                    cost += _board[currentpos.Key + 1, currentpos.Value ] - '0';
                }
                _board[currentpos.Key + 1, currentpos.Value] = '&';
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                AddVisitedPlace(currentpos.Key + 1, currentpos.Value );
                Console.WriteLine($"Total cost: {cost}");
                BoardMethods.Show(_board);
            }
        }

        /// <summary>
        /// Moves start Character LEFT
        /// </summary>
        internal void MoveLeft()
        {
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            AddVisitedPlace(currentpos.Key , currentpos.Value -1);

            if (!BorderCheck(_board[currentpos.Key, currentpos.Value - 1]))
            {
                if (!VisitedCheck(currentpos.Key, currentpos.Value - 1))
                {
                    cost += _board[currentpos.Key, currentpos.Value - 1] - '0';
                }
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key, currentpos.Value - 1] = '&';
                AddVisitedPlace(currentpos.Key , currentpos.Value + 1 );
                Console.WriteLine($"Total cost: {cost}");
                BoardMethods.Show(_board);
            }
        }

        /// <summary>
        /// Moves start Character RIGHT
        /// </summary>
        internal void MoveRight()
        {
            
            KeyValuePair<int, int> currentpos = GetStartCharPos();
            AddVisitedPlace(currentpos.Key - 1, currentpos.Value);
            if (!BorderCheck(_board[currentpos.Key, currentpos.Value + 1]))
            {
                if (!VisitedCheck(currentpos.Key, currentpos.Value + 1))
                {
                    cost += _board[currentpos.Key, currentpos.Value + 1] - '0';
                }
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key, currentpos.Value + 1] = '&';
                AddVisitedPlace(currentpos.Key , currentpos.Value + 1 );
                Console.WriteLine($"Total cost: {cost}");
                BoardMethods.Show(_board);
            }
        }

        #endregion
    }
}