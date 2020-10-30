// <copyright file="IDogLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// IDogLogic.
    /// </summary>
    public interface IDogLogic
    {
        /// <summary>
        /// Take a dog by id.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <returns>a dog.</returns>
        Dog GetDogByChip(int id);

        /// <summary>
        /// Dog name changeing method.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="name">the new dog name.</param>
        void ChangeDogName(int id, string name);

        /// <summary>
        /// Dog owner changeing method.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="owner">new owner name.</param>
        void ChangeDogOwner(int id, string owner);

        /// <summary>
        /// get all dogs from database.
        /// </summary>
        /// <returns>all dogs.</returns>
        IList<Dog> GetAllDogs();
    }
}
