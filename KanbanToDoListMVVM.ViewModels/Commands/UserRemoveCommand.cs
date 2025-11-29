// System
// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class UserRemoveCommand : CommandBase
    {
        private UsersListViewModel _ViewModel;
        private NavigationStore _navigationStore;

        public UserRemoveCommand(UsersListViewModel viewModel, NavigationStore navigationStore)
        {
            _ViewModel = viewModel;
            _navigationStore = navigationStore;
        }
        public override async void Execute(object parameter)
        {
            if (parameter is Users user)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        db.UserPermissionsRepository.RemoveUserPermissionByUserId(user.ID);
                        db.UsersRepository.RemoveUserById(user.ID);
                        db.Save();
                        _navigationStore.CurrentViewModel = new UsersListViewModel(_navigationStore);
                    }
                }
                catch
                {
                    _ViewModel.RemoveUserLabal = "";
                    await Task.Delay(1000);
                    _ViewModel.RemoveUserLabal = "The user has a record and cannot be deleted ..";

                }
            }
        }
    }
}
