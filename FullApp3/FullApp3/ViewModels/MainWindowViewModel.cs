using Prism.Commands;
using Prism.Mvvm;
using FullApp3.Modules.TimeCard.Views;

namespace FullApp3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand NavigateToTimeCardCommand { get; private set; }
        public DelegateCommand NavigateToTimeCardListCommand { get; private set; }

        public MainWindowViewModel()
        {
            NavigateToTimeCardCommand = new DelegateCommand(ExecuteNavigateToTimeCard);
            NavigateToTimeCardListCommand = new DelegateCommand(ExecuteNavigateToTimeCardList);
        }

        private void ExecuteNavigateToTimeCard()
        {
            var window = new EditTimeCard();
            window.Show();
        }

        private void ExecuteNavigateToTimeCardList()
        {
            var window = new TimeCardList();
            window.Show();
        }

        public string Title => "タイムカード管理システム";
    }
}
