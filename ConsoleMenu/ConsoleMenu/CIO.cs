using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC160_ConsoleMenu
{
    /// <summary>
    /// The CIO class is used to aid in Console I/O
    /// Lab 2 in CSC160
    /// Blake Rollins
    /// </summary>
    public static class CIO
    {
        /// <summary>
        /// Will display the prompt at the Console and check for the correct input allowed by the parser function
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="prompt">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <param name="parser">The function called to validate the input</param>
        /// <returns>The value entered at the Console</returns>
        private static T PromptForGeneric<T>(string prompt, T? min, T? max, Func<string, T> parser) where T : struct, IComparable<T>
        {
            if (prompt == null)
            {
                throw new ArgumentException("The prompt cannot be empty.");
            }
            if (min != null)
            {
                if (max != null)
                {
                    T minTemp = (T)min;
                    if (minTemp.CompareTo((T)max) > 0)
                    {
                        throw new ArgumentException("min must be less than max");
                    }
                    else
                    {
                        // we good
                    }
                }
            }
            else
            {
                if (max != null)
                {
                    throw new ArgumentException("cannot specify a max without a min.");
                }
            }

            Console.WriteLine(prompt);
            bool isValid = false;
            T result = default(T);

            while (!isValid)
            {
                string input = Console.ReadLine();

                try
                {
                    // Will throw an exception if the parse fails, then we only need to check the bounds
                    result = parser(input);
                    if (min != null && result.CompareTo((T)min) < 0)
                    {
                        Console.WriteLine("Value is too low.  Try again.");
                    }
                    else if (max != null && result.CompareTo((T)max) > 0)
                    {
                        Console.WriteLine("Value is too high.  Try again.");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Value is not a valid type.  Try again.");
                }
            }
            return result;
        }

        /// <summary>
        /// Prompts the User for a bool
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <returns>The value entered at the Console</returns>
        public static bool PromptForBool(string message)
        {
            return PromptForGeneric(message, null, null, Convert.ToBoolean);
        }
        
        /// <summary>
        /// Prompts the User for a bool
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="trueString">The string that equates to True</param>
        /// <param name="falseString">The string that equates to False</param>
        /// <returns>The value entered at the Console</returns>
        public static bool PromptForBool(string message, string trueString, string falseString)
        {
            Console.WriteLine(message);
            bool isValid = false;
            bool result = default(bool);

            while (!isValid)
            {
                string input = Console.ReadLine();

                try
                {
                    if (input.Equals(trueString))
                    {
                        result = true;
                        isValid = true;
                    }
                    else if (input.Equals(falseString))
                    {
                        result = false;
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Response is not valid.  Try again.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Response is not valid.  Try again.");
                }
            }
            return result;
        }

        /// <summary>
        /// Prompts the User for a byte
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns></returns>
        public static byte PromptForByte(string message, byte min, byte max)
        {
            return PromptForGeneric(message, min, max, Convert.ToByte);
        }

        /// <summary>
        /// Prompts the User for a char
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns>The value entered at the Console</returns>
        public static char PromptForChar(string message, char min, char max)
        {
            return PromptForGeneric(message, min, max, Convert.ToChar);
        }

        /// <summary>
        /// Prompts the User for a decimal
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns>The value entered at the Console</returns>
        public static decimal PromptForDecimal(string message, decimal min, decimal max)
        {
            return PromptForGeneric(message, min, max, Convert.ToDecimal);
        }

        /// <summary>
        /// Prompts the User for a double
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns>The value entered at the Console</returns>
        public static double PromptForDouble(string message, double min, double max)
        {
            return PromptForGeneric(message, min, max, Convert.ToDouble);
        }

        /// <summary>
        /// Prompts the User for a float
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns>The value entered at the Console</returns>
        public static float PromptForFloat(string message, float min, float max)
        {
            return PromptForGeneric(message, min, max, Convert.ToSingle);
        }

        /// <summary>
        /// Prompts the User for a string
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="allowEmpty">If any empty string is acceptable</param>
        /// <returns>The value entered at the Console</returns>
        public static string PromptForInput(string message, bool allowEmpty)
        {
            Console.WriteLine(message);
            bool isValid = false;
            string result = default(string);

            while (!isValid)
            {
                result = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(result))
                {
                    if (allowEmpty)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Response cannot be empty.  Try again.");
                        isValid = false;
                    }
                }
                else
                {
                    isValid = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Prompts the User for a float
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns>The value entered at the Console</returns>
        public static int PromptForInt(string message, int min, int max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt32);
        }

        /// <summary>
        /// Prompts the User for a long
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns>The value entered at the Console</returns>
        public static long PromptForLong(string message, long min, long max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt64);
        }

        /// <summary>
        /// Prompts the user to make a choice out of the specified options
        /// </summary>
        /// <param name="options">The set of strings that are options</param>
        /// <param name="withQuit">If option 0 should be set to Quit</param>
        /// <returns></returns>
        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            int minMenuItem = (withQuit) ? 0 : 1;
            int maxMenuItem = options.Count();
            if (maxMenuItem == 0 /*|| minMenuItem > maxMenuItem */)
            {
                throw new ArgumentException("The list of options cannot be empty.");
            }

            if (withQuit)
            {
                Console.WriteLine("0: Quit");
            }
            for (int i = 0; i < maxMenuItem; i++)
            {
                Console.WriteLine((i + 1) + ": " + options.ElementAt(i));
            }
            int selection = PromptForInt("", minMenuItem, maxMenuItem);
            return selection;
        }

        /// <summary>
        /// Prompts the User for a short
        /// </summary>
        /// <param name="message">The question to ask at the Console</param>
        /// <param name="min">The minimum accepted value (if any)</param>
        /// <param name="max">The maximum accepted value (if any)</param>
        /// <returns>The value entered at the Console</returns>
        public static short PromptForShort(string message, short min, short max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt16);
        }
    }
}