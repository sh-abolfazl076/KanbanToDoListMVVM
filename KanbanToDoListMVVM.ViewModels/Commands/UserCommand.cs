// System

// Internal

using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;
using System.Windows;

namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class UserCommand : CommandBase
    {

        private readonly NavigationStore _navigationStore;
        private UsersListViewModel _viewModel;


        public UserCommand(UsersListViewModel user, NavigationStore navigationStore)
        {
            _viewModel = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Users user)
            {
                _navigationStore.CurrentViewModel = new EditUserViewModel(user.ID, _navigationStore);
                
            }
        }
    }
}
