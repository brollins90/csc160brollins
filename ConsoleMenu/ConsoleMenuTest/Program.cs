using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;

namespace ConsoleMenuTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<string> options = new List<string>() { "Option 1", "Option 2" };
            //int fromMenuFalse = CSC160_ConsoleMenu.CIO.PromptForMenuSelection(options, false);
            //Console.WriteLine("fromMenuFalse: " + fromMenuFalse);

            //int fromMenuTrue = CSC160_ConsoleMenu.CIO.PromptForMenuSelection(options, true);
            //Console.WriteLine("fromMenuTrue: " + fromMenuTrue);

            bool bool1 = CSC160_ConsoleMenu.CIO.PromptForBool("Enter a boolean (Mine).");
            Console.WriteLine("bool1: " + bool1);

            //bool bool2 = CSC160_ConsoleMenu.CIO.PromptForBool("Enter a boolean.", "true", "false");
            //Console.WriteLine("bool2: " + bool2);

            byte byte1 = CSC160_ConsoleMenu.CIO.PromptForByte("Enter a byte.", 1, 10);
            Console.WriteLine("byte1: " + byte1);

            short short1 = CSC160_ConsoleMenu.CIO.PromptForShort("Enter a short.", 1, 10);
            Console.WriteLine("short1: " + short1);

            int int1 = CSC160_ConsoleMenu.CIO.PromptForInt("Enter a int.", 1, 10);
            Console.WriteLine("int1: " + int1);

            long long1 = CSC160_ConsoleMenu.CIO.PromptForLong("Enter a long.", 1, 10);
            Console.WriteLine("long1: " + long1);

            float float1 = CSC160_ConsoleMenu.CIO.PromptForFloat("Enter a float.", 1, 10);
            Console.WriteLine("float1: " + float1);

            double double1 = CSC160_ConsoleMenu.CIO.PromptForDouble("Enter a double.", 1, 10);
            Console.WriteLine("double1: " + double1);

            decimal decimal1 = CSC160_ConsoleMenu.CIO.PromptForDecimal("Enter a decimal.", 1, 10);
            Console.WriteLine("decimal1: " + decimal1);

            //string string1 = CSC160_ConsoleMenu.CIO.PromptForInput("Enter a string (allow empty).", true);
            //Console.WriteLine("string1: " + string1);

            //string string2 = CSC160_ConsoleMenu.CIO.PromptForInput("Enter a string.", false);
            //Console.WriteLine("string2: " + string2);

            char char1 = CSC160_ConsoleMenu.CIO.PromptForChar("Enter a char (a-z).", 'a', 'z');
            Console.WriteLine("char1: " + char1);

        }
    }
}
