// <copyright file="Dog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// this is the main class.
    /// </summary>
    public partial class Dog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dog"/> class.
        /// this is the constructor.
        /// </summary>
        public Dog()
        {
            this.Intervention = new HashSet<Intervention>();
            this.Medal = new HashSet<Medal>();
        }

        /// <summary>
        /// Gets or sets name of the dog.
        /// </summary>
        public string DogName { get; set; }

        /// <summary>
        /// Gets or sets gender of the dog.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets chip number of the medal.
        /// </summary>
        public decimal ChipNum { get; set; }

        /// <summary>
        /// Gets or sets breed of the dog.
        /// </summary>
        public string Breed { get; set; }

        /// <summary>
        /// Gets or sets born date of the dog.
        /// </summary>
        public DateTime? BornDate { get; set; }

        /// <summary>
        /// Gets or sets owner's name of the dog.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets intervertions.
        /// </summary>
        public virtual ICollection<Intervention> Intervention { get; }

        /// <summary>
        /// Gets medals.
        /// </summary>
        public virtual ICollection<Medal> Medal { get; }

        /// <summary>
        /// toString method.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "ID:" + this.ChipNum + " name:" + this.DogName + " owner name:" + this.OwnerName + " gender:" + this.Gender + " born date:" + this.BornDate + " breed:" + this.Breed;
        }
    }
}
