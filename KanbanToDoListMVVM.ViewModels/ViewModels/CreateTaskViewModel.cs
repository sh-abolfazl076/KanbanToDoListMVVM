// System
using System.Collections.ObjectModel;
using System.Windows.Input;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class CreateTaskViewModel : ViewModelBase
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

        private string _taskDuration;
        public string TaskDuration
        {
            get => _taskDuration;
            set
            {
                _taskDuration = value;
                OnPropertyChanged(nameof(TaskDuration));
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

        
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterUsers();
            }
        }
        ////
        
        private Users _selectedUser;
        public Users SelectedUser
        {
            get => _selectedUser;
            set 
            { 
                _selectedUser = value; 
                OnPropertyChanged(nameof(SelectedUser)); 
            }
        }
        ////

        private string _checkValidationLabal;
        public string CheckValidationLabal
        {
            get => _checkValidationLabal;
            set
            {
                _checkValidationLabal = value;
                OnPropertyChanged(nameof(CheckValidationLabal));
            }
        }
        ////

        public ObservableCollection<Users> UsersList { get; set; } = new ObservableCollection<Users>();
        
        public ICommand SubmitAddTask { get; }

        public ICommand BackToMainPanelCommand { get; }

        /// <summary>
        /// This creates the CreateTaskViewModel and sets the buttons for adding a task and going back.
        /// </summary>
        /// <param name="navigationStore">change pages in the app</param>
        public CreateTaskViewModel(NavigationStore navigationStore)
        {
            SubmitAddTask = new CreateTaskCommand(this,navigationStore);
            BackToMainPanelCommand = new NavigateCommand<MainPanleViewModel>(new NavigationService<MainPanleViewModel>(navigationStore, () => new MainPanleViewModel(navigationStore)));
            LoadUsers();
        }//End


        /// <summary>
        /// Load and set usernames from the database
        /// </summary>
        private void LoadUsers()
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                UsersList.Clear();
                foreach (var u in db.UsersRepository.GetAllUsers())UsersList.Add(u);
            }
        }//End


        /// <summary>
        /// Filter ListView by username
        /// </summary>
        private void FilterUsers()
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                UsersList.Clear();
                var result = db.UsersRepository.FilterUserByUsername(SearchText ?? "");
                foreach (var u in result)UsersList.Add(u);
            }
        }//End


    }
}
