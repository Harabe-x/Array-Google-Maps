using SchoolProject.Core;
using SchoolProject.Cosmetics;
namespace SchoolProject;

internal class Program
{
    internal static void Main(string[] args)
    {
        RunMainMenu();
    }
    
    
    /// <summary>
    /// Runs Main menu 
    /// </summary> 
    private static void RunMainMenu()
    {
        Console.Title = "Onion V1.0 ";
        string[] options = { "Start", "How to use?", "Credits", "Exit" }
            ;

        var menu = new Menu(options, @" ▒█████   ███▄    █  ██▓ ▒█████   ███▄    █ 
▒██▒  ██▒ ██ ▀█   █ ▓██▒▒██▒  ██▒ ██ ▀█   █ 
▒██░  ██▒▓██  ▀█ ██▒▒██▒▒██░  ██▒▓██  ▀█ ██▒
▒██   ██░▓██▒  ▐▌██▒░██░▒██   ██░▓██▒  ▐▌██▒
░ ████▓▒░▒██░   ▓██░░██░░ ████▓▒░▒██░   ▓██░
░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ 
  ░ ▒ ▒░ ░ ░░   ░ ▒░ ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░
░ ░ ░ ▒     ░   ░ ░  ▒ ░░ ░ ░ ▒     ░   ░ ░ 
    ░ ░           ░  ░      ░ ░           ░ 
                                                                                                                                                                                               
 Use Arrows to Select an option:
");
        var selectedIndex = menu.Run();
        switch (selectedIndex)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("Please Wait...");
                var res = new Resolve(BoardMethods.FillBoard(BoardMethods.Generate(10)));
                var resolvedBoard = res.ReturnPair();
                var visualizer = new Visualizer(resolvedBoard);
                Console.Clear();
                BoardMethods.Show(resolvedBoard.Value);
                Console.ReadKey(true);
                Console.Clear();
                visualizer.Visualize();
                BoardMethods.Show(resolvedBoard.Value);
                Animations.PressKeyToContinue();
                Console.Clear();
                RunMainMenu();
                break;
            case 1:
                Console.Clear();
                Animations.WriteAnimation("Just Select \"Start\" and click ENTER  " , TimeSpan.FromMilliseconds(75));
                Animations.PressKeyToContinue();
                RunMainMenu();
                break;
            case 2:
                Console.Clear();
                Animations.WriteAnimation("Main Developer: Harabe-X\nUI designer: Harabe-X\nRepository manager: Harabe-X\nProject idea: Michał Cybulski \n\n\nSpecial Thanks to: \nStackOverflow users " , TimeSpan.FromMilliseconds(100));
                Animations.PressKeyToContinue();
                RunMainMenu();
                break;
            case 3:
                Console.ResetColor();
                Console.Clear();
                Animations.PressKeyToContinue();
                Environment.Exit(0);
                break;
                
                
        }
    }
}