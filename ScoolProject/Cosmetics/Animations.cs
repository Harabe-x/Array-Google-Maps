using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Cosmetics
{
    internal static class Animations
    {
        /// <summary>
        /// Writes string char by char with specified delay 
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="dealy"></param>
        internal static void WriteAnimation(String Text , TimeSpan dealy)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                Console.Write(Text[i]);
                Thread.Sleep(dealy.Milliseconds);            
            }
            Console.WriteLine();
        }
    }
}
