using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;

namespace ConsoleMenuTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool b = ConsoleMenu.ConsoleMenu.PromptForBool("haha");
            Console.WriteLine("Bool: " + b);
            //int i = ConsoleMenu.ConsoleMenu.PromptForGenericWithBounds("hello", 1, 10, Convert.ToInt32);
            //Console.WriteLine(i);
        }
    }
}
