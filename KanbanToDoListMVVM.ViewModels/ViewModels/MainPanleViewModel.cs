// System
// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class MainPanleViewModel : ViewModelBase
    {
        private string _txtUsername;
        public string TxtUsername
        {
            get
            {
                return _txtUsername;
            }
            set
            {
                _txtUsername = value;
                OnPropertyChanged(nameof(TxtUsername));
            }
        }
        ////

        private string _txtPassword;
        public string TxtPassword
        {
            get
            {
                return _txtPassword;
            }
            set
            {
                _txtPassword = value;
                OnPropertyChanged(nameof(TxtPassword));
            }
        }
        ////

        private string _titleButtom;
        public string TitleButtom
        {
            get
            {
                return _titleButtom;
            }
            set
            {
                _titleButtom = value;
                OnPropertyChanged(nameof(_titleButtom));
            }
        }
        ////


        public ICommand ButtomUsersList { get; }
        public ICommand ButtomLogOut { get; }
        public ICommand ButtomCreateTask { get; }
        public ICommand TaskClickCommand { get; }



        public MainPanleViewModel(NavigationStore navigationStore) 
        {
            ButtomLogOut = new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore)));
            ButtomCreateTask = new NavigateCommand<CreateTaskViewModel>(new NavigationService<CreateTaskViewModel>(navigationStore, () => new CreateTaskViewModel(navigationStore)));
            ButtomUsersList = new NavigateCommand<UsersListViewModel>(new NavigationService<UsersListViewModel>(navigationStore, () => new UsersListViewModel(navigationStore)));
            TaskClickCommand = new TaskCommand(this, navigationStore);
            ReloadTasks();

        }

        public ObservableCollection<Tasks> ToDoTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> DoingTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> ReviewTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> DoneTasks { get; set; } = new ObservableCollection<Tasks>();
        public ObservableCollection<Tasks> CancelledTasks { get; set; } = new ObservableCollection<Tasks>();

        /// <summary>
        /// Reloads all task columns by reading them from the database.
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
        /// Loads tasks for a specific stage and fills the given collection.
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
