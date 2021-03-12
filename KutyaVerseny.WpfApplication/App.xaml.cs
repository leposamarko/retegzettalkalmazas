// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using KutyaVerseny.WpfApplication.Logic;
    using KutyaVerseny.WpfApplication.UI;

    /// <summary>
    /// MyIoc.
    /// </summary>
    internal class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets Instance.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);

            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);
            MyIoc.Instance.Register<IDogLogiWpf, DogLogiWpf>();
        }
    }
}
