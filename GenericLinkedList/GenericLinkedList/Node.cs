using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLinkedList
{
    public class Node <T> where T:IComparable<T>
    {
        private Node<T> _Next;
        public Node<T> Next { get { return _Next; } set { _Next = value; } }
        private Node<T> _Last;
        public Node<T> Last { get { return _Last; } set { _Last = value; } }
        private T _Value;
        public T Value { get { return _Value; } set { _Value = value; } }

        public Node(T value) {
            Value = value;
        }
        public override string ToString()
        {
            string lastString = (Last != null) ? Last.Value.ToString() : "null";
            string nextString = (Next != null) ? Next.Value.ToString() : "null";
            return string.Format("{0}-{1}-{2}", lastString, Value.ToString(), nextString);
        }
    }
}
