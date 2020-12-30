// <copyright file="MedalRepository.cs" company="Z3VJC0">
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
    /// medalrepo.
    /// </summary>
    public class MedalRepository : MainRepository<Medal>, IMedalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MedalRepository"/> class.
        /// </summary>
        /// <param name="ctx">database.</param>
        public MedalRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// method to change the category.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new cahtery name.</param>
        public void ChangeCategory(int id, string s)
        {
            var medal = this.GetOne(id);
            medal.Category = s;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to change the degree of the medal.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new medal degree.</param>
        public void ChangeDegree(int id, string s)
        {
            var medal = this.GetOne(id);
            medal.Degree = s;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to change the race name.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new race name.</param>
        public void ChangeRaceName(int id, string s)
        {
            var medal = this.GetOne(id);
            medal.RaceName = s;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to change the starters number on the race.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="db">new number of staters.</param>
        public void ChangeStratersNum(int id, int db)
        {
            var medal = this.GetOne(id);
            medal.StartersNum = db;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// get one medal object.
        /// </summary>
        /// <param name="id">id of searching medal.</param>
        /// <returns>a medal.</returns>
        public override Medal GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.MedalId == id);
        }
    }
}
