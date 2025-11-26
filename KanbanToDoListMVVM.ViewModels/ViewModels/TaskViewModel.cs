// System

// Internal


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

        public ICommand EditButtom{ get; }
        public ICommand ColseButtom { get; }
        public ICommand RemoveButtom { get; }

        public TaskViewModel()
        {

        }

    }
}
