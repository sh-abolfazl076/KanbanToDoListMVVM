// System
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface IConnectionViewModel
    {
        ICommand CheckConnectionCommand { get; }
        string CheckConnectionLabal { get; set; }
        string DatabaseName { get; set; }
        string PasswordDatabase { get; set; }
        string ServerName { get; set; }
        string Title { get; set; }
        string UsernameDatabase { get; set; }
    }
}