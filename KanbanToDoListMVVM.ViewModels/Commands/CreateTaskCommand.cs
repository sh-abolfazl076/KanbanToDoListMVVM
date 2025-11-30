// System
using System;
using System.Threading.Tasks;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.Utilities;
using KanbanToDoListMVVM.ViewModels.ViewModels;



namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class CreateTaskCommand : CommandBase
    {
        private CreateTaskViewModel _viewModel;
        private NavigationStore _navigationStore;

        /// <summary>
        /// This creates the CreateTaskCommand and saves the view model and navigation store.
        /// </summary>
        /// <param name="viewModel">Create Task screen data</param>
        /// <param name="navigationStore">change pages in the app</param>
        public CreateTaskCommand(CreateTaskViewModel viewModel ,NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }//End


        /// <summary>
        /// This runs when the user clicks the Add Task button.
        /// It checks the task data and the selected user.
        /// If something is wrong, it shows an error message.
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object parameter)
        {
            int stageToDo = 1;
            bool IsCreateTaskFormValid = Validation.IsCreateTaskFormValid(_viewModel.TaskTitle, _viewModel.TaskDescription, _viewModel.TaskDuration);

            int userId = _viewModel.SelectedUser?.ID ?? 0;
            if (userId == 0)
            {
                _viewModel.CheckValidationLabal = "";
                await Task.Delay(1000);
                _viewModel.CheckValidationLabal = "Please select a user.";
                return;
            }

            if (IsCreateTaskFormValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        Tasks task = new Tasks()
                        {
                            Title = _viewModel.TaskTitle,
                            Description = _viewModel.TaskDescription,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Duration = Convert.ToInt32(_viewModel.TaskDuration),
                            StageId = stageToDo,
                            UserId = userId
                        };

                        db.TasksRepository.AddTask(task);
                        db.Save();
                        _navigationStore.CurrentViewModel = new MainPanleViewModel(_navigationStore);
                    }
                }
                catch
                {
                    _viewModel.CheckValidationLabal = "";
                    await Task.Delay(1000);
                    _viewModel.CheckValidationLabal = "Database Error.";
                }
            }
            else
            {
                _viewModel.CheckValidationLabal = "";
                await Task.Delay(1000);
                _viewModel.CheckValidationLabal = "This field is invalid";
            }
        }//End

    }
}