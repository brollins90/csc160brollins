using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class PrettyConsole : IConsoleViewable
    {
        public string PromptForInput()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tell me something pretty");
            Console.ResetColor();
            string input = Console.ReadLine();
            return input;
        }

        public void PrintInput(string input)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(input);
            Console.ResetColor();
        }
    }
}
