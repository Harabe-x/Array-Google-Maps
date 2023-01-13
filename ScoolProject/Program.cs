using SchoolProject.Core;
using SchoolProject.Cosmetics;
using System;
using System.Collections.Generic;

namespace ShcoolProject;

class Program
{
    internal static void Main(string[] args)
    {
        ConsoleKey key;
        //int size;
        //Animations.WriteAnimation("Enter size :", TimeSpan.FromMilliseconds(0));
        //int.TryParse(Console.ReadLine(), out size);
        Resolve res = new Resolve(BoardMethods.FillBoard(BoardMethods.Generate(10)));
        Console.Clear();
        Console.Clear();
        while (true)
        {
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.A :
                    res.MoveLeft(); 
                 //   Thread.Sleep(1000); 
                    Console.SetCursorPosition(0,0);
                    break;
                case ConsoleKey.D : 
                    res.MoveRight();
                   // Thread.Sleep(1000); 
                    Console.SetCursorPosition(0,0); 
                    break;
                case ConsoleKey.W :
                    res.MoveUp();
               //     Thread.Sleep(1000); 
                    Console.SetCursorPosition(0,0);
                    break;
                case ConsoleKey.S :
                    res.MoveDown();
                //    Thread.Sleep(1000); 
                    Console.SetCursorPosition(0,0);
                    break;
                case ConsoleKey.Backspace :
                    return;
            }
        }
    }
}
