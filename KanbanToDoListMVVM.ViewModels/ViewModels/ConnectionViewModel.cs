// System
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using System.Windows.Input;


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class ConnectionViewModel :ViewModelBase
    {
        private string _serverNameDatabase;
        public string ServerNameDatabase
        {
            get
            {
                return _serverNameDatabase;
            }
            set
            {
                _serverNameDatabase = value;
                OnPropertyChanged(nameof(ServerNameDatabase));
            }
        }
        ////

        private string _databaseName;
        public string DatabaseName
        {
            get
            {
                return _databaseName;
            }
            set
            {
                _databaseName = value;
                OnPropertyChanged(nameof(DatabaseName));
            }
        }
        ////
        
        private string _usernameDatabase;
        public string UsernameDatabase
        {
            get
            {
                return _usernameDatabase;
            }
            set
            {
                _usernameDatabase = value;
                OnPropertyChanged(nameof(UsernameDatabase));
            }
        }
        ////

        private string _passwordDatabase;
        public string PasswordDatabase
        {
            get
            {
                return _passwordDatabase;
            }
            set
            {
                _passwordDatabase = value;
                OnPropertyChanged(nameof(PasswordDatabase));
            }
        }
        ////

        public ICommand ButtonCheckConnection {  get;}

        public ConnectionViewModel(NavigationStore navigationStore)
        {
            ButtonCheckConnection = new ConnectionCommand<LoginViewModel>(this,new NavigationService<LoginViewModel>(navigationStore,() => new LoginViewModel(navigationStore)));

        }

    }
}
