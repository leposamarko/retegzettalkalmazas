// <copyright file="KutyaVerseny.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using ConsoleTools;
    using global::KutyaVerseny.Data.Models;
    using global::KutyaVerseny.Logic;
    using global::KutyaVerseny.Repository;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// A program.
    /// </summary>
    public static class KutyaVerseny
    {
        /// <summary>
        /// Itt kezdődik a program.
        /// </summary>
        public static void Main()
        {
            Db ctx = new Db ();
            DogRepository dogRepo = new DogRepository(ctx);
            DogLogic dogLogic = new DogLogic(dogRepo);
            MedalRepository medalRepo = new MedalRepository(ctx);
            MedalLogic medalLogic = new MedalLogic(medalRepo);
            InterventionRepository intRepo = new InterventionRepository(ctx);
            InterventionLogic intLogic = new InterventionLogic(intRepo);

            var menu = new ConsoleMenu()
                .Add(">>DOGS", () => ListAllDog(dogLogic))
                .Add(">>LIST ALL MEDALS", () => ListAllMedal(medalLogic))
                .Add(">>LIST ALL INTERVENTIONS", () => ListAllIntervention(intLogic))
                .Add(">>EXIT", ConsoleMenu.Close);
            menu.Show();
        }
        private static void ListAllDog(DogLogic log)
        {
            System.Console.WriteLine("\n:: ALL DOGS ::\n");
            log.GetAllDogs().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        private static void ListAllMedal(MedalLogic log)
        {
            System.Console.WriteLine("\n:: ALL MEDALS ::\n");
            log.GetAllMedal().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        private static void ListAllIntervention(InterventionLogic log)
        {
            System.Console.WriteLine("\n:: ALLL INTERVENTIONS ::\n");
            log.GetAllIntervention().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
    }
}