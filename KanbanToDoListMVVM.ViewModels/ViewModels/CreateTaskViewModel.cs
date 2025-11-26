// System
using System.Collections.ObjectModel;
using System.Windows.Input;


// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Stores;


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class CreateTaskViewModel : ViewModelBase
    {
        private string _txtTitleAddTask;
        public string TxtTitleAddTask
        {
            get
            {
                return _txtTitleAddTask;
            }
            set
            {
                _txtTitleAddTask = value;
                OnPropertyChanged(nameof(TxtTitleAddTask));
            }
        }
        ////

        private string _txtDurationAddTask;
        public string TxtDurationAddTask
        {
            get
            {
                return _txtDurationAddTask;
            }
            set
            {
                _txtDurationAddTask = value;
                OnPropertyChanged(nameof(TxtDurationAddTask));
            }
        }
        ////

        private string _txtInfoAddTask;
        public string TxtInfoAddTask
        {
            get
            {
                return _txtInfoAddTask;
            }
            set
            {
                _txtInfoAddTask = value;
                OnPropertyChanged(nameof(TxtInfoAddTask));
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
        
        public ObservableCollection<Users> UsersList { get; set; } = new ObservableCollection<Users>();

         
        public ICommand SubmitAddTask { get; }

        
        public CreateTaskViewModel()
        {
            SubmitAddTask = new CreateTaskCommand(this);
            LoadUsers();
        }

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
        }

        /// <summary>
        /// Filter GridView by username
        /// </summary>
        private void FilterUsers()
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                UsersList.Clear();
                var result = db.UsersRepository.FilterUserByUsername(SearchText ?? "");
                foreach (var u in result)UsersList.Add(u);
            }
        }


    }
}
