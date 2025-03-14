using FullApp3.Core;
using FullApp3.Modules.TimeCard.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace FullApp3.Modules.TimeCard
{
    public class TimeCardModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public TimeCardModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "EditTimeCard");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<EditTimeCard>();
        }
    }
}