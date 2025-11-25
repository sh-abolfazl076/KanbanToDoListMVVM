// System

// Internal
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class SingUpViewModel :ViewModelBase
    {
        private string _txtUsernameSingUp;
        public string TxtUsernameSingUp
        {
            get
            {
                return _txtUsernameSingUp;
            }
            set
            {
                _txtUsernameSingUp = value;
                OnPropertyChanged(nameof(TxtUsernameSingUp));
            }
        }
        ////

        private string _txtPasswordSingUp;
        public string TxtPasswordSingUp
        {
            get
            {
                return _txtPasswordSingUp;
            }
            set
            {
                _txtPasswordSingUp = value;
                OnPropertyChanged(nameof(TxtPasswordSingUp));
            }
        }
        ////

        public ICommand SubmitAddUser{ get; }
        public ICommand ButtonBack{ get; }

        public SingUpViewModel(NavigationStore navigationStore)
        {
            ButtonBack = new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore)));
            SubmitAddUser = new SingUpCommand(this);
        }

    }
}
