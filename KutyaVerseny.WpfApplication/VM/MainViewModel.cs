// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;
    using KutyaVerseny.WpfApplication.Data;
    using KutyaVerseny.WpfApplication.Logic;

    /// <summary>
    /// mian view model.
    /// </summary>
    class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// logic.
        /// </summary>
        private DogLogiWpf logic;

        /// <summary>
        /// Gets collector of dogs.
        /// </summary>
        public ObservableCollection<DogWpf> Dogs { get; private set; } = new ObservableCollection<DogWpf>();

        /// <summary>
        /// Selected dog.
        /// </summary>
        private DogWpf selectedDog;

        /// <summary>
        /// Selected dog.
        /// </summary>
        public DogWpf SelectedDog
        {
            get
            {
                return this.selectedDog;
            }

            set
            {
                this.Set(ref this.selectedDog, value);
            }
        }

        /// <summary>
        /// add cmd.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        public ICommand ModCmd { get; private set; }

        public ICommand DelCmd { get; private set; }

        public ICommand RefreshCmd { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="messenger">mesige.</param>
        public MainViewModel(DogLogiWpf log)
        {
            this.logic = log;
            this.RefreshCarList(this.logic);
            this.AddCmd = new RelayCommand(() => this.logic.AddDog(this.Dogs));
            this.ModCmd = new RelayCommand(() => this.logic.ModyDog(this.SelectedDog));
            this.DelCmd = new RelayCommand(() => this.logic.DelDog(this.Dogs, this.SelectedDog));
            this.RefreshCmd = new RelayCommand(() => this.RefreshCarList(this.logic));
        }

        private void RefreshCarList(DogLogiWpf logic)
        {
            if (this.Dogs.Count > 0)
            {
                this.Dogs.Clear();
            }

            var carsInDb = logic.GetAllDog();

            foreach (var car in carsInDb)
            {
                this.Dogs.Add(car);
            }

        }
        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// ctor.
        /// </summary>
        public MainViewModel() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<DogLogiWpf>())//IoC
        {

        }
        */
        public MainViewModel()
        {
            this.logic = new DogLogiWpf();
            this.RefreshCarList(this.logic);
            this.AddCmd = new RelayCommand(() => this.logic.AddDog(this.Dogs));
            this.ModCmd = new RelayCommand(() => this.logic.ModyDog(this.SelectedDog));
            this.DelCmd = new RelayCommand(() => this.logic.DelDog(this.Dogs, this.SelectedDog));
            this.RefreshCmd = new RelayCommand(() => this.RefreshCarList(this.logic));
        }
    }
}
