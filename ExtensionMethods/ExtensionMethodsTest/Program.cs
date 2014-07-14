using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace ExtensionMethodsTest
{
    class Program
    {
        /// <summary>
        /// Some tests for the Extension methods
        /// 
        /// Blake Rollins
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("An example of a collection being printed as a comma delimited string:");
            List<string> l1 = new List<string>() {
                "one",
                "two",
                "three"
            };
            l1.P();
            Console.WriteLine("");

            Console.WriteLine("An example of an int raised to a power:");
            int intToPower = 5.ToPower(2);
            Console.WriteLine("{0} raised to {1}: {2}",5, 2, intToPower);
            Console.WriteLine("");

            Console.WriteLine("An example of a palindrome string:");
            string palindromeString = "bob";
            Console.WriteLine("'{0}' is palindrome: {1}", palindromeString, palindromeString.IsPalindrome());
            Console.WriteLine("");
            
            Console.WriteLine("An example of a non-palindrome string:");
            string nonPalindromeString = "bob2";
            Console.WriteLine("'{0}' is palindrome: {1}", nonPalindromeString, nonPalindromeString.IsPalindrome());
            Console.WriteLine("");

            Console.WriteLine("An example of a covnerting a string to an int:");
            string intString = "5";
            Console.WriteLine("{0} is {1}", intString, intString.ToInt());
            Console.WriteLine("");

            Console.WriteLine("An example of a reversing a string:");
            string rev = "reversie";
            Console.WriteLine("{0} reversed: {1}", rev, rev.Reverse());
            Console.WriteLine("");

            Console.WriteLine("An example of a checking an int for evenness and oddness:");
            Console.WriteLine("2: {0}", 2.IsEven());
            Console.WriteLine("15: {0}", 15.IsEven());

        }
    }
}
