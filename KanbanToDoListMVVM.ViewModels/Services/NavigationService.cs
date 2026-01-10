// System
using System;


// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Services
{
    public class NavigationService<TVeiwModel> : INavigationService<TVeiwModel> where TVeiwModel : ViewModelBase
    {

        private readonly INavigationStore _navigationStore;
        private readonly Func<TVeiwModel> _createViewModle;

        public NavigationService(INavigationStore navigationStore, Func<TVeiwModel> createViewModle)
        {
            _navigationStore = navigationStore;
            _createViewModle = createViewModle;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModle();
        }
    }
}
