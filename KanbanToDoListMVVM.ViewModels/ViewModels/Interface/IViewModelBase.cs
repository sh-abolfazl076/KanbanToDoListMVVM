// System
using System.ComponentModel;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public interface IViewModelBase
    {
        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyChanged);
    }
}