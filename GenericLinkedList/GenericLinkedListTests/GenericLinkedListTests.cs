using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSC160_GenericLinkedList;

namespace GenericLinkedListTests
{
    [TestClass]
    public class GenericLinkedListTests
    {
        [TestMethod]
        public void Add_NullValueToEmpty_Size0()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            int expectedCount = 0;
            string addString = null;

            // act
            myList.Add(addString);

            // assert
            Assert.AreEqual(expectedCount, myList.Count);
        }

        [TestMethod]
        public void Add_NullValueToNonEmpty_Size2()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            myList.Add("String1");
            myList.Add("String2");
            int expectedCount = 2;
            string addString = null;

            // act
            myList.Add(addString);

            // assert
            Assert.AreEqual(expectedCount, myList.Count);
        }

        [TestMethod]
        public void Add_ValueToNonEmpty_Size3()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            myList.Add("String1");
            myList.Add("String2");
            int expectedCount = 3;
            string addString = null;

            // act
            myList.Add(addString);

            // assert
            Assert.AreEqual(expectedCount, myList.Count);
        }

        [TestMethod]
        public void Clear_Size0()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            myList.Add("String1");
            myList.Add("String2");
            int expectedCount = 0;

            // act
            myList.Clear();

            // assert
            Assert.AreEqual(expectedCount, myList.Count);
        }

        [TestMethod]
        public void Insert_StringAt0()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            myList.Add("String1");
            myList.Add("String2");
            string addString = "added";
            int addIndex = 0;

            // act
            myList.Insert(addString, addIndex);

            // assert
            Assert.AreEqual(addString, myList.Get(addIndex));
        }

        [TestMethod]
        public void Insert_StringAt1()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            myList.Add("String1");
            myList.Add("String2");
            string addString = "added";
            int addIndex = 1;

            // act
            myList.Insert(addString, addIndex);

            // assert
            Assert.AreEqual(addString, myList.Get(addIndex));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_StringAt15_TooBigIndex()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            myList.Add("String1");
            myList.Add("String2");
            string addString = "added";
            int addIndex = 15;

            // act
            myList.Insert(addString, addIndex);

            // assert
            //Assert.AreEqual(addString, myList.Get(addIndex));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_IndexTooLarge()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            myList.Add("String1");
            myList.Add("String2");
            int index = 15;

            // act
            String retrieved = myList.Get(index);

            // assert
            //Assert.AreEqual(addString, myList.Get(addIndex));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_Index0()
        {
            // arange
            GenericLinkedList<string> myList = new GenericLinkedList<string>();
            int index = 0;

            // act
            String retrieved = myList.Get(index);

            // assert
            //Assert.AreEqual(addString, myList.Get(addIndex));
        }
    }
}
