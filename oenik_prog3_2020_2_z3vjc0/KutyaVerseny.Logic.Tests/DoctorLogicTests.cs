// <copyright file="DoctorLogicTests.cs" company="PlaceholderCompany">
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
    /// doctor logic tester.
    /// </summary>
    [TestFixture]
    public class DoctorLogicTests
    {
        /// <summary>
        /// test of changing cost method (this is an update method).
        /// </summary>
        [Test]
        public void UpdateCostTest()
        {
            Mock<IInterventionRepositry> docRepo = new Mock<IInterventionRepositry>();

            int id = 1;
            int newCost = 20000;
            List<Intervention> interventions = new List<Intervention>()
            {
                new Intervention() { Cost = 10000, InterventionId = 1 },
                new Intervention() { Cost = 15000, InterventionId = 2 },
            };
            docRepo.Setup(rep => rep.ChangeCost(It.IsAny<int>(), It.IsAny<int>()));
            docRepo.Setup(rep => rep.GetOne(It.IsAny<int>())).Returns(interventions.Find(i => i.InterventionId == id));

            DoctorLogic log = new DoctorLogic(docRepo.Object);
            log.ChangeInterventionCost(id, newCost);

            docRepo.Verify(r => r.ChangeCost(id, newCost), Times.Once);
        }

        /// <summary>
        /// test of getone method.
        /// </summary>
        [Test]
        public void OneIntervetnionTest()
        {
            Mock<IInterventionRepositry> docRepo = new Mock<IInterventionRepositry>();
            int id = 1;
            List<Intervention> interventions = new List<Intervention>()
            {
                new Intervention() { Cost = 10000, InterventionId = 1, Desript = "Test" },
                new Intervention() { Cost = 15000, InterventionId = 2, Desript = "Test" },
            };
            docRepo.Setup(rep => rep.GetOne(It.IsAny<int>())).Returns(interventions.Find(i => i.InterventionId == id));
            DoctorLogic log = new DoctorLogic(docRepo.Object);
            log.GetIntervention(id);
            docRepo.Verify(rep => rep.GetOne(id), Times.Once);
        }
    }
}
