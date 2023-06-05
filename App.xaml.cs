using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismWPF.ViewModels;
using PrismWPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrismWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<IndexAView>();
            containerRegistry.RegisterForNavigation<IndexBView>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register(typeof(IndexAView).ToString(), typeof(IndexAViewModel));
            ViewModelLocationProvider.Register(typeof(IndexBView).ToString(), typeof(IndexBViewModel));
            ViewModelLocationProvider.Register(typeof(MainView).ToString(), typeof(MainViewModel));

        }
    }
}
