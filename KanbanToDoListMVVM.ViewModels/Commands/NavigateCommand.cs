// System

// Internal
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class NavigateCommand<TViewModle> : CommandBase where TViewModle : ViewModelBase
    {
        private readonly NavigationService<TViewModle> _navigationService;

        public NavigateCommand(NavigationService<TViewModle> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
