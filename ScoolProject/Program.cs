using SchoolProject.Core;
using System;
using System.Collections.Generic;

namespace ShcoolProject;

class Program
{
    internal static void Main(string[] args)
    {
        int size;
        Console.WriteLine("Enter board size :");
         int.TryParse(Console.ReadLine(), out size);
         BoardMethods.Show(BoardMethods.FillBoard(BoardMethods.Generate(size),size));
        Console.Clear();
        for (int i = 0; i < 10000; i++)
        {
            BoardMethods.Show(BoardMethods.FillBoard(BoardMethods.Generate(size), size));
             Console.ReadLine();
            //Thread.Sleep(150);
            Console.SetCursorPosition(0, 0);
          
           
        }        
    }
}
