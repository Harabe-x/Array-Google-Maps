internal class PathCost
{
    #region Fields
    /// <summary>
    /// path to the goal
    /// </summary>
    public string Path { get; set; }
    /// <summary>
    /// Total cost 
    /// </summary>
    public int Cost { get; set; }
    /// <summary>
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cost"></param>
    #endregion
    #region Ctor
    public PathCost(string path, int cost)
    {
        Path = path;
        Cost = cost;
    }
    #endregion
    #region Methods
    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"Moves:{Path}\nCost:{Cost}";
    }
    #endregion
}