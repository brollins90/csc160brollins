using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        /// <summary>
        /// Returns a bool if the int is even
        /// </summary>
        /// <param name="i">The int to check for eveness</param>
        /// <returns>If the int is even.</returns>
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        /// <summary>
        /// Returns a bool signifying whether the string is a palindrome 
        /// </summary>
        /// <param name="s">The string to test for palendronism.</param>
        /// <returns>A bool signifying whether the string is a palindrome.</returns>
        public static bool IsPalindrome(this string s)
        {
            int i = 0;
            char[] sArray = s.ToCharArray();
            for (int j = s.Length - 1; i < j; j--)
            {
                if (sArray[i] != sArray[j])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        /// <summary>
        /// Prints out the objects in any collection, separating each value with a comma.
        /// </summary>
        /// <param name="ien">The enumerable set of objects to be printed.</param>
        public static void P(this IEnumerable<object> ien)
        {
            String output = "";
            foreach (object o in ien)
            {
                output += o.ToString();
                output += ", ";
            }
            Console.WriteLine(output.Substring(0, output.Length - 2));
        }

        /// <summary>
        /// Returns a reversed copy of the string.
        /// </summary>
        /// <param name="s">The string to reverse</param>
        /// <returns>A string that a reverse copy</returns>
        public static string Reverse(this string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// Returns the value of the original int raised to the power of the exponent parameter
        /// </summary>
        /// <param name="integer"></param>
        /// <param name="exponent"></param>
        /// <returns>The value of the int raised to the specified power.</returns>
        public static int ToPower(this int integer, int exponent) {
            return (int)Math.Pow(integer, exponent);
        }

        /// <summary>
        /// Converts a string to an int
        /// </summary>
        /// <param name="s">The string to convert</param>
        /// <returns>The int that is represented in the string</returns>
        public static int ToInt(this string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
