using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void Ctor_ThrowsExcWhenDbCountExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Ctor_AddValidItemsInDb()
        {
            var elements = new int[] { 1, 2, 3 };
            database = new Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Add_IncrementsCountWhenAddIsValid()
        {
            var n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_ThrowsExcWhenCapacityExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Remove_DecreaseDbCapacity()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            database.Remove();
            var expectedResultCount = 2;
            Assert.That(database.Count, Is.EqualTo(expectedResultCount));
        }

        [Test]
        public void Remove_ThrowsExcWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDb()
        {
            var n = 3;
            var lastElement = 3;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            database.Remove();
            var elements = database.Fetch();
            Assert.IsFalse(elements.Contains(lastElement));
        }

        [Test]
        public void Fetc_ReturnsDbCopyNotReference()
        {
            database.Add(1);
            database.Add(2);
            var firstCopy = database.Fetch();
            database.Add(3);
            var secondCopy = database.Fetch();
            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }



    }
}