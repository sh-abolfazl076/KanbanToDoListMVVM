// System
using System.Windows.Input;

// Internal
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class ConnectionViewModel :ViewModelBase
    {
        private string _title;
        public string Title
        {
            get => _title = "Database Connection";
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        ////
        
        private string _serverName = ".\\Moein2019";
        public string ServerName
        {
            get => _serverName ;
            set
            {
                _serverName = value;
                OnPropertyChanged(nameof(ServerName));
            }
        }
        ////

        private string _databaseName = "KanbanToDoListWPF";
        public string DatabaseName
        {
            get => _databaseName;
            set
            {
                _databaseName = value;
                OnPropertyChanged(nameof(DatabaseName));
            }
        }
        ////
        
        private string _usernameDatabase = "sa";
        public string UsernameDatabase
        {
            get => _usernameDatabase;
            set
            {
                _usernameDatabase = value;
                OnPropertyChanged(nameof(UsernameDatabase));
            }
        }
        ////

        private string _passwordDatabase = "arta0@";
        public string PasswordDatabase
        {
            get => _passwordDatabase;
            set
            {
                _passwordDatabase = value;
                OnPropertyChanged(nameof(PasswordDatabase));
            }
        }
        ////

        private string _CheckConnectionLabal;
        public string CheckConnectionLabal
        {
            get => _CheckConnectionLabal;
            set
            {
                _CheckConnectionLabal = value;
                OnPropertyChanged(nameof(CheckConnectionLabal));
            }
        }
        ////

        public ICommand CheckConnectionCommand {  get;}


        /// <summary>
        /// his sets the connection command for the ConnectionViewModel.
        /// </summary>
        /// <param name="navigationStore"></param>
        public ConnectionViewModel(NavigationStore navigationStore)
        {
            CheckConnectionCommand = new ConnectionCommand<LoginViewModel>(this,
                new NavigationService<LoginViewModel>(navigationStore,() => new LoginViewModel(navigationStore)));
        }//End

    }
}
