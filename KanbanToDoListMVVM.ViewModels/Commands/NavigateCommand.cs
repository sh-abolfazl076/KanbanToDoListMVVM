// System
using System;


// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class NavigateCommand<TViewModle> : CommandBase where TViewModle : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModle> _createViewModle;

        public NavigateCommand(NavigationStore navigationStore , Func<TViewModle> createViewModle)
        {
            _navigationStore = navigationStore;
            _createViewModle = createViewModle;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModle();
        }
    }
}
