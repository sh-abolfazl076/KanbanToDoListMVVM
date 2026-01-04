// System
using KanbanToDoListMVVM.Models.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface ICreateTaskViewModel
    {
        ICommand BackToMainPanelCommand { get; }
        string CheckValidationLabal { get; set; }
        string SearchText { get; set; }
        Users SelectedUser { get; set; }
        ICommand SubmitAddTask { get; }
        string TaskDescription { get; set; }
        string TaskDuration { get; set; }
        string TaskTitle { get; set; }
        ObservableCollection<Users> UsersList { get; set; }
    }
}