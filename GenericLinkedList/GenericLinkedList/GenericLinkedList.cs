using System;
using System.Text;

namespace CSC160_GenericLinkedList
{
    //Follow the comment prompts to complete the class below
    //You will also use the documentation comments to replace
    //the NotImplementedException statement with a real implementation
    //for each method.

    //WARNING: You are FORBIDDEN from changing the names of the namespace, 
    //classes, methods, or properties as defined or described in this
    //document. For example, if told to build a property called MyNum,
    //you MUST name it MyNum. You may, however, build any additional helper
    //methods you may wish to have.

    //Make the GenericLinkedList class generic using the placeholder "T"
    //Constrain T such that T implements IComparable<T>
    public class GenericLinkedList<T> where T : IComparable<T>
    {
        //The region bleow holds a nested class! 
        #region Nested Node Class

        //Change the Node class below so that it's only visible to the
        //GenericLinkedList class and its derived classes.
        //Make it generic using the placeholder "T".
        protected class Node<T> 
        {
            //Create a public property called Data of the generic type
            public T Data { get; set; }

            //Create a public property called Next of this Node type.
            //This property represents the next Node in the collection
            //and should default to null.
            public Node<T> Next { get; set; }
            public Node<T> Last { get; set; }

            //Create a constructor that has one parameter of type T.
            //If a value is not passed in when the constructor is called,
            //then the parameter should instead be the default value of T.
            //The constructor must assign the value of the parameter to the
            //Data property
            public Node(T data = default(T))
            {
                Data = data;
            }
            public override string ToString()
            {
                //string lastString = (Last != null) ? Last.Data.ToString() : "null";
                //string nextString = (Next != null) ? Next.Data.ToString() : "null";
                //return string.Format("{0}-{1}-{2}", lastString, Data.ToString(), nextString);
                return this.Data.ToString();
            }
        }
        #endregion


        //Create Head and Tail properties, both of type Node<T>
        //These properties should only be visible to this class
        //and any of its derived classes
        protected Node<T> Head { get; set; }
        protected Node<T> Tail { get; set; }

        //Create a property called Count
        //This property will represent the number of elements
        //in the LinkedList at any given time.
        //It should always start at 0, increment when an item
        //is added, decrement when an item is removed, and NEVER
        //be a negative number.
        //The get must be public, but the set should only be
        //visible to this class and its derived classes.
        public int Count { get; protected set; }

        public GenericLinkedList()
        {
            Count = 0;
        }

        /// <summary>
        /// Places the new value at the Tail end of the linked list
        /// </summary>
        /// <param name="data">The new value to be added</param>
        public void Add(T data)
        {
            if (Head == null)
            {
                Head = new Node<T>(data);
                Tail = Head;
            }
            else { 
                Node<T> previousTail = Tail;
                Tail = new Node<T>(data);
                Tail.Last = previousTail;
                previousTail.Next = Tail;
            }
            Count++;
        }

        /// <summary>
        /// Removes all elements from the linked list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Places a new value at the index specified
        /// </summary>
        /// <param name="data">The new value to be added</param>
        /// <param name="index">The index where the new value will be stored</param>
        public void Insert(T data, int index)
        {
            Node<T> item = new Node<T>(data);
            index = (index > Count) ? Count : index;
            Node<T> previousAt = Head;
            for (int i = 0; i < index; i++)
            {
                previousAt = previousAt.Next;
            }
            if (previousAt == null) // Insert at end
            {
                Tail.Next = item;
                item.Last = Tail;
                Tail = item;
            }
            else if (previousAt.Last == null) // Insert at Front
            {
                Head = item;
                previousAt.Last = item;
                Head.Next = previousAt;
            }
            else
            {
                previousAt.Last.Next = item;
                item.Last = previousAt.Last;
                previousAt.Last = item;
                item.Next = previousAt;
            }
            Count++;
        }

        /// <summary>
        /// Gets the value stored at the specified index
        /// </summary>
        /// <param name="index">The specified index</param>
        /// <returns>The value stored at the specified index</returns>
        public T Get(int index)
        {
            return GetNode(index).Data;
        }

