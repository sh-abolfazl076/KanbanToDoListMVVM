// System
using KanbanToDoListMVVM.ViewModels.Stores;
using System;
using System.Windows.Input;

// Internal


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class MainPanleViewModel : ViewModelBase
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

        public ICommand ButtomUsersList { get; }
        public ICommand ButtomLogOut { get; }
        public ICommand ButtomCreateTask { get; }

        public MainPanleViewModel(NavigationStore navigationStore) 
        {

        }
    }
}
