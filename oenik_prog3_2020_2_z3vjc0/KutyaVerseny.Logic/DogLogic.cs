// <copyright file="DogLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;

    /// <summary>
    /// dogLogic.
    /// </summary>
    public class DogLogic : IDogLogic
    {
        private readonly IDogRepository dogRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="DogLogic"/> class.
        /// </summary>
        /// <param name="repo">repo.</param>
        public DogLogic(IDogRepository repo)
        {
            this.dogRepo = repo;
        }

        /// <summary>
        /// Add dog.
        /// </summary>
        /// <param name="d">dog.</param>
        public void AddDog(Dog d)
        {
            this.dogRepo.Add(d);
        }

        /// <summary>
        /// Dog name changeing method.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="name">the new dog name.</param>
        public void ChangeDogName(int id, string name)
        {
            this.dogRepo.ChangeName(id,  name);
        }

        /// <summary>
        /// Dog owner changeing method.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="owner">new owner name.</param>
        public void ChangeDogOwner(int id, string owner)
        {
            this.dogRepo.ChangeOwner(id, owner);
        }

        /// <summary>
        /// get all dogs from database.
        /// </summary>
        /// <returns>all dogs.</returns>
        public IList<Dog> GetAllDogs()
        {
            return this.dogRepo.GetAll().ToList();
        }

        /// <summary>
        /// Take a dog by id.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <returns>a dog.</returns>
        public Dog GetDogByChip(int id)
        {
            return this.dogRepo.GetOne(id);
        }

        /// <summary>
        /// remove a dog.
        /// </summary>
        /// <param name="d">dog.</param>
        public void RemoveDog(Dog d)
        {
            this.dogRepo.Remove(d);
        }
    }
}
