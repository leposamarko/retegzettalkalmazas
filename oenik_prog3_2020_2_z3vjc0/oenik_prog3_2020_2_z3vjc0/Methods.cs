// <copyright file="Methods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleTools;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Logic;

    /// <summary>
    /// methods class what u can use from the menu.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Methods"/> class.
        /// </summary>
        public Methods()
        {
        }

        /// <summary>
        /// list all god.
        /// </summary>
        /// <param name="log">log.</param>
        public void ListAllDog(DogLogic log)
        {
            System.Console.WriteLine("\n:: ALL DOGS ::\n");
            log.GetAllDogs().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// list all meda.
        /// </summary>
        /// <param name="log">medalog.</param>
        public void ListAllMedal(MedalLogic log)
        {
            System.Console.WriteLine("\n:: ALL MEDALS ::\n");
            log.GetAllMedal().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// List All Intervention.
        /// </summary>
        /// <param name="log">intervention log.</param>
        public void ListAllIntervention(InterventionLogic log)
        {
            System.Console.WriteLine("\n:: ALLL INTERVENTIONS ::\n");
            log.GetAllIntervention().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// change medal category.
        /// </summary>
        /// <param name="medalLogic">medallogic.</param>
        public void ChangeMedalCategory(MedalLogic medalLogic)
        {
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            Console.WriteLine("New name of Category ->");
            string categor = Console.ReadLine();
            medalLogic.ChangeMedalCategory(id, categor);
        }

        /// <summary>
        /// Change medal degree.
        /// </summary>
        /// <param name="medalLogic">medal logic.</param>
        public void ChangeMedalDegree(MedalLogic medalLogic)
        {
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            Console.WriteLine(">> NEW DEGREE:");
            string degree = Console.ReadLine();
            medalLogic.ChangeMedalDegree(id, degree);
        }

        /// <summary>
        /// Add a new medal.
        /// </summary>
        /// <param name="medalLogic">medallogic.</param>
        /// <param name="dogLogic">doglogic.</param>
        public void AddNewMedal(MedalLogic medalLogic, DogLogic dogLogic)
        {
            Console.WriteLine("GIVE THE DATA OF THE MEDAL:");
            Medal m = new Medal();
            Console.WriteLine("NAME OF THE RACE -> ");
            m.RaceName = Console.ReadLine();
            Console.WriteLine("NAME OF THE CATEGORY -> ");
            m.Category = Console.ReadLine();
            Console.WriteLine("NAME OF THE DEGREE -> ");
            m.Degree = Console.ReadLine();
            Console.WriteLine("ID OF THE DOG WHO WIN IT -> ");
            m.DogChipNum = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            Console.WriteLine("NUMBER OF STARTERS -> ");
            m.MedalId = medalLogic.GetAllMedal().Count + 1;
            m.StartersNum = int.Parse(Console.ReadLine());
            medalLogic.AddMedal(m);
        }

        /// <summary>
        /// get a medal according to id.
        /// </summary>
        /// <param name="medalLogic">medallogic.</param>
        public void GetMedalById(MedalLogic medalLogic)
        {
            Console.WriteLine("ID OF THE MEDAL WHAT YOU WANT TO LIST");
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            var med = medalLogic.GetMedal(id);
            Console.WriteLine(med.ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// remove a medal according to id.
        /// </summary>
        /// <param name="medalLogic">medallogic.</param>
        public void RemoveMedalById(MedalLogic medalLogic)
        {
            Console.WriteLine("ID OF THE REMOVING MEDAL");
            int id = Investigator<Medal>.IdNumber(medalLogic.GetAllMedal().ToList());
            Medal rm = medalLogic.GetMedal(id);
            medalLogic.RemoveMedal(rm);
        }

        /// <summary>
        /// change the dog name.
        /// </summary>
        /// <param name="dogLogic">doglogic.</param>
        public void ChangeDogName(DogLogic dogLogic)
        {
            Console.WriteLine("ID OF DOG");
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            Console.WriteLine(">> NEW DEGREE:");
            string name = Console.ReadLine();
            dogLogic.ChangeDogName(id, name);
        }

        /// <summary>
        /// change owner name of dog.
        /// </summary>
        /// <param name="dogLogic">dogLogic.</param>
        public void ChangeOwnerName(DogLogic dogLogic)
        {
            Console.WriteLine("ID OF DOG");
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            Console.WriteLine(">> NEW NAME OF OWNER:");
            string name = Console.ReadLine();
            dogLogic.ChangeDogOwner(id, name);
        }

        /// <summary>
        /// Add a new dog.
        /// </summary>
        /// <param name="dogLogic">doglog.</param>
        public void AddNewDog(DogLogic dogLogic)
        {
            Console.WriteLine("GIVE THE DATA OF THE DOG");
            Dog d = new Dog();
            Console.WriteLine("DOG NAME -> ");
            d.DogName = Console.ReadLine();
            Console.WriteLine("OWNER NAME -> ");
            d.OwnerName = Console.ReadLine();
            Console.WriteLine("GENDER -> ");
            d.Gender = Console.ReadLine();
            Console.WriteLine("BREED -> ");
            d.Breed = Console.ReadLine();
            d.ChipNum = dogLogic.GetAllDogs().Count + 1;
            dogLogic.AddDog(d);
        }

        /// <summary>
        /// get a dog by id.
        /// </summary>
        /// <param name="dogLogic">dogLogic.</param>
        public void GetDogById(DogLogic dogLogic)
        {
            Console.WriteLine("ID OF THE DOG WHAT YOU WANT TO LIST");
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            var dog = dogLogic.GetDogByChip(id);
            Console.WriteLine(dog.ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// dog remove.
        /// </summary>
        /// <param name="dogLogic">doglocig.</param>
        public void RemoveDogById(DogLogic dogLogic)
        {
            Console.WriteLine("ID OF THE REMOVING MEDAL");
            int id = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            Dog rm = dogLogic.GetDogByChip(id);
            dogLogic.RemoveDog(rm);
        }

        /// <summary>
        /// change intervention description.
        /// </summary>
        /// <param name="intLog">intervention log.</param>
        public void ChangeInterventionDescript(InterventionLogic intLog)
        {
            Console.WriteLine("ID OF INTERVENTION");
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            Console.WriteLine(">> NEW DESCRIPTION :");
            string desc = Console.ReadLine();
            intLog.ChangeInterventionDescript(id, desc);
        }

        /// <summary>
        /// change doctor name.
        /// </summary>
        /// <param name="intLog">intervention logic.</param>
        public void ChangeDocName(InterventionLogic intLog)
        {
            Console.WriteLine("ID OF INTERVENTION");
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            Console.WriteLine(">> NEW DOCTOR NAME:");
            string name = Console.ReadLine();
            intLog.ChangeInterventionDoctor(id, name);
        }

        /// <summary>
        /// add a new interventon.
        /// </summary>
        /// <param name="intLog".>intervention logic.</param>
        /// <param name="dogLogic">dog logic.</param>
        public void AddNewIntervention(InterventionLogic intLog, DogLogic dogLogic)
        {
            Console.WriteLine("GIVE THE DATA OF THE INTERVENTION");
            Intervention i = new Intervention();
            Console.WriteLine("DESCRIPTION -> ");
            i.Desript = Console.ReadLine();
            i.InterventionId = intLog.GetAllIntervention().ToList().Count + 1;
            Console.WriteLine("COST -> ");
            i.Cost = int.Parse(Console.ReadLine());
            Console.WriteLine("NAME OF DOCTOR -> ");
            i.Doctor = Console.ReadLine();
            Console.WriteLine();
            i.DoctorPhone = int.Parse(Console.ReadLine());
            Console.WriteLine("DOG CHIP NUMBER -> ");
            i.DogChipNum = Investigator<Dog>.IdNumber(dogLogic.GetAllDogs().ToList());
            intLog.Add(i);
        }

        /// <summary>
        /// get intervention by id.
        /// </summary>
        /// <param name="intLog">intervention logic.</param>
        public void GetInterventionById(InterventionLogic intLog)
        {
            Console.WriteLine("ID OF THE INTERVENTION WHAT YOU WANT TO LIST");
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            var interv = intLog.GetIntervention(id);
            Console.WriteLine(interv.ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// remove intervention by id.
        /// </summary>
        /// <param name="intLog">intervention logic.</param>
        public void RemoveInterventionById(InterventionLogic intLog)
        {
            Console.WriteLine("ID OF THE REMOVING INTERVENTION");
            int id = Investigator<Intervention>.IdNumber(intLog.GetAllIntervention().ToList());
            Intervention rm = intLog.GetIntervention(id);
            intLog.Remov(rm);
        }
    }
}
