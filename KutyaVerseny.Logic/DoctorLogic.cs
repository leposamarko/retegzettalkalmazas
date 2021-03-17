﻿// <copyright file="DoctorLogic.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
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
    /// doctro logic.
    /// </summary>
    public class DoctorLogic : IDoctorLogic
    {
        private IInterventionRepositry interRepo;
        private IDogRepository dogRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorLogic"/> class.
        /// intervention logic.
        /// </summary>
        /// <param name="repo">repo.</param>
        /// <param name="dogRepo">dogrepo.</param>
        public DoctorLogic(IInterventionRepositry repo, IDogRepository dogRepo)
        {
            this.interRepo = repo;
            this.dogRepo = dogRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorLogic"/> class.
        /// </summary>
        /// <param name="repo">repository.</param>
        public DoctorLogic(IInterventionRepositry repo)
        {
            this.interRepo = repo;
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
        public void ChangeInterventionDescript(int id, string txt)
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

        /// <summary>
        /// Add Intervention.
        /// </summary>
        /// <param name="i">Intervention.</param>
        public void Add(Intervention i)
        {
            this.interRepo.Add(i);
        }

        /// <summary>
        /// Remove an Intervention.
        /// </summary>
        /// <param name="i">Intervention.</param>
        public void Remov(Intervention i)
        {
            this.interRepo.Remove(i);
        }

        /// <summary>
        /// return all doctor.
        /// </summary>
        /// <returns>string list.</returns>
        public IList<string> AllDoctor()
        {
            IList<string> doctors = new List<string>();
            foreach (var item in this.interRepo.GetAll().ToList())
            {
                if (!doctors.Contains(item.Doctor))
                {
                    doctors.Add(item.Doctor);
                }
            }

            return doctors;
        }

        /// <summary>
        /// Docotrs interventions.
        /// </summary>
        /// <param name="name">doctor name.</param>
        /// <returns>list.</returns>
        public IList<Intervention> AllInterventionForDoc(string name)
        {
            return this.interRepo.GetAll().Where(x => x.Doctor == name).ToList();
        }

        /// <summary>
        /// Dog neutering.
        /// </summary>
        /// <param name="chipNum">dog chip number.</param>
        public void DogNeutering(int chipNum)
        {
            this.dogRepo.DogNeutering(chipNum);
        }
    }
}
