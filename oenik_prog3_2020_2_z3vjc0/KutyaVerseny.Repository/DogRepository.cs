// <copyright file="DogRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
    public class DogRepository : Repository<Dog>, IDogRepository
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
            this.ctx.SaveChanges();
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
            this.ctx.SaveChanges();
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
