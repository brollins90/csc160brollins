using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class AngryConsole : IConsoleViewable
    {
        public string PromptForInput()
        {
            Console.WriteLine("Hmph, I dont like your input, but tell me anyway.");
            string input = Console.ReadLine();
            return input;
        }

        public void PrintInput(string input)
        {
            Console.WriteLine(input.ToUpper());
        }
    }
}
