using FullApp3.Core.Mvvm;
using FullApp3.Services.Interfaces;
using Prism.Regions;

namespace FullApp3.Modules.TimeCard.ViewModels
{
    public class EditTimeCardViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public EditTimeCardViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
