using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public static class ConsoleMenu    {

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

        //public static T PromptForGeneric<T>(string prompt, Func<string, T> parser) where T : IComparable<T>
        //{
        //    Console.WriteLine(prompt);
        //    bool isValid = false;
        //    T result = default(T);

        //    while (!isValid)
        //    {
        //        string input = Console.ReadLine();

        //        try
        //        {
        //            // Will throw an exception if the parse fails
        //            result = parser(input);
        //            isValid = true;
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Value is not a valid type.  Try again.");
        //        }
        //    }
        //    return result;
        //}

        public static bool PromptForBool(string prompt)
        {
            return PromptForGeneric(prompt, null, null, Convert.ToBoolean);
        }

        public static short PromptForByte(string prompt, short? min, short? max)
        {
            return PromptForGeneric(prompt, min, max, Convert.ToInt16); // int16 is a short
        }

        public static short PromptForShort(string prompt, short? min, short? max)
        {
            return PromptForGeneric(prompt, min, max, Convert.ToInt16); // int16 is a short
        }

        public static int PromptForInt(string prompt, int? min, int? max)
        {
            return PromptForGeneric(prompt, min, max, Convert.ToInt32);
        }

        //public static int PromptForMenuSelection(List<String> options, bool allowQuit)
        //{

        //}

        //public static int PromptForInt(string prompt, int? min, int? max)
        //{
        //    Console.WriteLine(prompt);
        //    bool isValid = false;
        //    int result = int.MinValue;
        //    while (!isValid)
        //    {
        //        string input = Console.ReadLine();

        //        try
        //        {
        //            result = int.Parse(input);
        //            if ((min != null && result < min) || (max != null && result > max))
        //            {
        //                throw new Exception();
        //            }
        //            isValid = true;
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Invalid value, Try again.");
        //        }
        //    }
        //    return result;
        //}

        //public static long PromptForLong(string prompt, long? min, long? max)
        //{

        //}

        //public static float PromptForFloat(string prompt, float? min, float? max)
        //{

        //}

        //public static double PromptForDouble(string prompt, double? min, double? max)
        //{

        //}

        //public static decimal PromptForDecimal(string prompt, decimal? min, decimal? max)
        //{

        //}

        //public static string PromptForInput(string prompt)
        //{

        //}

        //public static char PromptForChar(string prompt, char? min, char? max)
        //{

        //}
    }
}
