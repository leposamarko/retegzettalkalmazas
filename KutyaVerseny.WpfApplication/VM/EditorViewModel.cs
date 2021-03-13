// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using KutyaVerseny.WpfApplication.Data;
    using static KutyaVerseny.WpfApplication.Data.DogWpf;

    /// <summary>
    /// editroViewModel.
    /// </summary>
    internal class EditorViewModel : ViewModelBase
    {
        private DogWpf dog;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
        {
            this.dog = new DogWpf();
            if (this.IsInDesignMode)
            {
                this.dog.DogName = "Blöki";
            }
        }

        /// <summary>
        /// Gets or sets dog.
        /// </summary>
        public DogWpf Dog
        {
            get { return this.dog; }
            set { this.Set(ref this.dog, value); }
        }

        /// <summary>
        /// Gets genders of type.
        /// </summary>
        public Array TypeGenders
        {
            get { return Enum.GetValues(typeof(Genders)); }
        }
    }
}
