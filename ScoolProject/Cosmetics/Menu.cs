using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace SchoolProject.Cosmetics;

internal class Menu
{
    private  int _selectedIndex;
    private readonly string[] _options;
    private readonly string _prompt;
    private bool _firstTime = true;

    public Menu(string[] options, string prompt)
    {
        _selectedIndex = 0;
        _options = options;
        _prompt = prompt;
        Console.CursorVisible = false;
    }

    internal int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.ResetColor();
            Console.SetCursorPosition(0,0);
          // Console.SetCursorPosition(0,0);
            DisplayOptions();
            var keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex == _options.Length)
                    _selectedIndex = 0;

                    
            }
            else if (keyPressed == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex == - 1)
                    _selectedIndex = _options.Length - 1;
                        
            }
        } while (keyPressed != ConsoleKey.Enter);


        return _selectedIndex;
    }

    private void DisplayOptions()
    {
        if (_firstTime)
        {
            Animations.WriteAnimation(_prompt, TimeSpan.FromMilliseconds(5));
            _firstTime = ! _firstTime;
        }
        else
        {
            Console.WriteLine(_prompt);
        }
        for (int i = 0; i < _options.Length; i++)
        {
            
            var currentOption = _options[i];
            string prefix;
            if (i == _selectedIndex)
            {

                prefix = "*";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            }

            Console.WriteLine($"{prefix} << {currentOption} >>");
        }
    }
}