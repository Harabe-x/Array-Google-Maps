using SchoolProject.Core;

namespace ShcoolProject;

class Program
{
    internal static void Main(string[] args)
    {
        bool condition = true;
        ConsoleKey key;
        //int size;
        //Animations.WriteAnimation("Enter size :", TimeSpan.FromMilliseconds(0));
        //int.TryParse(Console.ReadLine(), out size);
        Resolve res = new Resolve(BoardMethods.FillBoard(BoardMethods.Generate(24)));
        Console.Clear();
        Console.Clear();
        // while (condition)
        // {
        //     key = Console.ReadKey().Key;
        //     switch (key)
        //     {
        //         case ConsoleKey.A :
        //             
        //          //   Thread.Sleep(1000); 
        //             Console.SetCursorPosition(0,0);
        //             break;
        //         case ConsoleKey.D : 
        //             res.MoveRight();
        //            // Thread.Sleep(1000); 
        //             Console.SetCursorPosition(0,0); 
        //             break;
        //         case ConsoleKey.W :
        //             res.MoveUp();
        //        //     Thread.Sleep(1000); 
        //             Console.SetCursorPosition(0,0);
        //             break;
        //         case ConsoleKey.S :
        //             Console.Clear();
        //             res.Start();
        //           Thread.Sleep(1000); 
        //             Console.SetCursorPosition(0,0);
        //             break;
        //         case ConsoleKey.Backspace :
        //             condition = false;
        //             break; 
        //         case ConsoleKey.E :
        //             Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n KOSZT:" + res.GetCostOfMoveDown());;
        //             break;
        //     }
        //     
        // }
        //
        // var x = res.retList();
        // Console.Clear();
        // foreach (var c in x)
        // {
        //     for (int i = 0; i < c.GetLength(0); i++)
        //     {
        //         for (int k = 0; k < c.GetLength(1); k++)
        //         {
        //             Console.Write(c[i,k]);
        //         }
        //
        //         Console.WriteLine();
        //     }
        // }
        res.Start();
        Console.ReadKey();
    }
}
