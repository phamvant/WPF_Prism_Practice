using Prism.Ioc;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using WPF_Prism_Practice.ViewModels;
using WPF_Prism_Practice.Views;

namespace WPF_Prism_Practice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.ViewA>();
            containerRegistry.RegisterForNavigation<Views.ViewB>();
            containerRegistry.RegisterDialog<Views.ViewC>();
        }
    }

}
