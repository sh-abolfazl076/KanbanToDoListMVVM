// System

// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class TaskCommand : CommandBase
    {

        private MainPanleViewModel _ViewModel;
        private NavigationStore _navigationStore;

        public TaskCommand(MainPanleViewModel viewModel , NavigationStore navigationStore)
        {
            _ViewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Tasks task)
            {
                _navigationStore.CurrentViewModel = new TaskViewModel(task,_navigationStore);
            }
        }
    }
}
