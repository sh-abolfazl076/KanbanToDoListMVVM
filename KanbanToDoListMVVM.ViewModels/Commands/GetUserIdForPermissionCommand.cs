// System

// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;




namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class GetUserIdForPermissionCommand : CommandBase
    {
        private UsersListViewModel _viewModel;
        private readonly NavigationStore _navigationStore;

        public GetUserIdForPermissionCommand(UsersListViewModel user, NavigationStore navigationStore)
        {
            _viewModel = user;
            _navigationStore = navigationStore;
        }



        public override void Execute(object parameter)
        {
            if (parameter is Users user)
            {
                _navigationStore.CurrentViewModel = new PermissionUserViewModel(user.ID, _navigationStore);

            }
        }
    }
}
