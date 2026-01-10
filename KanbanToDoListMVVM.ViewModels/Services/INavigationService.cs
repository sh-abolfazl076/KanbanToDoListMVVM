// System
using KanbanToDoListMVVM.ViewModels.ViewModels;
using System.Windows.Navigation;

namespace KanbanToDoListMVVM.ViewModels.Services
{
    public interface INavigationService<TVeiwModel> where TVeiwModel : ViewModelBase
    {
        void Navigate();
    }
}