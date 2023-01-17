public class PathCost
{
    public string Path { get; set; }
    public int Cost { get; set; }

    public PathCost(string path, int cost)
    {
        Path = path;
        Cost = cost;
    }
}