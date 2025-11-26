// System
// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using System.Windows.Input;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        private string _txtTitleTask;
        public string TxtTitleTask
        {
            get
            {
                return _txtTitleTask;
            }
            set
            {
                _txtTitleTask = value;
                OnPropertyChanged(nameof(TxtTitleTask));
            }
        }
        ////
        
        private string _txtInfoTask;
        public string TxtInfoTask
        {
            get
            {
                return _txtInfoTask;
            }
            set
            {
                _txtInfoTask  = value;
                OnPropertyChanged(nameof(TxtInfoTask));
            }
        }
        ////

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }
        ////




        public ICommand EditButtom{ get; }
        public ICommand BackButtom { get; }
        public ICommand RemoveButtom { get; }

        public TaskViewModel(Tasks task ,NavigationStore navigationStore)
        {
            TxtTitleTask = task.Title;
            TxtInfoTask = task.Description;
           
            BackButtom = new NavigateCommand<MainPanleViewModel>(new NavigationService<MainPanleViewModel>(navigationStore, () => new MainPanleViewModel(navigationStore)));
            RemoveButtom = new RemoveTaskCommand(task, navigationStore);
            EditButtom = new EditTaskCommand(task ,this, navigationStore);
        }

    }
}
