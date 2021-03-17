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
    /// Mian view model.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Selected dog.
        /// </summary>
        private DogWpf selectedDog;

        /// <summary>
        /// logic.
        /// </summary>
        private IDogLogiWpf logic;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="log">log.</param>
        public MainViewModel(IDogLogiWpf log)
        {
            this.logic = log;
            if (log != null)
            {
                foreach (var item in this.logic.GetAllDog())
                {
                    this.Dogs.Add(item);
                }
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddDog(this.Dogs));
            this.ModCmd = new RelayCommand(() => this.logic.ModyDog(this.SelectedDog));
            this.DelCmd = new RelayCommand(() => this.logic.DelDog(this.Dogs, this.SelectedDog));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IDogLogiWpf>())
        {
        }

        /// <summary>
        /// Gets collector of dogs.
        /// </summary>
        public ObservableCollection<DogWpf> Dogs { get; private set; } = new ObservableCollection<DogWpf>();

        /// <summary>
        /// Gets or sets .Selected dog.
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
        /// Gets add cmd.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets modcmd.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets delcmd.
        /// </summary>
        public ICommand DelCmd { get; private set; }
    }
}
