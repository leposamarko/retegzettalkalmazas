// <copyright file="Repository.cs" company="PlaceholderCompany">
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
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// repositry class.
    /// </summary>
    /// <typeparam name="T">unknow object.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// constructor.
        /// </summary>
        /// <param name="ctx">ctx is the context.</param>
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// list all data from the T.
        /// </summary>
        /// <returns>Iqueryable list with all data.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Take the searched one item.
        /// </summary>
        /// <param name="id">id of the searching item.</param>
        /// <returns>an item.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// methond to remov an item.
        /// </summary>
        /// <param name="item">item to remove.</param>
        public void Remove(T item)
        {
            this.ctx.Remove<T>(item);
        }

        /// <summary>
        /// method to add an item.
        /// </summary>
        /// <param name="item">item to add.</param>
        public void Add(T item)
        {
            this.ctx.Add<T>(item);
        }
    }
}
