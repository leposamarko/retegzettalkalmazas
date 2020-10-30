// <copyright file="Classes.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using KutyaVerseny.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KutyaVerseny.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected DbContext ctx;
        public Repository(DbContext ctx)
        {
            this.ctx = ctx; ;
        }
        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public abstract void Add(T item);

        void IRepository<T>.Add(T item)
        {
            throw new NotImplementedException();
        }
    }

}
