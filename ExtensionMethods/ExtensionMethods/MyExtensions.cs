using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static void P(this IEnumerable<object> ien) {
            String output = "";
            foreach(object o in ien) {
                output += o.ToString();
                output += ", ";
            }
            Console.WriteLine(output.Substring(0,output.Length - 2));
        }

        public static int ToPower(this int x, int y) {
            return (int)Math.Pow(x, y);
        }
    }
}
