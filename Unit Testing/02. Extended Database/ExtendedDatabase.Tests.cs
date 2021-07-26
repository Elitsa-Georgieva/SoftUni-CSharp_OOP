using System;
using NUnit.Framework;


namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDB;

        [SetUp]
        public void Setup()
        {
            extendedDB = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddInitialPeoplesToDb()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Name: {i}");
            }

            extendedDB = new ExtendedDatabase(persons);

            Assert.That(extendedDB.Count, Is.EqualTo(persons.Length));

            foreach (Person person in persons)
            {
                Person dbPerson = extendedDB.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }

        [Test]

        public void Ctor_ThrowsExceptionWhenCapacityIsExceeded()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Pesho{i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDB = new ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ThrowsExceptonWhenCountIsExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                extendedDB.Add(new Person(i, $"Name{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDB.Add(new Person(16, "abcde")));
        }

        [Test]
        public void Add_ThrowsExceptonWhenUserNameAlreadyExist()
        {
            var name = "Pesho";
            extendedDB.Add(new Person(1, name));

            Assert.Throws<InvalidOperationException>(() => extendedDB.Add(new Person(6, name)));
        }

        [Test]
        public void Add_ThrowsExceptonWhenIdAlreadyExist()
        {
            var id = 1;
            extendedDB.Add(new Person(id, "abcde"));
            
            Assert.Throws<InvalidOperationException>(() => extendedDB.Add(new Person(id, "name")));
        }

        [Test]
        public void Add_IncrementCountWhenAllIsValid()
        {
            var expectedCount = 2;
            extendedDB.Add(new Person(1, "Pesho"));
            extendedDB.Add(new Person(2, "Gosho"));
            Assert.That(extendedDB.Count, Is.EqualTo(expectedCount));

        }

        [Test]
        public void Remove_ThrowsExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDb()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendedDB.Add(new Person(i, $"Fresh{i}"));
            }

            extendedDB.Remove();
            Assert.That(extendedDB.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindBbyUserName_ThrowsExceptionWhenUserNameIsInvalid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDB.FindByUsername(username));
        }

        [Test]
        public void FindBbyUserName_ThrowsExceptionWhenUserNameIsNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindByUsername("asdjfk"));
        }

        [Test]
        public void FindBbyUserName_ReturnsTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDB.Add(person);
            var dbPerson = extendedDB.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void FindBbyId_ThrowsExceptionForInvalidId()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindById(6));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-21)]
        public void FindBbyId_ThrowsExceptionWhenIdIsNegativeValue(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDB.FindById(id));
        }

        [Test]
        public void FindById_ReturnsTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDB.Add(person);
            var dbPerson = extendedDB.FindById(person.Id);
            Assert.That(person, Is.EqualTo(dbPerson));
        }
    }
}