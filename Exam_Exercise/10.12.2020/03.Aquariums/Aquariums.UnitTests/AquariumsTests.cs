using System.Collections.Generic;
using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish1;
        private Fish fish2;
        private Fish fish3;

        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("aqua", 2);
            fish1 = new Fish("Nemo");
            fish2 = new Fish("Dori");
            fish3 = new Fish("Pepa");
        }

        [Test]
        [TestCase(null, 100)]
        [TestCase("", 100)]
        public void Ctor_ThrowsExceptionWhenNameIsInvalid(string name, int capacity)
        {

            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }


        [Test]
        [TestCase("Aqua100", -1)]
        public void Ctor_ThrowsExceptionWhenCapacityIsInvalid(string name, int capacity)
        {

            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void Add_ThrowsExcWhenCapacityExceeded()
        {

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish3));
        }

        [Test]
        public void RemoveFishMethodThrowAnExceptionWhenFishDoesNotExist()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Ribka"));
        }


        [Test]
        public void RemoveFish_DecreaseAquariumCapacity()
        {

            aquarium = new Aquarium("Aquarium", 10);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.RemoveFish("Pepa");
            var expectedResultCount = 2;
            Assert.That(aquarium.Count, Is.EqualTo(expectedResultCount));
        }

        [Test]

        public void SellFish_ThrowsExceptionIfNameIsInvalid()
        {
            var requestedFish = new Fish(null);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }

        [Test]

        public void SellFish_changeStatusOfFish()
        {
            aquarium = new Aquarium("Aquarium", 10);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            var requestedFish = new Fish("Dori");
            aquarium.SellFish("Dori");
            
            Assert.That(false, Is.EqualTo(fish2.Available));
        }

        [Test]

        public void Report_Should()
        {
            aquarium = new Aquarium("Aquarium", 10);
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.That("Fish available at Aquarium: Nemo, Dori", Is.EqualTo(aquarium.Report()));
        }




    }
}
