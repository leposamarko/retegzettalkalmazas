// <copyright file="Intervention.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// the main class.
    /// </summary>
    public partial class Intervention
    {
        /// <summary>
        /// Gets or sets name of the doctor who made the intervention.
        /// </summary>
        public string Doctor { get; set; }

        /// <summary>
        /// Gets or sets the phone number of doctor.
        /// </summary>
        public int? DoctorPhone { get; set; }

        /// <summary>
        /// Gets or sets date of the intervention.
        /// </summary>
        public DateTime? InterventionDate { get; set; }

        /// <summary>
        /// Gets or sets desription of the intervention.
        /// </summary>
        public string Desript { get; set; }

        /// <summary>
        /// Gets or sets id of the intervention.
        /// </summary>
        public int InterventionId { get; set; }

        /// <summary>
        /// Gets or sets the dog chip number.
        /// </summary>
        public int? DogChipNum { get; set; }

        /// <summary>
        /// Gets or sets cost of the intervention.
        /// </summary>
        public int? Cost { get; set; }

        /// <summary>
        /// Gets or sets of the connection.
        /// </summary>
        public virtual Dog DogChipNumNavigation { get; set; }

        /// <summary>
        /// tostring.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "ID:" + this.InterventionId + " ;Doctor name:" + this.Doctor + " ;doctor phone:" + "  ;desription:" + this.Desript + " ;dog chip number:" + this.DogChipNum + " cost:" + this.Cost;
        }
    }
}
