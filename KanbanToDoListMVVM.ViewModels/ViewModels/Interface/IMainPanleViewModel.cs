// System
using KanbanToDoListMVVM.Models.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface IMainPanleViewModel
    {
        ObservableCollection<Tasks> CancelledTasks { get; set; }
        ICommand CreateTaskCommand { get; }
        ObservableCollection<Tasks> DoingTasks { get; set; }
        ObservableCollection<Tasks> DoneTasks { get; set; }
        ICommand LogOutCommand { get; }
        ObservableCollection<Tasks> ReviewTasks { get; set; }
        ICommand TaskCommand { get; }
        ObservableCollection<Tasks> ToDoTasks { get; set; }
        ICommand UsersListCommand { get; }

        void ReloadTasks();
    }
}