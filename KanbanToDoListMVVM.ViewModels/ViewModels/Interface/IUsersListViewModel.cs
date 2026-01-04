// System
using KanbanToDoListMVVM.Models.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface IUsersListViewModel
    {
        ICommand BackToMainPanleCommand { get; }
        ObservableCollection<Users> EditUserList { get; set; }
        ICommand PermissionCommand { get; }
        ObservableCollection<Users> PermissionsUserList { get; set; }
        string RemoveUserLabal { get; set; }
        ObservableCollection<Users> RemoveUserList { get; set; }
        ICommand UserEditCommand { get; }
        ICommand UserRemoveCommand { get; }
        ObservableCollection<Users> UsersList { get; set; }
    }
}