// <copyright file="IInterventionLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using Microsoft.VisualBasic;

    /// <summary>
    /// Intervention interface.
    /// </summary>
    public interface IInterventionLogic
    {
        /// <summary>
        /// method to change the doctor name.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="name">doctor name.</param>
        void ChangeInterventionDoctor(int id, string name);

        /// <summary>
        /// method to change the doctro phone number.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="num">new number.</param>
        void ChangeInterventionDocPhone(int id, int num);

        /// <summary>
        /// method to change the desription.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="txt">new destripton.</param>
        void ChangeInterventionDesript(int id, string txt);

        /// <summary>
        /// method to change the cost of intervention.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="nc">new cost.</param>
        void ChangeInterventionCost(int id, int nc);

        /// <summary>
        /// get all intervention from database.
        /// </summary>
        /// <returns>all intervetnion.</returns>
        IList<Intervention> GetAllIntervention();

        /// <summary>
        /// Take a intervention by id.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <returns>a intervention.</returns>
        Intervention GetIntervention(int id);
    }
}
