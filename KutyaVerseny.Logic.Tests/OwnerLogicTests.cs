// <copyright file="OwnerLogicTests.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
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

        /// <summary>
        /// dog medal test.
        /// </summary>
        [Test]
        public void DogsMedalTest()
        {
            Mock<IDogRepository> dogrepo = new Mock<IDogRepository>();
            Mock<IMedalRepository> medalrepo = new Mock<IMedalRepository>();
            Dog d = new Dog() { ChipNum = 1, DogName = "testdog1", Breed = "unknow", OwnerName = "testgeza" };
            Dog d2 = new Dog() { ChipNum = 2, DogName = "testdog2", Breed = "unknow", OwnerName = "tesztgeza2" };
            string name = d.OwnerName;
            List<Dog> dogs = new List<Dog> { d, d2 };
            List<Medal> medals = new List<Medal>()
            {
                new Medal() { Category = "test1", DogChipNum = 1, Degree = "arany" },
                new Medal() { Category = "test3", DogChipNum = 1, Degree = "arany" },
                new Medal() { Category = "test2", DogChipNum = 2, Degree = "arany" },
            };
            List<string> epm = new List<string>()
            {
                { "DogName = testdog1, Breed= unknow, Category = test1, Degree= arany" },
                { "DogName = testdog1, Breed= unknow, Category = test3, Degree= arany" },
                { "DogName = testdog2, Breed= unknow, Category = test2, Degree= arany" },
            };
            dogrepo.Setup(rep => rep.GetAll()).Returns(dogs.AsQueryable);
            medalrepo.Setup(rep => rep.GetAll()).Returns(medals.AsQueryable);
            OwnerLogic log = new OwnerLogic(dogrepo.Object, medalrepo.Object);
            List<string> methodresutl = log.DogsMedals(name);
            Assert.That(methodresutl[0], Is.EquivalentTo(epm[0].ToString()));
            dogrepo.Verify(rep => rep.GetAll(), Times.Once);
            medalrepo.Verify(rep => rep.GetAll(), Times.Once);
        }

        /// <summary>
        /// dog intervetnions test.
        /// </summary>
        [Test]
        public void TestDogsInterventions()
        {
            Mock<IDogRepository> dogrepo = new Mock<IDogRepository>();
            Mock<IInterventionRepositry> intrepo = new Mock<IInterventionRepositry>();

            Dog d = new Dog() { ChipNum = 1, DogName = "testdog1", Breed = "unknow", OwnerName = "testgeza" };
            Dog d2 = new Dog() { ChipNum = 2, DogName = "testdog2", Breed = "unknow", OwnerName = "tesztgeza2" };
            string name = d.OwnerName;
            List<Dog> dogs = new List<Dog> { d, d2 };
            List<Medal> medals = new List<Medal>()
            {
                new Medal() { Category = "test1", DogChipNum = 1, Degree = "arany" },
                new Medal() { Category = "test3", DogChipNum = 1, Degree = "arany" },
                new Medal() { Category = "test2", DogChipNum = 2, Degree = "arany" },
            };

            List<Intervention> inters = new List<Intervention>()
            {
                new Intervention() { Desript = "test", Cost = 10, Doctor = "somebody", DogChipNum = 2 },
                new Intervention() { Desript = "test", Cost = 10, Doctor = "somebody", DogChipNum = 1 },
                new Intervention() { Desript = "test", Cost = 10, Doctor = "somebody", DogChipNum = 1 },
            };

            dogrepo.Setup(rep => rep.GetAll()).Returns(dogs.AsQueryable());
            intrepo.Setup(rep => rep.GetAll()).Returns(inters.AsQueryable());
            string expected = $"neve={d.DogName}, fajtaja={d.Breed}, Desript={inters[1].Desript}, Doctor={inters[1].Doctor}, Cost={inters[1].Cost}";
            OwnerLogic log = new OwnerLogic(dogrepo.Object, intrepo.Object, null);
            Assert.That(log.DogsInterventions(name)[0], Is.EquivalentTo(expected));
            dogrepo.Verify(rep => rep.GetAll(), Times.Once);
            intrepo.Verify(rep => rep.GetAll(), Times.Once);
        }
    }
}
