// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;

    /// <summary>
    /// Factory.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Gets dogRepo.
        /// </summary>
        public static DogRepository DogRepo { get; private set; }

        /// <summary>
        /// Gets  intrepo.
        /// </summary>
        public static InterventionRepository IntRepo { get; private set; }

        /// <summary>
        /// Gets medalrepo.
        /// </summary>
        public static MedalRepository MedRepo { get; private set; }

        /// <summary>
        /// Gets or sets  DB.
        /// </summary>
        public static Db DogDb { get; set; }

        /// <summary>
        /// create calls method.
        /// </summary>
        public static void CreateClass()
        {
            DogDb = new Db();
            DogRepo = new DogRepository(DogDb);
            IntRepo = new InterventionRepository(DogDb);
            MedRepo = new MedalRepository(DogDb);
        }
    }
}
