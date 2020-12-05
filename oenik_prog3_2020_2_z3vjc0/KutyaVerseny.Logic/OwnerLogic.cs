﻿// <copyright file="OwnerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;

    /// <summary>
    /// class of owner logic.
    /// </summary>
    public class OwnerLogic : IOwnerLogic
    {
        private IDogRepository dogRepo;
        private IInterventionRepositry intRepo;
        private IMedalRepository medalRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerLogic"/> class.
        /// </summary>
        /// <param name="repo">repo.</param>
        /// <param name="intRepo">intRepo.</param>
        /// <param name="medalRepo">medalRepo.</param>
        public OwnerLogic(IDogRepository repo, IInterventionRepositry intRepo, IMedalRepository medalRepo)
        {
            this.dogRepo = repo;
            this.intRepo = intRepo;
            this.medalRepo = medalRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerLogic"/> class.
        /// ctor with one parameter.
        /// </summary>
        /// <param name="repo">dog repository.</param>
        public OwnerLogic(IDogRepository repo)
        {
            this.dogRepo = repo;
        }

        /// <summary>
        /// add a dog.
        /// </summary>
        /// <param name="d">dog.</param>
        public void AddDog(Dog d)
        {
            this.dogRepo.Add(d);
        }

        /// <summary>
        /// change dog name.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        public void ChangeDogName(int id, string name)
        {
            this.dogRepo.ChangeName(id, name);
        }

        /// <summary>
        /// get all dogs.
        /// </summary>
        /// <returns>list.</returns>
        public IList<Dog> GetAllDogs()
        {
            return this.dogRepo.GetAll().ToList();
        }

        /// <summary>
        /// get all intervention.
        /// </summary>
        /// <param name="chipnumb">chipnumb.</param>
        /// <returns>list.</returns>
        public IList<Intervention> GetAllIntervention(int chipnumb)
        {
            return this.intRepo.GetAll().Where(x => x.DogChipNum.GetHashCode().Equals(chipnumb)).ToList();
        }

        /// <summary>
        /// get all medal.
        /// </summary>
        /// <param name="chipnumb">chipnumb.</param>
        /// <returns>list.</returns>
        public IList<Medal> GetAllMedal(int chipnumb)
        {
            return this.medalRepo.GetAll().Where(x => x.DogChipNum.GetHashCode().Equals(chipnumb)).ToList();
        }

        /// <summary>
        /// get your dog according to chip.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>a dog.</returns>
        public Dog GetYourDogByChip(int id)
        {
            return this.dogRepo.GetOne(id);
        }

        /// <summary>
        /// get all of your dogs.
        /// </summary>
        /// <param name="name">name.</param>
        /// <returns>list of dogs.</returns>
        public IList<Dog> GetYourDogs(string name)
        {
            return this.dogRepo.GetAll().Where(x => x.OwnerName.Equals(name)).ToList();
        }

        /// <summary>
        /// delet a dog.
        /// </summary>
        /// <param name="d">dog.</param>
        public void RemoveDog(Dog d)
        {
            this.dogRepo.Remove(d);
        }

        /// <summary>
        /// list all owner in the database.
        /// </summary>
        /// <returns>list of string.</returns>
        public List<string> AllOwner()
        {
            List<string> doctors = new List<string>();
            foreach (var item in this.dogRepo.GetAll().ToList())
            {
                if (!doctors.Contains(item.OwnerName))
                {
                    doctors.Add(item.OwnerName);
                }
            }

            return doctors;
        }

        /// <summary>
        /// dog medals.
        /// </summary>
        /// <param name="name">naem of owner.</param>
        public void DogsMedals(string name)
        {
            var q1 = from a in this.dogRepo.GetAll().ToList()
                     join b in this.medalRepo.GetAll().ToList() on a.ChipNum equals b.DogChipNum
                     where a.OwnerName.Equals(name)
                     select new
                     {
                         neve = a.DogName,
                         fajta = a.Breed,
                         dij = b.Category,
                         fokozat = b.Degree,
                     };
            foreach (var item in q1)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// dog wiht intervetnion.
        /// </summary>
        /// <param name="name">name.</param>
        public void DogsInterventions(string name)
        {
            var q2 = from a in this.dogRepo.GetAll().ToList()
                     join b in this.intRepo.GetAll().ToList() on a.ChipNum equals b.DogChipNum
                     where a.OwnerName.Equals(name)
                     select new
                     {
                         neve = a.DogName,
                         fajta = a.Breed,
                         leiras = b.Desript,
                         orvos = b.Doctor,
                         ara = b.Cost,
                     };
            foreach (var item in q2)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}
