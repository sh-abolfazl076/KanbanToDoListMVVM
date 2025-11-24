// System
using System;


// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Services
{
    public class NavigationService<TVeiwModel> where TVeiwModel : ViewModelBase
    {
        
        private readonly NavigationStore _navigationStore;
        private readonly Func<TVeiwModel> _createViewModle;

        public NavigationService(NavigationStore navigationStore, Func<TVeiwModel> createViewModle)
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
