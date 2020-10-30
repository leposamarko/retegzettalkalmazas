// <copyright file="IInterventionRepositry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

    /// <summary>
    /// intervention repo.
    /// </summary>
    public interface IInterventionRepositry : IRepository<Intervention>
    {
        /// <summary>
        /// method to change the doctor name.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="name">doctor name.</param>
        void ChangeDoctor(int id, string name);

        /// <summary>
        /// method to change the doctro phone number.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="num">new number.</param>
        void ChangeDocPhone(int id, int num);

        /// <summary>
        /// method to change the desription.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="txt">new destripton.</param>
        void ChangeDesript(int id, string txt);

        /// <summary>
        /// method to change the cost of intervention.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="nc">new cost.</param>
        void ChangeCost(int id, int nc);
    }
}
