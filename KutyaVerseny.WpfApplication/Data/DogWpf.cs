// <copyright file="DogWpf.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// dog entity in wpf.
    /// </summary>
    public class DogWpf : ObservableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DogWpf"/> class.
        /// </summary>
        public DogWpf()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DogWpf"/> class.
        /// </summary>
        /// <param name="d">dog.</param>
        public DogWpf(Dog d)
        {
            this.ChipNum = d.ChipNum;
            this.DogName = d.DogName;
            this.Gender = d.Gender;
            this.Breed = d.Breed;
            this.BornDate = d.BornDate;
            this.OwnerName = d.OwnerName;
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
        /// copy from method.
        /// </summary>
        /// <returns>dog.</returns>
        public Dog ConvertToEntity()
        {
            return new Dog() { ChipNum = this.ChipNum, BornDate = this.BornDate, OwnerName = this.OwnerName, Breed = this.Breed, Gender = this.Gender, DogName = this.DogName };
        }

        /// <summary>
        /// other copyfrom.
        /// </summary>
        /// <param name="dog">dot to copy.</param>
        public void CopyFrom(DogWpf dog)
        {
            this.GetType().GetProperties().ToList().ForEach(p => p.SetValue(this, p.GetValue(dog)));
        }
    }
}
