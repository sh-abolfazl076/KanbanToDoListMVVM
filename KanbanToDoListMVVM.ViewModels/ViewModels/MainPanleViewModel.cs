// System
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.Utilities;


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class MainPanleViewModel : ViewModelBase
    {

        public ICommand UsersListCommand { get; }
        public ICommand LogOutCommand { get; }
        public ICommand CreateTaskCommand { get; }
        public ICommand TaskCommand { get; }

        public ObservableCollection<Tasks> ToDoTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> DoingTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> ReviewTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> DoneTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> CancelledTasks { get; set; } = new ObservableCollection<Tasks>();

        /// <summary>
        /// This creates the MainPanelViewModel and sets the buttons and user permissions.
        /// </summary>
        /// <param name="navigationStore">change pages in the app</param>
        public MainPanleViewModel(NavigationStore navigationStore) 
        {
            LogOutCommand = new NavigateCommand<LoginViewModel>(
                new NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore)));

            TaskCommand = new TaskCommand(this, navigationStore);

            ReloadTasks();

            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                if (db.UserPermissionsRepository.CheckPermission(ApplicationStore.Instance.UserId, PermissionId.AddTask) != null)
                {
                    CreateTaskCommand = new NavigateCommand<CreateTaskViewModel>(
                        new NavigationService<CreateTaskViewModel>(navigationStore, () => new CreateTaskViewModel(navigationStore)));
                }

                if (db.UserPermissionsRepository.CheckPermission(ApplicationStore.Instance.UserId, PermissionId.AccessUsers) != null)
                {
                    UsersListCommand = new NavigateCommand<UsersListViewModel>(
                        new NavigationService<UsersListViewModel>(navigationStore, () => new UsersListViewModel(navigationStore)));  
                }
            }
        }//End


        /// <summary>
        /// his reloads all tasks for the user and updates every task column.
        /// </summary>
        public void ReloadTasks()
        {
            int userId = ApplicationStore.Instance.UserId;

            LoadTask(ToDoTasks, userId, 1); // ToDo
            LoadTask(DoingTasks, userId, 2);// Doing
            LoadTask(ReviewTasks, userId, 3);// Review
            LoadTask(DoneTasks, userId, 4);// Done
            LoadTask(CancelledTasks, userId, 5);// Cancelled
        }//End


        /// <summary>
        /// This loads tasks for one column and adds them to the list.
        /// </summary>
        /// <param name="targetCollection">Collection bound to UI</param>
        /// <param name="userId">Current user ID</param>
        /// <param name="stageId">Task stage column</param>
        private void LoadTask(ObservableCollection<Tasks> targetCollection, int userId, int stageId)
        {
            targetCollection.Clear();

            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                var tasks = db.TasksRepository.GetAllTasksByUserIdAndStageId(userId, stageId).ToList();
                foreach (var task in tasks)
                    targetCollection.Add(task);
            }
        }//End


    }
}
