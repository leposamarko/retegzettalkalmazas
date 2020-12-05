// <copyright file="Mainprogram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Races
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using ConsoleTools;
    using global::KutyaVerseny.Data.Models;
    using global::KutyaVerseny.Logic;
    using global::KutyaVerseny.Program;
    using global::KutyaVerseny.Repository;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.VisualBasic.CompilerServices;

    /// <summary>
    /// A program.
    /// </summary>
    public static class Mainprogram
    {
        /// <summary>
        /// start of the program.
        /// </summary>
        public static void Main()
        {
            Db ctx = new Db();
            DogRepository dogRepo = new DogRepository(ctx);
            MedalRepository medalRepo = new MedalRepository(ctx);
            InterventionRepository intRepo = new InterventionRepository(ctx);
            OwnerLogic ownerLogic = new OwnerLogic(dogRepo, intRepo, medalRepo);
            DoctorLogic doctorLogic = new DoctorLogic(intRepo, dogRepo);
            DirectorLogic directorLogic = new DirectorLogic(medalRepo, dogRepo);

            Menu m = new Menu();
            var menu = new ConsoleMenu()
                .Add(">>BELÉPÉS GAZDIKÉNT", () => m.OwnerMenu(ownerLogic))
                .Add(">>BELÉPÉS ORVOSKÉNT", () => m.DoctorMenu(doctorLogic, ownerLogic))
                .Add(">>BELÉPÉS RENDZŐKÉNT", () => m.DirectorMenu(directorLogic, ownerLogic))
                .Add(">>EXIT", ConsoleMenu.Close);
            menu.Show();
        }
    }
}