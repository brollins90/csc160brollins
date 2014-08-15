using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_GenericLinkedList;

namespace LinkedListDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericLinkedList<string> myStructure = new GenericLinkedList<string>();
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
            Console.WriteLine("at end " + myStructure.Get(myStructure.Count - 1));

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
            myStructure.Add("9");
            myStructure.Add("8");
            Console.WriteLine(myStructure.ToString());
            myStructure.Sort();
            Console.WriteLine(myStructure.ToString());
            myStructure.Sort(true);
            Console.WriteLine(myStructure.ToString());


            // ints

            GenericLinkedList<int> myStructure2 = new GenericLinkedList<int>();
            myStructure2.Add(1);
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Add(2);
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Add(3);
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Insert(4, 0);
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Insert(5, 1);
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Insert(6, 0);
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Insert(7, 10);
            Console.WriteLine(myStructure2.ToString());

            Console.WriteLine("at 0 " + myStructure2.Get(0));
            Console.WriteLine("at 4 " + myStructure2.Get(4));
            Console.WriteLine("at end " + myStructure2.Get(myStructure2.Count - 1));

            Console.WriteLine("Remove " + myStructure2.Remove());

            Console.WriteLine("RemoveAt(4) " + myStructure2.RemoveAt(4));

            Console.WriteLine("RemoveLast " + myStructure2.RemoveLast());
            Console.WriteLine("Search: " + myStructure2.Search(2));

            Console.WriteLine(myStructure2.ToString());
            myStructure2.Clear();

            Console.WriteLine(myStructure2.ToString());
            myStructure2.Add(3);
            myStructure2.Add(2);
            myStructure2.Add(1);
            myStructure2.Add(7);
            myStructure2.Add(9);
            myStructure2.Add(9);
            myStructure2.Add(8);
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Sort();
            Console.WriteLine(myStructure2.ToString());
            myStructure2.Sort(true);
            Console.WriteLine(myStructure2.ToString());


            Console.WriteLine("ALL DONE!");
            string wait = Console.ReadLine();
        }
    }
}
