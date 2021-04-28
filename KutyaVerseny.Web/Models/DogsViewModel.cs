// <copyright file="DogsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// dogs view model.
    /// </summary>
    public class DogsViewModel
    {
        /// <summary>
        /// Gets or sets lost of dogs.
        /// </summary>
        public IEnumerable<Dog> ListOfDogs { get; set; }
    }
}
