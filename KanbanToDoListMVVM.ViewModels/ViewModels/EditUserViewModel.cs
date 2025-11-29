// System
using System.Windows.Input;

// Internal
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        private string _titleUserEdit;
        public string TitleUserEdit
        {
            get => _titleUserEdit = "Change User";
            set
            {
                _titleUserEdit = value;
                OnPropertyChanged(nameof(TitleUserEdit));
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
        
        public ICommand SubmitUserEditCommand { get; }
        public ICommand BackToUserListCommand { get; }


        /// <summary>
        /// This creates the EditUserViewModel and sets the buttons for saving changes and going back.
        /// </summary>
        /// <param name="userId">The ID of the user to edit</param>
        /// <param name="navigationStore">change pages in the app</param>
        public EditUserViewModel(int userId, NavigationStore navigationStore)
        {
            BackToUserListCommand = new NavigateCommand<UsersListViewModel>(new NavigationService<UsersListViewModel>(navigationStore, () => new UsersListViewModel(navigationStore)));
            SubmitUserEditCommand = new EditUserCommand(this,userId, navigationStore);
        }//End

    }
}
