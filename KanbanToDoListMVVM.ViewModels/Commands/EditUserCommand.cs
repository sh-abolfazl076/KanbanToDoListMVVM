using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
// System

using KanbanToDoListMVVM.ViewModels.ViewModels;
using System;
using System.Threading.Tasks;


// Internal

using System.Windows;

namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class EditUserCommand : CommandBase
    {
        private EditUserViewModel _ViewModel;
        private int _userId;
        private NavigationStore _navigationStore;

        public EditUserCommand(EditUserViewModel viewModel,int userId, NavigationStore navigationStore)
        {
            _ViewModel = viewModel;
            _userId = userId;
            _navigationStore = navigationStore;
        }

        public override async void Execute(object parameter)
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                {


                    var edit = db.UsersRepository.GetUserById(_userId);
                    var existingUser = db.UsersRepository.GetUserByUsername(_ViewModel.Username);

                    if (existingUser != null)
                    {
                        _ViewModel.CheckPermissionLabal = "";
                        await Task.Delay(1000);
                        _ViewModel.CheckPermissionLabal = "A User with this name exists, please choose another.";
                    }
                    else
                    {
                        if (edit != null)
                        {
                            edit.UserName = _ViewModel.Username;
                            edit.PassWord = _ViewModel.Password;
                            edit.UpdatedAt = DateTime.Now;


                            db.UsersRepository.UpdataUser(edit);
                            db.Save();

                            _navigationStore.CurrentViewModel = new UsersListViewModel(_navigationStore);
                        }
                    }
                }
            }
            catch
            {
                _ViewModel.CheckPermissionLabal = "";
                await Task.Delay(1000);
                _ViewModel.CheckPermissionLabal = "Databese Error ! .";
            }
        }
    }
}