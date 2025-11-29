// System
using System.Windows.Input;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.Utilities;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        private string _taskTitle;
        public string TaskTitle
        {
            get => _taskTitle;
            set
            {
                _taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));
            }
        }
        ////
        
        private string _taskDescription;
        public string TaskDescription
        {
            get => _taskDescription;
            set
            {
                _taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }
        ////

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }
        ////


        public ICommand SubmitEditTaskCommand { get; }
        public ICommand BackToMainPanleCommand { get; }
        public ICommand RemoveTaskCommand { get; }

        /// <summary>
        /// This creates the TaskViewModel and sets the task info and the buttons for edit, delete, and back.
        /// </summary>
        /// <param name="task">task data</param>
        /// <param name="navigationStore">change pages in the app</param>
        public TaskViewModel(Tasks task ,NavigationStore navigationStore)
        {
            TaskTitle = task.Title;
            TaskDescription = task.Description;

            BackToMainPanleCommand = new NavigateCommand<MainPanleViewModel>(new NavigationService<MainPanleViewModel>(navigationStore, () => new MainPanleViewModel(navigationStore)));

            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                if (db.UserPermissionsRepository.CheckPermission(ApplicationStore.Instance.UserId, PermissionId.ModifyTask) != null)
                {
                    SubmitEditTaskCommand = new EditTaskCommand(task ,this, navigationStore);  
                }

                if (db.UserPermissionsRepository.CheckPermission(ApplicationStore.Instance.UserId, PermissionId.RemoveTask) != null)
                {
                    RemoveTaskCommand = new RemoveTaskCommand(task, navigationStore);
                }
            }//End


        }

    }
}
