// System
using System.Windows.Input;



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

        public LoginViewModel()
        {

        }



    }
}
