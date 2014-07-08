using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC160_ConsoleMenu
{
    public static class CIO
    {
        public static T PromptForGeneric<T>(string prompt, Nullable<T> min, Nullable<T> max, Func<string, T> parser) where T : struct, IComparable<T>
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

        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            throw new NotImplementedException();
        }

        public static bool PromptForBool(string message)
        {
            return PromptForGeneric(message, null, null, Convert.ToBoolean);
        }

        public static bool PromptForBool(string message, string trueString, string falseString)
        {
            //return PromptForGeneric(message, null, null, Convert.ToBoolean);
            throw new NotImplementedException();
        }

        public static byte PromptForByte(string message, byte min, byte max)
        {
            return PromptForGeneric(message, min, max, Convert.ToByte);
        }

        public static short PromptForShort(string message, short min, short max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt16);
        }

        public static int PromptForInt(string message, int min, int max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt32);
        }

        public static long PromptForLong(string message, long min, long max)
        {
            return PromptForGeneric(message, min, max, Convert.ToInt64);
        }

        public static float PromptForFloat(string message, float min, float max)
        {
            return PromptForGeneric(message, min, max, Convert.ToSingle);
        }

        public static double PromptForDouble(string message, double min, double max)
        {
            return PromptForGeneric(message, min, max, Convert.ToDouble);
        }

        public static decimal PromptForDecimal(string message, decimal min, decimal max)
        {
            return PromptForGeneric(message, min, max, Convert.ToDecimal);
        }

        public static string PromptForInput(string message, bool allowEmpty)
        {
            //return PromptForGeneric(message, null, null, Convert.ToString);
            throw new NotImplementedException();
        }

        public static char PromptForChar(string message, char min, char max)
        {
            return PromptForGeneric(message, min, max, Convert.ToChar);
        }
    }
}