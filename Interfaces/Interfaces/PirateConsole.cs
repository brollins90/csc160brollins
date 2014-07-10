using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class PirateConsole : IConsoleViewable
    {
        public string PromptForInput()
        {
            Console.WriteLine("Arrrr, me matey! Enter ye here some worthwhile news and I’ll share with ye me rum!");
            string input = Console.ReadLine();
            return input;
        }

        public void PrintInput(string input)
        {
            Console.WriteLine(input.Replace("r", "-ARR-") + ", me hearty!");
        }
    }
}
