// <copyright file="MainRepository.cs" company="Z3VJC0">
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
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// repositry class.
    /// </summary>
    /// <typeparam name="T">unknow object.</typeparam>
    public abstract class MainRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets ctx.
        /// </summary>
        protected DbContext Ctx { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainRepository{T}"/> class.
        /// constructor.
        /// </summary>
        /// <param name="ctx">ctx is the context.</param>
        #pragma warning disable SA1201 // Elements should appear in the correct order
        public MainRepository(DbContext ctx)
        #pragma warning restore SA1201 // Elements should appear in the correct order
        {
            this.Ctx = ctx;
        }

        /// <summary>
        /// list all data from the T.
        /// </summary>
        /// <returns>Iqueryable list with all data.</returns>
        public IQueryable<T> GetAll()
        {
            return this.Ctx.Set<T>();
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
            this.Ctx.Remove<T>(item);
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to add an item.
        /// </summary>
        /// <param name="item">item to add.</param>
        public void Add(T item)
        {
            this.Ctx.Add<T>(item);
            this.Ctx.SaveChanges();
        }
    }
}
