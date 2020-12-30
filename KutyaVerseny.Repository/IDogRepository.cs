// <copyright file="IDogRepository.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// Dog repo.
    /// </summary>
    public interface IDogRepository : IRepository<Dog>
    {
        /// <summary>
        /// Dog name changeing method.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="name">the new dog name.</param>
        void ChangeName(int id, string name);

        /// <summary>
        /// Dog owner changeing method.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="owner">new owner name.</param>
        void ChangeOwner(int id, string owner);

        /// <summary>
        /// chang the dog gender to neutering.
        /// </summary>
        /// <param name="chipnumb">dog cip id.</param>
        void DogNeutering(int chipnumb);
    }
}
