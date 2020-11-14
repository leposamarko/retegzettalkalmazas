// <copyright file="InterventionRepository.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// intervention repo.
    /// </summary>
    public class InterventionRepository : Repository<Intervention>, IInterventionRepositry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterventionRepository"/> class.
        /// </summary>
        /// <param name="ctx">datatbase.</param>
        public InterventionRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// method to change the cost of intervention.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="nc">new cost.</param>
        public void ChangeCost(int id, int nc)
        {
            var inte = this.GetOne(id);
            inte.Cost = nc;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to change the desription.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="txt">new destripton.</param>
        public void ChangeDesript(int id, string txt)
        {
            var inte = this.GetOne(id);
            inte.Desript = txt;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to change the doctro phone number.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="num">new number.</param>
        public void ChangeDocPhone(int id, int num)
        {
            var inte = this.GetOne(id);
            inte.DoctorPhone = num;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// method to change the doctor name.
        /// </summary>
        /// <param name="id">intervention id.</param>
        /// <param name="name">doctor name.</param>
        public void ChangeDoctor(int id, string name)
        {
            var inte = this.GetOne(id);
            inte.Doctor = name;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Intervention GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.InterventionId == id);
        }
    }
}
