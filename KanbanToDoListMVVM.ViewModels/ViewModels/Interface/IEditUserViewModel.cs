// System
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface IEditUserViewModel
    {
        ICommand BackToUserListCommand { get; }
        string CheckPermissionLabal { get; set; }
        string Password { get; set; }
        ICommand SubmitUserEditCommand { get; }
        string TitleUserEdit { get; set; }
        string Username { get; set; }
    }
}