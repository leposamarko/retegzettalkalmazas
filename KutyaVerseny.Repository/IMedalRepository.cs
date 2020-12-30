// <copyright file="IMedalRepository.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// meda repo.
    /// </summary>
    public interface IMedalRepository : IRepository<Medal>
    {
        /// <summary>
        /// method to change the degree of the medal.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new medal degree.</param>
        void ChangeDegree(int id, string s);

        /// <summary>
        /// method to change the race name.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new race name.</param>
        void ChangeRaceName(int id, string s);

        /// <summary>
        /// method to change the category.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new cahtery name.</param>
        void ChangeCategory(int id, string s);

        /// <summary>
        /// method to change the starters number on the race.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="db">new number of staters.</param>
        void ChangeStratersNum(int id, int db);
    }
}
