// System
using System.Windows.Input;

// Internal
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;



namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        
        private string _title;
        public string Title
        {
            get => _title = "Welcome !";
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        ////
        
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        ////
       
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        ////
        
        public ICommand ConnectionCommand { get; }
        public ICommand SingUpCommand { get; }
        public ICommand LoginCommand { get; }


        /// <summary>
        /// This creates the LoginViewModel and sets the commands for navigation and login.
        /// </summary>
        /// <param name="navigationStore">switch between pages</param>
        public LoginViewModel(NavigationStore navigationStore)
        {
            ConnectionCommand = new NavigateCommand<ConnectionViewModel>
                (new NavigationService<ConnectionViewModel>(navigationStore, () => new ConnectionViewModel(navigationStore)));

            SingUpCommand = new NavigateCommand<SingUpViewModel>(
                new NavigationService<SingUpViewModel>(navigationStore, () => new SingUpViewModel(navigationStore)));

            LoginCommand = new LoginCommand<MainPanleViewModel>(this,
                new NavigationService<MainPanleViewModel>(navigationStore, () => new MainPanleViewModel(navigationStore)));
        }//End

    }
}
