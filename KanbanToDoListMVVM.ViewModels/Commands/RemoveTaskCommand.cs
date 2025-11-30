// System

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class RemoveTaskCommand : CommandBase
    {
        private Tasks _task;
        private NavigationStore _navigationStore;

        public RemoveTaskCommand(Tasks task, NavigationStore navigationStore)
        {
            _task = task;
            _navigationStore = navigationStore;
        }//End

        /// <summary>
        /// Deletes the selected task from the database
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                db.TasksRepository.RemoveTaskById(_task.ID);
                db.Save();

                _navigationStore.CurrentViewModel = new MainPanleViewModel(_navigationStore);
            }

        }//End

    }
}