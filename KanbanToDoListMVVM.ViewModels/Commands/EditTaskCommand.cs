// System
using System;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.Utilities;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class EditTaskCommand : CommandBase
    {
        private TaskViewModel _viewModel;
        private NavigationStore _navigationStore;
        private Tasks _task;

        public EditTaskCommand(Tasks task ,TaskViewModel viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
            _task = task;
        }

        /// <summary>
        /// This runs when the user clicks the Save button to edit a task.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            int selectedIndex = _viewModel.SelectedIndex;
            
            bool IsTaskFormValid = Validation.IsTaskFormValid(_viewModel.TaskTitle, _viewModel.TaskDescription, selectedIndex);
            if (IsTaskFormValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var task = db.TasksRepository.GetTaskById(_task.ID);
                        if (task != null)
                        {
                            task.Title = _viewModel.TaskTitle;
                            task.Description = _viewModel.TaskDescription;
                            task.UpdatedAt = DateTime.Now;
                            task.StageId = selectedIndex + 1;
                            db.TasksRepository.UpdateTask(task);
                            db.Save();
                            _navigationStore.CurrentViewModel = new MainPanleViewModel(_navigationStore);
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Database Error");
                }


            }
        }//End
    }
}
