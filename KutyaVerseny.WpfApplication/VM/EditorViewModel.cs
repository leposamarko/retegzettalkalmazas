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

    /// <summary>
    /// editroViewModel.
    /// </summary>
    class EditorViewModel : ViewModelBase
    {
        private DogWpf dog;

        public DogWpf Dog
        {
            get { return this.dog; }
            set { this.Set(ref this.dog, value); }
        }

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
    }
}
