// <copyright file="IDoctorLogic.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// interface of doglogic.
    /// </summary>
    public interface IDoctorLogic
    {
        /// <summary>
        /// All doctor.
        /// </summary>
        /// <returns>String list.</returns>
        IList<string> AllDoctor();

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
        void ChangeInterventionDescript(int id, string txt);

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

        /// <summary>
        /// Add an Intervention.
        /// </summary>
        /// <param name="i">Intervention.</param>
        void Add(Intervention i);

        /// <summary>
        /// Remova an Intervention.
        /// </summary>
        /// <param name="i">Intervention.</param>
        void Remov(Intervention i);

        /// <summary>
        /// list the intervention for a doctro.
        /// </summary>
        /// <param name="name">name of the doctor.</param>
        /// <returns>list of intervention.</returns>
        IList<Intervention> AllInterventionForDoc(string name);

        /// <summary>
        /// Dog neutering.
        /// </summary>
        /// <param name="chipNum">dog chip number.</param>
        void DogNeutering(int chipNum);
    }
}
