// System

// Internal


using KanbanToDoListMVVM.ViewModels.Stores;
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        private string _txtTitleUserEdit;
        public string TxtTitleUserEdit
        {
            get
            {
                return _txtTitleUserEdit = "hjhh";
            }
            set
            {
                _txtTitleUserEdit = value;
                OnPropertyChanged(nameof(TxtTitleUserEdit));
            }
        }
        ////

        private string _txtUsernameEdit;
        public string TxtUsernameEdit
        {
            get
            {
                return _txtUsernameEdit;
            }
            set
            {
                _txtUsernameEdit = value;
                OnPropertyChanged(nameof(TxtUsernameEdit));
            }
        }
        ////

        private string _txtPasswordEdit;
        public string TxtPasswordEdit
        {
            get
            {
                return _txtPasswordEdit;
            }
            set
            {
                _txtPasswordEdit = value;
                OnPropertyChanged(nameof(TxtPasswordEdit));
            }
        }
        ////
        
        public ICommand SubmitUserEdit { get; }




        public EditUserViewModel(UsersListViewModel viewModel, NavigationStore navigationStore)
        {
            SubmitUserEdit = new EditUserCommand(viewModel , navigationStore)
        }

    }
}
