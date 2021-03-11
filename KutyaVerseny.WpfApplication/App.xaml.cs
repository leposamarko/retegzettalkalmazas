using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using KutyaVerseny.WpfApplication.Logic;
using KutyaVerseny.WpfApplication.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KutyaVerseny.WpfApplication
{

    class MyIoc : SimpleIoc, IServiceLocator
    {
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);

            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);
            //MyIoc.Instance.Register<DogLogiWpf, DogLogiWpf>();
        }
    }
}
