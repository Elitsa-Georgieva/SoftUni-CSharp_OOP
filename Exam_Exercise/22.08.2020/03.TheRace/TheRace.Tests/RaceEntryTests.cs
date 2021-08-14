using System;
using System.Collections.Generic;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{

    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }


        [Test]
        public void Counter_IsZero()
        {
            Assert.That(raceEntry.Counter, Is.Zero);
        }

        [Test]
        public void Counter_IncreasesWhenAddingDriver()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Tesla", 100, 3000)));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ThrowsExceptionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_ThrowsExceptionWhenDriverWithThatNameIsAlreadyCreated()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Tesla", 100, 3000)));
            Assert.Throws<InvalidOperationException>(() =>
                raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Toyota", 100, 2500))));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsExceptionWhenThereIsNotEnoughParticipants()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Tesla", 100, 3000)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_WorksCorectly()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Tesla", 100, 3000)));
            raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Toyota", 100, 2500)));

            var avgHP = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(100, avgHP);
        }










    }
}