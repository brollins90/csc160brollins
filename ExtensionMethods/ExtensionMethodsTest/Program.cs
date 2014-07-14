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
        static void Main(string[] args)
        {
            int i1 = 5.ToPower(2);
            Console.WriteLine(i1);
        }
    }
}
