// <copyright file="DogListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// doglist.
    /// </summary>
    public class DogListViewModel
    {
        /// <summary>
        /// Gets or sets list of dogs.
        /// </summary>
        public List<Dog> ListOfDog { get; set; }

        /// <summary>
        /// Gets or sets editd dog.
        /// </summary>
        public Dog EditedDog { get; set; }
    }
}
