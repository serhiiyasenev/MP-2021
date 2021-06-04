using NUnit.Framework;
using System;

namespace RecentlyUsedList.Tests
{
    [TestFixture]
    public class RecentlyUsedListTest
    {
        private RecentlyUsedStackSolver list;

        [SetUp]
        public void SetUp()
        {
            list = new RecentlyUsedStackSolver();
        }

        [Test]
        public void AddElement()
        {
            list.Push("first");
            Assert.AreEqual(1, list.Count);
        }
        
        [Test]
        public void LastAddedElementShouldBeFirst()
        {
            list.Push("first");
            list.Push("second");
            list.Push("third");

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("third", list[0]);
        }
        
        [Test]
        public void DuplicatedItemShouldBeMoved()
        {
            list.Push("first");
            list.Push("second");
            list.Push("first");

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("first", list[0]);
            Assert.AreEqual("second", list[1]);
        }
        
        [Test]
        public void NegativeIndexThrowsException()
        {
            string test = null;
            Assert.Throws<IndexOutOfRangeException>( () => { test = list[-1]; });
        }

        [Test] 
        public void NullInsertionThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => list.Push(null));
        }
        
        [Test] 
        public void ListIsEmptyByDefault()
        {
            Assert.AreEqual(0, list.Count);
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void ListCapacityIsNotValid(int capacity)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RecentlyUsedStackSolver(capacity));
        }
        
        [Test] 
        public void ListAutomaticallyRemovingItemsOutOfBoundedCapacity()
        {
            var listSolver = new RecentlyUsedStackSolver(1);
            listSolver.Push("first");
            listSolver.Push("second");

            Assert.AreEqual(1, listSolver.Count);
            Assert.AreEqual("second", listSolver[0]);
        }
        
        [TestCase] 
        public void CapacityByDefaultIsFive()
        {
            for(var i = 0; i <= 10; i++) list.Push(i.ToString());
            
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("10", list[0]);
            Assert.AreEqual("6", list[4]);
        }

        [Test]
        public void ListReturnsValueAfterDeletingElement()
        {
            list.Push("first");
            list.Push("second");
            list.Push("third");

            Assert.True(list.Pop("first"));
            Assert.True(list.Pop("third"));
            Assert.True(list.Count.Equals(1));
            Assert.True(list[0].Equals("second"));
        }

        [Test]
        public void EmptyListThrowsExceptionWhenDeletingElement()
        {
            Assert.Throws<InvalidOperationException>(() => new RecentlyUsedStackSolver().Pop("first"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ListThrowsExceptionWhenDeletingEmptyOrNullElement(string element)
        {
            Assert.Throws<ArgumentNullException>(() => list.Push(element));
        }
    }
}