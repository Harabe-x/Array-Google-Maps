using SchoolProject.Core;
using SchoolProject.Cosmetics;
namespace SchoolProject;

internal class Program
{
    internal static void Main(string[] args)
    {
        var res = new Resolve(BoardMethods.FillBoard(BoardMethods.Generate(10)));
        var resolvedBoard = res.ReturnPair();
        var visualizer = new Visualizer(resolvedBoard);
        visualizer.Visualize();
        BoardMethods.Show(resolvedBoard.Value);
        Console.ReadKey();
    }
}