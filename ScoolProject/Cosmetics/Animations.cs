namespace SchoolProject.Cosmetics
{
    internal static class Animations
    {
        /// <summary>
        /// Writes string char by char with specified delay 
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delay"></param>
        internal static void WriteAnimation(String text, TimeSpan delay)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(delay.Milliseconds);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Makes board displaying smooth
        /// </summary>
        /// <param name="delay"></param>
        internal static void ClearAndWait(TimeSpan delay)
        {
            Console.ReadKey();
            Console.SetCursorPosition(0, 0);
        }
    }
}