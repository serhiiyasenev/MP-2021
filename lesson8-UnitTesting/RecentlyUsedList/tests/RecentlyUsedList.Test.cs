using NUnit.Framework;
using System;

namespace RecentlyUsedList.Tests
{
    [TestFixture]
    public class RecentlyUsedListTest
    {
        [Test]
        public void AddElement()
        {
            var list = new RecentlyUsedListSolver();
            list.Add("first");
            Assert.AreEqual(1, list.Count);
        }
        
        [Test]
        public void LastAddedElementShouldBeFirst()
        {
            var list = new RecentlyUsedListSolver();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("third", list[0]);
        }
        
        [Test]
        public void DuplicatedItemShouldBeMoved()
        {
            var list = new RecentlyUsedListSolver();
            list.Add("first");
            list.Add("second");
            list.Add("first");
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("first", list[0]);
        }
        
        [Test]
        public void NegativeIndexThrowsException()
        {
            var list = new RecentlyUsedListSolver();
            string test = null;
            Assert.Throws<IndexOutOfRangeException>( () => { test = list[-1]; });
        }

        [Test] 
        public void NullInsertionThrowsException()
        {
            var list = new RecentlyUsedListSolver();
            Assert.Throws<ArgumentNullException>(() => list.Add(null));
        }
        
        [Test] 
        public void ListIsEmptyByDefault()
        {
            var list = new RecentlyUsedListSolver();
            Assert.AreEqual(0, list.Count);
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void ListCapacityIsNotValid(int capacity)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RecentlyUsedListSolver(capacity));
        }
        
        [Test] 
        public void ListAutomaticallyRemovingItemsOutOfBoundedCapacity()
        {
            var list = new RecentlyUsedListSolver(1);
            list.Add("first");
            list.Add("second");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("second", list[0]);
        }
        
        [TestCase] 
        public void CapacityByDefaultIsFive()
        {
            var list = new RecentlyUsedListSolver();
            for(var i = 0; i <= 10; i++)
                list.Add(i.ToString());
            
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("10", list[0]);
            Assert.AreEqual("6", list[4]);
        }
    }
}