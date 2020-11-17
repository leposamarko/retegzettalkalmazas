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
            #pragma warning disable CA2000 // Dispose objects before losing scope
            Db ctx = new Db();
            #pragma warning restore CA2000 // Dispose objects before losing scope
            DogRepository dogRepo = new DogRepository(ctx);
            DogLogic dogLogic = new DogLogic(dogRepo);
            MedalRepository medalRepo = new MedalRepository(ctx);
            MedalLogic medalLogic = new MedalLogic(medalRepo);
            InterventionRepository intRepo = new InterventionRepository(ctx);
            InterventionLogic intLogic = new InterventionLogic(intRepo);
            NonCRUDLogic ncl = new NonCRUDLogic(dogRepo, medalRepo, intRepo);

            OwnerLogic ownerLogic = new OwnerLogic(dogRepo, intRepo, medalRepo);
            DoctorLogic doctorLogic = new DoctorLogic(intRepo, dogRepo);
            DirectorLogic directorLogic = new DirectorLogic(medalRepo, dogRepo);

            Menu m = new Menu();
            var menu = new ConsoleMenu()
                .Add(">>BELÉPÉS GAZDIKÉNT", () => m.DogMenu(dogLogic))
                .Add(">>BELÉPÉS ORVOSKÉNT", () => m.MedalMenu(medalLogic, dogLogic))
                .Add(">>BELÉPÉS RENDZŐKÉNT", () => m.InterventionMenu(intLogic, dogLogic))
                .Add(">>EXIT", ConsoleMenu.Close);
            menu.Show();
        }

        private static void ListAllDog(DogLogic log)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            System.Console.WriteLine("\n:: ALL DOGS ::\n");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            log.GetAllDogs().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        private static void ListAllMedal(MedalLogic log)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            System.Console.WriteLine("\n:: ALL MEDALS ::\n");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            log.GetAllMedal().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        private static void ListAllIntervention(InterventionLogic log)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            System.Console.WriteLine("\n:: ALLL INTERVENTIONS ::\n");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            log.GetAllIntervention().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        private static void ChangeMedalCategory(MedalLogic medalLogic)
        {
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("New name of Category ->");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            string categor = Console.ReadLine();
            #pragma warning restore CA1305 // Specify IFormatProvider
            medalLogic.ChangeMedalCategory(id, categor);
         }

        private static void ChangeMedalDegree(MedalLogic medalLogic)
        {
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine(">> NEW DEGREE:");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            string degree = Console.ReadLine();
            medalLogic.ChangeMedalDegree(id, degree);
        }

        private static void AddNewMedal(MedalLogic medalLogic, DogLogic dogLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("GIVE THE DATA OF THE MEDAL:");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            Medal m = new Medal();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("NAME OF THE RACE -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            m.RaceName = Console.ReadLine();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("NAME OF THE CATEGORY -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            m.Category = Console.ReadLine();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("NAME OF THE DEGREE -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            m.Degree = Console.ReadLine();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF THE DOG WHO WIN IT -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            m.DogChipNum = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("NUMBER OF STARTERS -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            m.MedalId = medalLogic.GetAllMedal().Count + 1;
            #pragma warning disable CA1305 // Specify IFormatProvider
            m.StartersNum = int.Parse(Console.ReadLine());
            #pragma warning restore CA1305 // Specify IFormatProvider
            medalLogic.AddMedal(m);
        }

        private static void GetMedalById(MedalLogic medalLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF THE MEDAL WHAT YOU WANT TO LIST");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            var med = medalLogic.GetMedal(id);
            Console.WriteLine(med.ToString());
            Console.ReadLine();
        }

        private static void RemoveMedalById(MedalLogic medalLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF THE REMOVING MEDAL");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            Medal rm = medalLogic.GetMedal(id);
            medalLogic.RemoveMedal(rm);
        }

        private static void ChangeDogName(DogLogic dogLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF DOG");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine(">> NEW DEGREE:");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            string name = Console.ReadLine();
            dogLogic.ChangeDogName(id, name);
        }

        private static void ChangeOwnerName(DogLogic dogLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF DOG");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine(">> NEW NAME OF OWNER:");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            string name = Console.ReadLine();
            dogLogic.ChangeDogOwner(id, name);
        }

        private static void AddNewDog(DogLogic dogLogic)
        {
            Console.WriteLine("GIVE THE DATA OF THE DOG");
            Dog d = new Dog();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("DOG NAME -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            d.DogName = Console.ReadLine();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("OWNER NAME -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            d.OwnerName = Console.ReadLine();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("GENDER -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            d.Gender = Console.ReadLine();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("BREED -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            d.Breed = Console.ReadLine();
            d.ChipNum = dogLogic.GetAllDogs().Count + 1;
            dogLogic.AddDog(d);
        }

        private static void GetDogById(DogLogic dogLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF THE DOG WHAT YOU WANT TO LIST");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            var dog = dogLogic.GetDogByChip(id);
            Console.WriteLine(dog.ToString());
            Console.ReadLine();
        }

        private static void RemoveDogById(DogLogic dogLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF THE REMOVING MEDAL");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            Dog rm = dogLogic.GetDogByChip(id);
            dogLogic.RemoveDog(rm);
        }

        private static void ChangeInterventionDescript(InterventionLogic intLog)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF INTERVENTION");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine(">> NEW DESCRIPTION :");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            string desc = Console.ReadLine();
            intLog.ChangeInterventionDescript(id, desc);
        }

        private static void ChangeDocName(InterventionLogic intLog)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF INTERVENTION");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine(">> NEW DOCTOR NAME:");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            string name = Console.ReadLine();
            intLog.ChangeInterventionDoctor(id, name);
        }

        private static void AddNewIntervention(InterventionLogic intLog, DogLogic dogLogic)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("GIVE THE DATA OF THE INTERVENTION");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            Intervention i = new Intervention();
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("DESCRIPTION -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            i.Desript = Console.ReadLine();
            i.InterventionId = intLog.GetAllIntervention().ToList().Count + 1;
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("COST -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            #pragma warning disable CA1305 // Specify IFormatProvider
            i.Cost = int.Parse(Console.ReadLine());
            #pragma warning restore CA1305 // Specify IFormatProvider
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("NAME OF DOCTOR -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            i.Doctor = Console.ReadLine();
            Console.WriteLine();
            #pragma warning disable CA1305 // Specify IFormatProvider
            i.DoctorPhone = int.Parse(Console.ReadLine());
            #pragma warning restore CA1305 // Specify IFormatProvider
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("DOG CHIP NUMBER -> ");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            i.DogChipNum = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            intLog.Add(i);
        }

        private static void GetInterventionById(InterventionLogic intLog)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF THE INTERVENTION WHAT YOU WANT TO LIST");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            var interv = intLog.GetIntervention(id);
            Console.WriteLine(interv.ToString());
            Console.ReadLine();
        }

        private static void RemoveInterventionById(InterventionLogic intLog)
        {
            #pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("ID OF THE REMOVING INTERVENTION");
            #pragma warning restore CA1303 // Do not pass literals as localized parameters
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            Intervention rm = intLog.GetIntervention(id);
            intLog.Remov(rm);
        }
    }
}