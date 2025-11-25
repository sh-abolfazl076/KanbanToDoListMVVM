// System

// Internal
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
        public ICommand ButtonClose{ get; }

        public SingUpViewModel()
        {

        }

    }
}
