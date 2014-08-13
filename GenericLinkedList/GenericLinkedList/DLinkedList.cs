using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLinkedList
{
    public class DLinkedList<T> where T : IComparable<T>
    {
        private Node<T> _Head;
        public Node<T> Head { get { return _Head; } set { _Head = value; } }
        
        private Node<T> _Tail;
        public Node<T> Tail { get { return _Tail; } set { _Tail = value; } }

        private int _Size;
        public int Size { get { return _Size; } set { _Size = value; } }

        public DLinkedList()
        {
            Size = 0;
        }

        public void Add(T item)
        {
            if (Head == null)
            {
                Head = new Node<T>(item);
                Tail = Head;
            }
            else { 
                Node<T> previousTail = Tail;
                Tail = new Node<T>(item);
                Tail.Last = previousTail;
                previousTail.Next = Tail;
            }
            Size++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public void Insert(T itemValue, int index)
        {
            Node<T> item = new Node<T>(itemValue);
            index = (index > Size) ? Size : index;
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
            Size++;
        }

        public T Get(int index)
        {
            return GetNode(index).Value;
        }

        public Node<T> GetNode(int index)
        {
            Node<T> previousAt = Head;
            for (int i = 0; i < index; i++)
            {
                previousAt = previousAt.Next;
            }
            return previousAt;
        }

        public T Remove()
        {
            Node<T> previousAt = Head;
            Head = Head.Next;
            Head.Last = null;
            Size--;
            return previousAt.Value;
        }

        public T RemoveAt(int index)
        {
            Node<T> previousAt = Head;
            for (int i = 0; i < index; i++)
            {
                previousAt = previousAt.Next;
            }
            previousAt.Last.Next = previousAt.Next;
            previousAt.Next.Last = previousAt.Last;
            Size--;
            return previousAt.Value;
        }

        public T RemoveLast()
        {
            Node<T> previousAt = Tail;
            Tail = Tail.Last;
            Tail.Next = null;
            Size--;
            return previousAt.Value;
        }

        public int Search(T item)
        {
            int foundIndex = -1;
            
            Node<T> previousAt = Head;
            for (int i = 0; i < Size && foundIndex == -1; i++)
            {
                if (previousAt.Value.CompareTo(item) == 0)
                {
                    foundIndex = i;
                }
                previousAt = previousAt.Next;
            }
            return foundIndex;
        }

        public void Sort(bool reverse = false)
        {
            bool madeAChange = true;
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
                        if (node1.Value.CompareTo(node2.Value) == -1)
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

        private void SwapNodes(Node<T> n1, Node<T> n2)
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

        public override string ToString()
        {
            string retString = "";
            int index = 0;
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                //Console.Write(index++ + ": " + currentNode.ToString() + "\n");
                retString += index++ + ": " + currentNode.ToString() + "\n";
                currentNode = currentNode.Next;
            }
            return retString;
        }
    }
}
