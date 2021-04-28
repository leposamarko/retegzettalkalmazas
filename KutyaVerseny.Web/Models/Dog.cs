// <copyright file="Dog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// dog.
    /// </summary>
    public class Dog
    {
        /// <summary>
        /// Gets or sets name of the dog.
        /// </summary>
        [Display(Name ="Dog Name")]
        public string DogName { get; set; }

        /// <summary>
        /// Gets or sets gender of the dog.
        /// </summary>
        [Display(Name ="Dog Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets chip number of the medal.
        /// </summary>
        [Display(Name ="Dog chip numb")]
        public int ChipNum { get; set; }

        /// <summary>
        /// Gets or sets breed of the dog.
        /// </summary>
        [Display(Name = "Dog Breed")]
        public string Breed { get; set; }

        /// <summary>
        /// Gets or sets born date of the dog.
        /// </summary>
        [Display(Name = "Dog Bord date")]
        public DateTime BornDate { get; set; }

        /// <summary>
        /// Gets or sets owner's name of the dog.
        /// </summary>
        [Display(Name = "Dog owner name")]
        public string OwnerName { get; set; }

        /// <summary>
        /// toString method.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "ID:" + this.ChipNum + " name:" + this.DogName + " owner name:" + this.OwnerName + " gender:" + this.Gender + " breed:" + this.Breed;
        }
    }
}
