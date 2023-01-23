namespace SchoolProject.Cosmetics
{
    internal static class Animations
    {
        #region Methods

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
                if (text[i] == ' ')
                    continue;
                Thread.Sleep(delay.Milliseconds);
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Writes "Press any key to continue ..." 
        /// </summary>
        internal static void PressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey(true);
        }
        #endregion
    }
}