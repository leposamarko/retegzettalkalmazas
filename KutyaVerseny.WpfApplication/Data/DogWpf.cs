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
    public partial class DogWpf : ObservableObject
    {
        private string dogName;
        private string gender;
        private decimal chipNum;
        private string breed;
        private DateTime? bornDate;
        private string ownerName;

        /*
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
        */

        /// <summary>
        /// enum.
        /// </summary>
        public enum Genders
        {
            /// <summary>
            /// kan.
            /// </summary>
            Kan = 0,

            /// <summary>
            /// female.
            /// </summary>
            Female = 1,
        }

        /// <summary>
        /// Gets or sets name of the dog.
        /// </summary>
        public string DogName { get => this.dogName; set => this.Set(ref this.dogName, value); }

        /// <summary>
        /// Gets or sets gender of the dog.
        /// </summary>
        public string Gender { get => this.gender; set => this.Set(ref this.gender, value); }

        /// <summary>
        /// Gets or sets chip number of the medal.
        /// </summary>
        public decimal ChipNum { get => this.chipNum; set => this.Set(ref this.chipNum, value); }

        /// <summary>
        /// Gets or sets breed of the dog.
        /// </summary>
        public string Breed { get => this.breed; set => this.Set(ref this.breed, value); }

        /// <summary>
        /// Gets or sets born date of the dog.
        /// </summary>
        public DateTime? BornDate { get => this.bornDate; set => this.Set(ref this.bornDate, value); }

        /// <summary>
        /// Gets or sets owner's name of the dog.
        /// </summary>
        public string OwnerName { get => this.ownerName; set => this.Set(ref this.ownerName, value); }

        /// <summary>
        /// copy from method.
        /// </summary>
        /// <returns>dog.</returns>
        public Dog ConvertToEntity()
        {
            Dog d = new Dog();
            d.ChipNum = this.ChipNum;
            d.DogName = this.dogName;
            d.OwnerName = this.ownerName;
            d.Breed = this.breed;
            d.Gender = this.gender;
            d.BornDate = this.bornDate;
            return d;
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
