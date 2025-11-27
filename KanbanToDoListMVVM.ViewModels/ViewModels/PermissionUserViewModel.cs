// System
using System.Windows.Input;

// Internal



namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class PermissionUserViewModel : ViewModelBase
    {

        private string _titlePermission;
        public string TitlePermission
        {
            get
            {
                return _titlePermission = "User Permission";
            }
            set
            {
                _titlePermission = value;
                OnPropertyChanged(nameof(TitlePermission));
            }
        }
        ////
        
        private bool _addTask;
        public bool AddTask
        {
            get
            {
                return _addTask;
            }
            set
            {
                _addTask = value;
                OnPropertyChanged(nameof(AddTask));
            }
        }
        ////

        private bool _deleteTask;
        public bool DeleteTask
        {
            get
            {
                return _deleteTask;
            }
            set
            {
                _deleteTask = value;
                OnPropertyChanged(nameof(DeleteTask));
            }
        }
        ////

        private bool _manageUserAccess;
        public bool ManageUserAccess
        {
            get
            {
                return _manageUserAccess;
            }
            set
            {
                _manageUserAccess = value;
                OnPropertyChanged(nameof(ManageUserAccess));
            }
        }
        ////

        private bool _updateTask;
        public bool UpdateTask
        {
            get
            {
                return _updateTask;
            }
            set
            {
                _updateTask = value;
                OnPropertyChanged(nameof(UpdateTask));
            }
        }
        ////


        public ICommand SubmitPermssionUser { get; }

        public PermissionUserViewModel()
        {
            SubmitPermssionUser = new PermissionUserCommand();
        }

    }
}
