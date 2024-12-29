using FullApp3.Modules.TimeCard;
using FullApp3.Services;
using FullApp3.Services.Interfaces;
using FullApp3.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace FullApp3
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
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<TimeCardModule>();
        }
    }
}
