// System
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface ILoginViewModel
    {
        string CheckPermissionLabal { get; set; }
        ICommand ConnectionCommand { get; }
        ICommand LoginCommand { get; }
        string Password { get; set; }
        ICommand SingUpCommand { get; }
        string Title { get; set; }
        string Username { get; set; }
    }
}