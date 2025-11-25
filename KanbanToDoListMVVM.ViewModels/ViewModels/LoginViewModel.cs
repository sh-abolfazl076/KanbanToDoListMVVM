// System
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using System.Windows.Input;
using System.Windows.Navigation;



// Internal



namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class LoginViewModel : ViewModelBase
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
        
        public ICommand SubmitConnection { get; }
        public ICommand SubmitSingup { get; }
        public ICommand SubmitLogin { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            SubmitConnection = new NavigateCommand<ConnectionViewModel>(new NavigationService<ConnectionViewModel>(navigationStore, () => new ConnectionViewModel(navigationStore)));
            SubmitSingup = new NavigateCommand<SingUpViewModel>(new NavigationService<SingUpViewModel>(navigationStore, () => new SingUpViewModel(navigationStore)));
            SubmitLogin = new LoginCommand<MainPanleViewModel>(this,new NavigationService<MainPanleViewModel>(navigationStore, () => new MainPanleViewModel(navigationStore)));

        }



    }
}
