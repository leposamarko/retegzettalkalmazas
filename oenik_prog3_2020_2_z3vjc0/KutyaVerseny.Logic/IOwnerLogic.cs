﻿// <copyright file="IOwnerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// interface.
    /// </summary>
    public interface IOwnerLogic
    {
        /// <summary>
        /// Take a dog by id.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <returns>a dog.</returns>
        Dog GetYourDogByChip(int id);

        /// <summary>
        /// Dog name changeing method.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <param name="name">the new dog name.</param>
        void ChangeDogName(int id, string name);

        /// <summary>
        ///  get all off your dogs from database.
        /// </summary>
        /// <param name="name">name.</param>
        /// <returns>list of dogs.</returns>
        IList<Dog> GetYourDogs(string name);

        /// <summary>
        /// get all dogs from database.
        /// </summary>
        /// <returns>all dogs.</returns>
        IList<Dog> GetAllDogs();

        /// <summary>
        /// Add dog.
        /// </summary>
        /// <param name="d">dog.</param>
        void AddDog(Dog d);

        /// <summary>
        /// Remove a dog.
        /// </summary>
        /// <param name="d">dog.</param>
        void RemoveDog(Dog d);

        /// <summary>
        /// get all intervention from database.
        /// </summary>
        /// <param name="chipnumb">chipnumber.</param>
        /// <returns>list.</returns>
        IList<Intervention> GetAllIntervention(int chipnumb);

        /// <summary>
        /// get all medal from database.
        /// </summary>
        /// /// <param name="chipnumb">chipnumber.</param>
        /// <returns>all dogs.</returns>
        IList<Medal> GetAllMedal(int chipnumb);
    }
}