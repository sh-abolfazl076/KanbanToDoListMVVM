// System
using KanbanToDoListMVVM.ViewModels.ViewModels;
using System;

namespace KanbanToDoListMVVM.ViewModels.Stores
{
    public interface INavigationStore
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;
    }
}