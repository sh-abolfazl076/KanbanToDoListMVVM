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
    public class CreateTaskCommand : CommandBase
    {
        private CreateTaskViewModel _viewModel;

        public CreateTaskCommand(CreateTaskViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            int stageToDo = 1;
            bool IsCreateTaskFormValid = Validation.IsCreateTaskFormValid(_viewModel.TxtTitleAddTask, _viewModel.TxtInfoAddTask, _viewModel.TxtDurationAddTask);

            int userId = _viewModel.SelectedUser?.ID ?? 0;
            if (userId == 0)
            {
                MessageBox.Show("Please select a user.");
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
                            Title = _viewModel.TxtTitleAddTask,
                            Description = _viewModel.TxtInfoAddTask,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Duration = Convert.ToInt32(_viewModel.TxtDurationAddTask),
                            StageId = stageToDo,
                            UserId = userId
                        };

                        db.TasksRepository.AddTask(task);
                        db.Save();
                    }
                }
                catch
                {
                    MessageBox.Show("Database Error");
                }
            }
        }

    }
}