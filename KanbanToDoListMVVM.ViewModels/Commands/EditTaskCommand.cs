// System
using System;
using System.Windows;

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
        private TaskViewModel _ViewModel;
        private NavigationStore _navigationStore;
        private Tasks _task;

        public EditTaskCommand(Tasks task ,TaskViewModel viewModel, NavigationStore navigationStore)
        {
            _ViewModel = viewModel;
            _navigationStore = navigationStore;
            _task = task;
        }

        public override void Execute(object parameter)
        {
            int selectedIndex = _ViewModel.SelectedIndex;
            
            bool IsTaskFormValid = Validation.IsTaskFormValid(_ViewModel.TaskTitle, _ViewModel.TaskDescription, selectedIndex);
            if (IsTaskFormValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var task = db.TasksRepository.GetTaskById(_task.ID);
                        if (task != null)
                        {
                            task.Title = _ViewModel.TaskTitle;
                            task.Description = _ViewModel.TaskDescription;
                            //task.Description = Description;
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
                    MessageBox.Show("Database Error");
                }


            }
        }//End
    }
}
