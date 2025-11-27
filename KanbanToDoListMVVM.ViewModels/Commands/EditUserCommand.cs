using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
// System

using KanbanToDoListMVVM.ViewModels.ViewModels;
using System;

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

        public override void Execute(object parameter)
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                {


                    var edit = db.UsersRepository.GetUserById(_userId);
                    var existingUser = db.UsersRepository.GetUserByUsername(_ViewModel.TxtUsernameEdit);

                    if (existingUser != null)
                    {
                        MessageBox.Show("A User with this name exists, please choose another.");
                    }
                    else
                    {
                        if (edit != null)
                        {
                            edit.UserName = _ViewModel.TxtUsernameEdit;
                            edit.PassWord = _ViewModel.TxtPasswordEdit;
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
                MessageBox.Show("ِDatabese Error !");
            }
        }
    }
}