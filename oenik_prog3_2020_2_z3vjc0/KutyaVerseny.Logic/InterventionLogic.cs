// <copyright file="InterventionLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;

    /// <summary>
    /// intervention logic class.
    /// </summary>
    public class InterventionLogic : IInterventionLogic
    {
        private readonly IInterventionRepositry interRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterventionLogic"/> class.
        /// intervention logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        public InterventionLogic(IInterventionRepositry repo)
        {
            this.interRepo = repo;
        }

        /// <summary>
        /// method to change the doctor name.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="name">doctor name.</param>
        public void ChangeInterventionDoctor(int id, string name)
        {
            this.interRepo.ChangeDoctor(id, name);
        }

        /// <summary>
        /// method to change the doctro phone number.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="num">new number.</param>
        public void ChangeInterventionDocPhone(int id, int num)
        {
            this.interRepo.ChangeDocPhone(id, num);
        }

        /// <summary>
        /// method to change the desription.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="txt">new destripton.</param>
        public void ChangeInterventionDesript(int id, string txt)
        {
            this.interRepo.ChangeDesript(id, txt);
        }

        /// <summary>
        /// method to change the cost of intervention.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="nc">new cost.</param>
        public void ChangeInterventionCost(int id, int nc)
        {
            this.interRepo.ChangeCost(id, nc);
        }

        /// <summary>
        /// get all intervention from database.
        /// </summary>
        /// <returns>all intervetnion.</returns>
        public IList<Intervention> GetAllIntervention()
        {
            return this.interRepo.GetAll().ToList();
        }

        /// <summary>
        /// Take a intervention by id.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <returns>a intervention.</returns>
        public Intervention GetIntervention(int id)
        {
            return this.interRepo.GetOne(id);
        }
    }
}
