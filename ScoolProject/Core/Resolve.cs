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
        /// <summary>
        /// Array of chars which contains board to solve
        /// </summary>
        private char[,] _board;
        
        /// <summary>
        /// CTOR LOL 
        /// </summary>
        /// <param name="board"></param>
        
        internal Resolve(char[,] board)
        {
            _board = board;
        }
        /// <summary>
        /// Check if the specified position is board border 
        /// </summary>
        /// <param name="DrawnIndex"></param>
        /// <returns></returns>
        internal static bool BorderCheck(Char DrawnIndex)
        {
            if (DrawnIndex =='+')
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Prints board to console.
        /// </summary>
        /// <param name="_board"></param>
        internal void Show() => BoardMethods.Show(_board);
        

        internal void Start()
        {
            
        }

        internal void MoveUp()
        { 
            KeyValuePair<int,int> currentpos = GetStartCharPos();
          if (!BorderCheck(_board[currentpos.Key + 1,currentpos.Value] ))
          {
              _board[currentpos.Key, currentpos.Value] = (char)9632;
              _board[currentpos.Key + 1, currentpos.Value] = '&';
              Show();
          }
        }
        internal void MoveDown()
        { 
            KeyValuePair<int,int> currentpos = GetStartCharPos();
            if (!BorderCheck(_board[currentpos.Key - 1, currentpos.Value]))
            {
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key - 1, currentpos.Value] = '&';
                Show();
            }
        }
        internal void MoveLeft()
        { 
            KeyValuePair<int,int> currentpos = GetStartCharPos();
            if (!BorderCheck(_board[currentpos.Key,currentpos.Value - 1] ))
            {
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key, currentpos.Value- 1] = '&';
                Show();
            }
        }
        internal void MoveRight()
        { 
            KeyValuePair<int,int> currentpos = GetStartCharPos();
            if (!BorderCheck(_board[currentpos.Key,currentpos.Value + 1] ))
            {
                _board[currentpos.Key, currentpos.Value] = (char)9632;
                _board[currentpos.Key, currentpos.Value + 1] = '&';
                Show();
            }
        }
        /// <summary>
        /// Finds the Start Char
        /// Start Char = &
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private KeyValuePair<int , int> GetStartCharPos()
        {
            KeyValuePair<int, int> position;
            int a = 0; 
            int b = 0;
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i,j] == '$')
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
        private KeyValuePair<int , int> GetEndCharPos(char[,] board)
        {
            KeyValuePair<int, int> position;
            int a = 0; 
            int b = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j] == '$')
                    {
                        a = i;
                        b = j;
                    }
                }
            }
            position = new KeyValuePair<int, int>(a, b);
            return position;
        }

        
       
    }
}
