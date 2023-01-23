using SchoolProject.Core;
namespace SchoolProject.Cosmetics;

internal class Visualizer
{
    #region Fields

    /// <summary>
    ///  board 
    /// </summary>
    private readonly string[,] _board;
    
    /// <summary>
    ///  PathCost
    /// </summary>

    private readonly PathCost _pathCost;
    #endregion
    #region Enum
    /// <summary>
    /// Move Types
    /// </summary>
    private enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }
    #endregion
    #region Ctor
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="keyValuePair"></param>
    public Visualizer(KeyValuePair<PathCost, string[,]> keyValuePair)
    {
        _board = keyValuePair.Value;
        _pathCost = keyValuePair.Key;
    }
    #endregion
    #region Methods
    /// <summary>
    /// Visually goes from point a to b 
    /// </summary>
    /// <param name="direction"></param>
    private void Move(Direction direction)
    {
        var currentPos = Resolve.GetStartCharPos(_board);
        switch (direction)
        {
            case Direction.Up:
                _board[currentPos.Key, currentPos.Value] = "■";
                _board[currentPos.Key - 1, currentPos.Value] = "&";
                BoardMethods.Show(_board);
                break;
            case Direction.Down:
                _board[currentPos.Key, currentPos.Value] = "■";
                _board[currentPos.Key + 1, currentPos.Value] = "&";
                BoardMethods.Show(_board);
                break;
            case Direction.Left:
                _board[currentPos.Key, currentPos.Value] = "■";
                _board[currentPos.Key, currentPos.Value - 1] = "&";
                BoardMethods.Show(_board);
                break;
            case Direction.Right:
                _board[currentPos.Key, currentPos.Value] = "■";
                _board[currentPos.Key, currentPos.Value + 1] = "&";
                BoardMethods.Show(_board);
                break;
        }
    }
    /// <summary>
    /// interprets  given string in Ctor 
    /// </summary>
    internal void Visualize()
    {
        foreach (var item in _pathCost.Path)
        {
            Console.WriteLine(_pathCost);
            switch (item)
            {
                case 'U':
                    Move(Direction.Up);
                    break;
                case 'D':
                    Move(Direction.Down);
                    break;
                case 'L':
                    Move(Direction.Left);
                    break;
                case 'R':
                    Move(Direction.Right);
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine(_pathCost);

    }
    #endregion
}