// <copyright file="MainVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kutyaverseny.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// mian vm.
    /// </summary>
    internal class MainVM : ViewModelBase
    {
        private MainLogic logic;
        private DogVM selectedDog;
        private ObservableCollection<DogVM> allDogs;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
        {
            this.logic = new MainLogic();
            this.LoadCmd = new RelayCommand(() => this.AllDogs = new ObservableCollection<DogVM>(this.logic.ApiGetDogs()));

            this.DelCmd = new RelayCommand(() => this.logic.ApiDelDog(this.selectedDog));
            this.AddCmd = new RelayCommand(() => this.logic.EditDog(null, this.EditorFunc));
            this.ModCmd = new RelayCommand(() => this.logic.EditDog(this.selectedDog, this.EditorFunc));
        }

        /// <summary>
        /// Gets or sets all cars.
        /// </summary>
        public ObservableCollection<DogVM> AllDogs
        {
            get { return this.allDogs; }
            set { this.Set(ref this.allDogs, value); }
        }

        /// <summary>
        /// Gets or sets a dog..
        /// </summary>
        public DogVM SelectedDog
        {
            get { return this.selectedDog; }
            set { this.Set(ref this.selectedDog, value); }
        }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public Func<DogVM, bool> EditorFunc { get; set; }

        /// <summary>
        /// Gets .
        /// </summary>
        public ICommand AddCmd { get;  private set; }

        /// <summary>
        /// Gets .
        /// </summary>
        public ICommand DelCmd { get;  private set; }

        /// <summary>
        /// Gets .
        /// </summary>
        public ICommand ModCmd { get;  private set; }

        /// <summary>
        /// Gets .
        /// </summary>
        public ICommand LoadCmd { get;  private set; }
    }
}
