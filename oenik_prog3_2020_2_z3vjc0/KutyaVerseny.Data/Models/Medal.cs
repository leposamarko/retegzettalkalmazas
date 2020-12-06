// <copyright file="Medal.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This is the main class.
    /// </summary>
    public partial class Medal
    {
        /// <summary>
        ///  Gets or sets this is the id of medal table.
        /// </summary>
        public decimal MedalId { get; set; }

        /// <summary>
        ///  Gets or sets the degree of the medal.
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// Gets or sets the dog chip number.
        /// </summary>
        public decimal? DogChipNum { get; set; }

        /// <summary>
        /// Gets or sets the date of the medal winnig.
        /// </summary>
        public DateTime? WonDate { get; set; }

        /// <summary>
        /// Gets or sets the race name where the dog win the medal.
        /// </summary>
        public string RaceName { get; set; }

        /// <summary>
        /// Gets or sets the category when win the medal.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the straters number of the race.
        /// </summary>
        public decimal? StartersNum { get; set; }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        public virtual Dog DogChipNumNavigation { get; set; }

        /// <summary>
        /// tostring.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "ID:" + this.MedalId + " ;Degree:" + this.Degree + " ;Dog ChipNum:" + this.DogChipNum + " ;Category:" + this.Category + " ;Race name:" + this.RaceName + " ;won date:" + this.WonDate + " ;starters number:" + this.StartersNum;
        }
    }
}
