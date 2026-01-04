// System
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface ISingUpViewModel
    {
        ICommand BackToLoginCommand { get; }
        string CheckPermissionLabal { get; set; }
        string Password { get; set; }
        string PasswordChek { get; set; }
        ICommand SubmitAddUserCommand { get; }
        string Title { get; set; }
        string Username { get; set; }
    }
}