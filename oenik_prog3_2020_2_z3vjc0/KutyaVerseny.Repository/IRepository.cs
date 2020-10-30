// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// main repositroy.
    /// </summary>
    /// <typeparam name="T">Main.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Return with one object.
        /// </summary>
        /// <param name="id">Fint the object from id.</param>
        /// <returns>An T generic object.</returns>
        T GetOne(int id);

        /// <summary>
        /// Get back all of the data from the object.
        /// </summary>
        /// <returns>An IQueryable list.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Add item for the database.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Add(T item);

        /// <summary>
        /// Remove the item from the database.
        /// </summary>
        /// <param name="item">Item to remove from database.</param>
        void Remove(T item);
    }
}
