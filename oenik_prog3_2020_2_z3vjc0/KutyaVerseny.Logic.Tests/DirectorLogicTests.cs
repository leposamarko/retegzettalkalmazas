// <copyright file="DirectorLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// director logic test.
    /// </summary>
    [TestFixture]
    public class DirectorLogicTests
    {
        /// <summary>
        /// remove test.
        /// </summary>
        [Test]
        public void RemoveMedalTest()
        {
            Mock<IMedalRepository> repo = new Mock<IMedalRepository>();
            List<Medal> m = new List<Medal>()
            {
                new Medal() { MedalId = 1, Degree = "test", Category = "justtest" },
                new Medal() { MedalId = 2, Degree = "test2", Category = "justtest" },
                new Medal() { MedalId = 3, Degree = "test3", Category = "justtest" },
            };
            repo.Setup(rep => rep.Remove(It.IsAny<Medal>()));
            DirectorLogic log = new DirectorLogic(repo.Object);
            log.RemoveMedal(m[1]);
            repo.Verify(r => r.Remove(m[1]), Times.Once);
        }
    }
}