        protected Node<T> GetNode(int index)
        {
            Node<T> previousAt = Head;
            for (int i = 0; i < index; i++)
            {
                previousAt = previousAt.Next;
            }
            return previousAt;
        }

        /// <summary>
        /// Removes the value stored at the Head of the linked list
        /// </summary>
        /// <returns>The value removed</returns>
        public T Remove()
        {
            Node<T> previousAt = Head;
            Head = Head.Next;
            Head.Last = null;
            Count--;
            return previousAt.Data;
        }

        /// <summary>
        /// Removes the value at the specified index
        /// </summary>
        /// <param name="index">The specified index</param>
        /// <returns>The value removed</returns>
        public T RemoveAt(int index)
        {
            Node<T> previousAt = Head;
            for (int i = 0; i < index; i++)
            {
                previousAt = previousAt.Next;
            }
            previousAt.Last.Next = previousAt.Next;
            previousAt.Next.Last = previousAt.Last;
            Count--;
            return previousAt.Data;
        }

        /// <summary>
        /// Removes the value stored at the Tail of the linked list
        /// </summary>
        /// <returns>The value removed</returns>
        public T RemoveLast()
        {
            Node<T> previousAt = Tail;
            Tail = Tail.Last;
            Tail.Next = null;
            Count--;
            return previousAt.Data;
        }

        /// <summary>
        /// Searches for the specified value and returns the first index that contains it
        /// </summary>
        /// <param name="value">The specified value</param>
        /// <returns>The first index containing the value or -1 if the value is not found</returns>
        public int Search(T value)
        {
            int foundIndex = -1;
            
            Node<T> previousAt = Head;
            for (int i = 0; i < Count && foundIndex == -1; i++)
            {
                if (previousAt.Data.CompareTo(value) == 0)
                {
                    foundIndex = i;
                }
                previousAt = previousAt.Next;
            }
            return foundIndex;
        }

        /// <summary>
        /// Organizes the values in the linked list starting from the Head
        /// </summary>
        /// <param name="sortDescending">Indicates whether the sort is ascending or descending. The default is ascending.</param>
        public void Sort(bool sortDescending = false)
        {
            BubbleSort(sortDescending);
        }

        protected void BubbleSort(bool sortDescending = false)
        {
            bool madeAChange = true;
            int needsToChange = sortDescending ? 1 : -1;
            Node<T> start = Head;
            if (start != null && start.Next != null)
            {
                while (madeAChange)
                {
                    madeAChange = false;
                    Node<T> node1 = Tail;
                    Node<T> node2 = Tail.Last;
                    while (node2 != null)
                    {
                        if (node1.Data.CompareTo(node2.Data) == needsToChange)
                        {
                            madeAChange = true;
                            SwapNodes(node2, node1);
                        }
                        
                        node1 = node2;
                        node2 = node1.Last;
                    }
                }
            }
        }

        protected void SwapNodes(Node<T> n1, Node<T> n2)
        {
            Node<T> n0 = n1.Last;
            Node<T> n3 = n2.Next;
            if (n0 == null)
            {
                Head = n2;
            }
            else
            {
                n0.Next = n2;
            }
            n1.Last = n2;
            n1.Next = n3;
            n2.Last = n0;
            n2.Next = n1;
            if (n3 == null)
            {
                Tail = n1;
            }
            else
            {
                n3.Last = n1;
            }
        }

        /// <summary>
        /// Creates a string representing the linked list by its values.
        /// If the collection is empty, this will return the empty string.
        /// All values will be separated by a single space character with no
        /// leading or trailing spaces.
        /// </summary>
        /// <returns>The string representation of the collection</returns>
        public override string ToString()
        {
            string retString = "";
            //int index = 0;
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                //Console.Write(index++ + ": " + currentNode.ToString() + "\n");
                retString += currentNode.Data + " "; //index++ + ": " + currentNode.ToString() + "\n";
                currentNode = currentNode.Next;
            }
            return retString.Trim();
        }

    }
}
