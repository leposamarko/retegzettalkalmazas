﻿// <copyright file="DogRepository.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// dog repo.
    /// </summary>
    public class DogRepository : MainRepository<Dog>, IDogRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DogRepository"/> class.
        /// </summary>
        /// <param name="ctx">database.</param>
        public DogRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// method to change the dog name.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="name">new owner name.</param>
        public void ChangeName(int id, string name)
        {
            var dog = this.GetOne(id);
            dog.DogName = name;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to change owner name.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="owner">new name of owner.</param>
        public void ChangeOwner(int id, string owner)
        {
            var dog = this.GetOne(id);
            dog.OwnerName = owner;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// chage breed.
        /// </summary>
        /// <param name="id">id of dog.</param>
        /// <param name="breed">breed of dog.</param>
        public void ChangeBreed(int id, string breed)
        {
            var dog = this.GetOne(id);
            dog.Breed = breed;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// chang the dog gender to neutering.
        /// </summary>
        /// <param name="chipnumb">dog cip id.</param>
        public void DogNeutering(int chipnumb)
        {
            var dog = this.GetOne(chipnumb);
            dog.Gender = "semmi";
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Method to get one dog.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <returns>a dog.</returns>
        public override Dog GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ChipNum == id);
        }
    }
}
