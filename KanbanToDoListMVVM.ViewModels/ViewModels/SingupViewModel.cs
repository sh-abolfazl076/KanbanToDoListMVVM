// System
using System.Windows.Input;

// Internal
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class SingUpViewModel : ViewModelBase, ISingUpViewModel
    {
        private string _title;
        public string Title
        {
            get => _title = "Sing Up !";
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
        private string _passwordChek;
        public string PasswordChek
        {
            get => _passwordChek;
            set
            {
                _passwordChek = value;
                OnPropertyChanged(nameof(PasswordChek));
            }
        }
        //// 

        private string _checkPermissionLabal;
        public string CheckPermissionLabal
        {
            get => _checkPermissionLabal;
            set
            {
                _checkPermissionLabal = value;
                OnPropertyChanged(nameof(CheckPermissionLabal));
            }
        }
        ////
        public ICommand SubmitAddUserCommand { get; }
        public ICommand BackToLoginCommand { get; }


        /// <summary>
        /// Initializes the SignUpViewModel and sets up navigation and submit commands.
        /// </summary>
        /// <param name="navigationStore">Handles view navigation</param>
        public SingUpViewModel(NavigationStore navigationStore)
        {
            BackToLoginCommand = new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore)));
            SubmitAddUserCommand = new SingUpCommand(this, navigationStore);
        }//End

    }
}
