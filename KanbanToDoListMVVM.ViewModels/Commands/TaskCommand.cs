// System

// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class TaskCommand : CommandBase
    {

        private MainPanleViewModel _viewModel;
        private NavigationStore _navigationStore;

        public TaskCommand(MainPanleViewModel viewModel , NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        /// <summary>
        /// Navigates to the TaskViewModel for the selected task.
        /// </summary>
        /// <param name="parameter">selected task</param>
        public override void Execute(object parameter)
        {
            if (parameter is Tasks task)
            {
                _navigationStore.CurrentViewModel = new TaskViewModel(task,_navigationStore);
            }
        }//End
    }
}
