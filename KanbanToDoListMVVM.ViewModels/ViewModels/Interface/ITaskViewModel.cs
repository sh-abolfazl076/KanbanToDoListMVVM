// System
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface ITaskViewModel
    {
        ICommand BackToMainPanleCommand { get; }
        ICommand RemoveTaskCommand { get; }
        int SelectedIndex { get; set; }
        ICommand SubmitEditTaskCommand { get; }
        string TaskDescription { get; set; }
        string TaskTitle { get; set; }
    }
}