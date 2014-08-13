using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DLinkedList<string> myStructure = new DLinkedList<string>();
            myStructure.Add("number 1");
            Console.WriteLine(myStructure.ToString());
            myStructure.Add("number 2");
            Console.WriteLine(myStructure.ToString());
            myStructure.Add("number 3");
            Console.WriteLine(myStructure.ToString());
            myStructure.Insert("insert at 0", 0);
            Console.WriteLine(myStructure.ToString());
            myStructure.Insert("insert at 1", 1);
            Console.WriteLine(myStructure.ToString());
            myStructure.Insert("insert at 0", 0);
            Console.WriteLine(myStructure.ToString());
            myStructure.Insert("insert at 10", 10);
            Console.WriteLine(myStructure.ToString());

            Console.WriteLine("at 0 " + myStructure.Get(0));
            Console.WriteLine("at 4 " + myStructure.Get(4));
            Console.WriteLine("at end " + myStructure.Get(myStructure.Size - 1));

            Console.WriteLine("Remove " + myStructure.Remove());

            Console.WriteLine("RemoveAt(4) " + myStructure.RemoveAt(4));

            Console.WriteLine("RemoveLast " + myStructure.RemoveLast());
            Console.WriteLine("Search: " + myStructure.Search("number 2"));

            Console.WriteLine(myStructure.ToString());
            myStructure.Clear();

            Console.WriteLine(myStructure.ToString());
            myStructure.Add("3");
            myStructure.Add("2");
            myStructure.Add("1");
            myStructure.Add("7");
            myStructure.Add("9");
            myStructure.Add("8");
            Console.WriteLine(myStructure.ToString());
            myStructure.Sort();
            Console.WriteLine(myStructure.ToString());


            Console.WriteLine("ALL DONE!");
            string wait = Console.ReadLine();
        }
    }
}
