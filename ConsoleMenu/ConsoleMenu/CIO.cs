using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC160_ConsoleMenu
{
    public static class CIO
    {

        public static T PromptForGeneric<T>(string prompt, T? min, T? max, Func<string, T> parser) where T : struct, IComparable<T>
        {
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

        public static bool PromptForBool(string message)
        {
            return PromptForGeneric(message, null, null, Convert.ToBoolean);
        }

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

        public static byte PromptForByte(string message, byte min, byte max)
        {
            return PromptForGeneric(message, min, max, Convert.ToByte);
        }

        public static char PromptForChar(string message, char min, char max)
        {
            return PromptForGeneric(message, min, max, Convert.ToChar);
        }

        public static decimal PromptForDecimal(string message, decimal min, decimal max)
        {
            return PromptForGeneric(message, min, max, Convert.ToDecimal);
        }

        public static double PromptForDouble(string message, double min, double max)
        {
            return PromptForGeneric(message, min, max, Convert.ToDouble);
        }

        public static float PromptForFloat(string message, float min, float max)
        {
            return PromptForGeneric(message, min, max, Convert.ToSingle);
        }

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

        public static int PromptForInt(string message, int min, int max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt32);
        }

        public static long PromptForLong(string message, long min, long max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt64);
        }

        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            int minMenuItem = (withQuit) ? 0 : 1;
            int maxMenuItem = options.Count();

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

        public static short PromptForShort(string message, short min, short max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt16);
        }
    }
}