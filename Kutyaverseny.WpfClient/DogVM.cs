// <copyright file="DogVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kutyaverseny.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// dog vm.
    /// </summary>
    public class DogVM : ObservableObject
    {
        private string dogName;
        private string gender;
        private decimal chipNum;
        private string breed;
        private DateTime bornDate;
        private string ownerName;

        /// <summary>
        /// Gets or sets name of the dog.
        /// </summary>
        public string DogName
        {
            get { return this.dogName; }
            set { this.Set(ref this.dogName, value); }
        }

        /// <summary>
        /// Gets or sets gender of the dog.
        /// </summary>
        public string Gender
        {
            get { return this.gender; }
            set { this.Set(ref this.gender, value); }
        }

        /// <summary>
        /// Gets or sets chip number of the medal.
        /// </summary>
        public decimal ChipNum
        {
            get { return this.chipNum; }
            set { this.Set(ref this.chipNum, value); }
        }

        /// <summary>
        /// Gets or sets breed of the dog.
        /// </summary>
        public string Breed
        {
            get { return this.breed; }
            set { this.Set(ref this.breed, value); }
        }

        /// <summary>
        /// Gets or sets born date of the dog.
        /// </summary>
        public DateTime BornDate
        {
            get { return this.bornDate; }
            set { this.Set(ref this.bornDate, value); }
        }

        /// <summary>
        /// Gets or sets owner's name of the dog.
        /// </summary>
        public string OwnerName
        {
            get { return this.ownerName; }
            set { this.Set(ref this.ownerName, value); }
        }

        /// <summary>
        /// copy from.
        /// </summary>
        /// <param name="other">copyed dog.</param>
        public void CopyFrom(DogVM other)
        {
            if (other == null)
            {
                return;
            }

            this.chipNum = other.chipNum;
            this.dogName = other.dogName;
            this.ownerName = other.ownerName;
            this.breed = other.breed;
            this.gender = other.gender;
        }
    }
}
