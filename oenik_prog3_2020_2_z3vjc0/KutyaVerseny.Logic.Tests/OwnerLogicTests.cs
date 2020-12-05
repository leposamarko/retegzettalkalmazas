// <copyright file="OwnerLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test fixture of owner's logic.
    /// </summary>
    [TestFixture]
    public class OwnerLogicTests
    {
        /// <summary>
        /// test of getAll().
        /// </summary>
        [Test]
        public void TestGetDogs()
        {
            Mock<IDogRepository> repo = new Mock<IDogRepository>(MockBehavior.Loose);
            List<Dog> dogs = new List<Dog>()
            {
                new Dog() { DogName = "testkutya1", ChipNum = 1 },
                new Dog() { DogName = "testkutya2", ChipNum = 2 },
                new Dog() { DogName = "testkutya3", ChipNum = 3 },
            };
            List<Dog> exepted = new List<Dog>() { dogs[0], dogs[1], dogs[2] };
            repo.Setup(rep => rep.GetAll()).Returns(dogs.AsQueryable());
            OwnerLogic log = new OwnerLogic(repo.Object);

            var result = log.GetAllDogs();
            repo.Verify(rep => rep.GetAll(), Times.Once);
            repo.Verify(rep => rep.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// add dog test.
        /// </summary>
        [Test]
        public void TestAddDog()
        {
            Mock<IDogRepository> dogrepo = new Mock<IDogRepository>();
            dogrepo.Setup(repo => repo.Add(It.IsAny<Dog>()));
            OwnerLogic logic = new OwnerLogic(dogrepo.Object);

            Dog d = new Dog()
            {
                DogName = "Testdog",
                ChipNum = 1,
            };
            logic.AddDog(d);
            dogrepo.Verify(r => r.Add(d), Times.Once);
        }
    }
}
