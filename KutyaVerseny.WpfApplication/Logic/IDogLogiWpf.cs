// <copyright file="IDogLogiWpf.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KutyaVerseny.WpfApplication.Data;

    /// <summary>
    /// IDogLogci.
    /// </summary>
    internal interface IDogLogiWpf
    {
        /// <summary>
        /// Add dog method.
        /// </summary>
        /// <param name="list">list of dogs.</param>
        public void AddDog(IList<DogWpf> list);

        /// <summary>
        /// get all dog method.
        /// </summary>
        /// <returns>all dog.</returns>
        public IEnumerable<DogWpf> GetAllDog();

        /// <summary>
        /// delete a dog.
        /// </summary>
        /// <param name="list">list of dogs.</param>
        /// <param name="dog">dog to remove.</param>
        public void DelDog(IList<DogWpf> list, DogWpf dog);

        /// <summary>
        /// mody dog.
        /// </summary>
        /// <param name="dogToModi">dog to mody.</param>
        public void ModyDog(DogWpf dogToModi);
    }
}
