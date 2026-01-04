// System
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface IPermissionUserViewModel
    {
        bool AddTask { get; set; }
        ICommand BackToUserListCommand { get; }
        bool DeleteTask { get; set; }
        bool ManageUserAccess { get; set; }
        ICommand SubmitPermssionUserCommand { get; }
        string TitlePermission { get; set; }
        bool UpdateTask { get; set; }
    }
}