// System
using System.Windows.Input;


// Internal


namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class CreateTaskViewModel : ViewModelBase
    {
        private string _txtTitleAddTask;
        public string TxtTitleAddTask
        {
            get
            {
                return _txtTitleAddTask;
            }
            set
            {
                _txtTitleAddTask = value;
                OnPropertyChanged(nameof(TxtTitleAddTask));
            }
        }
        ////

        private string _txtDurationAddTask;
        public string TxtDurationAddTask
        {
            get
            {
                return _txtDurationAddTask;
            }
            set
            {
                _txtDurationAddTask = value;
                OnPropertyChanged(nameof(TxtDurationAddTask));
            }
        }
        ////

        private string _txtInfoAddTask;
        public string TxtInfoAddTask
        {
            get
            {
                return _txtInfoAddTask;
            }
            set
            {
                _txtInfoAddTask = value;
                OnPropertyChanged(nameof(TxtInfoAddTask));
            }
        }
        ////

        public ICommand SubmitAddTask { get; }


        public CreateTaskViewModel()
        {

        }

    }
}
