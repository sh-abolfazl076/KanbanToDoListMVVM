// System
using KanbanToDoListMVVM.ViewModels.Stores;


// Internal


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private INavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(INavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModleChanged;
        }

        private void OnCurrentViewModleChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
