using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        IConsoleViewable _TheConsole;

        public Program(IConsoleViewable con)
        {
            _TheConsole = con;
            Run();
        }

        public void Run()
        {
            string input = _TheConsole.PromptForInput();
            _TheConsole.PrintInput(input);
        }

        public static void Main(string[] args)
        {
            IConsoleViewable theConsoleWeGunnaUse = new PirateConsole();
            try
            {
                int temp = Convert.ToInt32(args[0]);
                if (temp == 2)
                {
                    theConsoleWeGunnaUse = new PrettyConsole();
                }
                else if (temp == 3)
                {
                    theConsoleWeGunnaUse = new AngryConsole();
                }
            } catch (Exception) {

            }
            Program p = new Program(theConsoleWeGunnaUse);
        }
    }
}
