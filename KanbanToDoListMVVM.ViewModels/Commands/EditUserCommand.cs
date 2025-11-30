// System
using System;
using System.Threading.Tasks;


// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;
using KanbanToDoListMVVM.Models.Context;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class EditUserCommand : CommandBase
    {
        private int _userId;
        private EditUserViewModel _viewModel;
        private NavigationStore _navigationStore;

        public EditUserCommand(EditUserViewModel viewModel,int userId, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _userId = userId;
            _navigationStore = navigationStore;
        }

        /// <summary>
        /// This runs when the user clicks the Save button to edit a user.
        /// It checks if the username already exists.
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object parameter)
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                {
                    var edit = db.UsersRepository.GetUserById(_userId);
                    var existingUser = db.UsersRepository.GetUserByUsername(_viewModel.Username);

                    if (existingUser != null)
                    {
                        _viewModel.CheckPermissionLabal = "";
                        await Task.Delay(1000);
                        _viewModel.CheckPermissionLabal = "A User with this name exists, please choose another.";
                    }
                    else
                    {
                        if (edit != null)
                        {
                            edit.UserName = _viewModel.Username;
                            edit.PassWord = _viewModel.Password;
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
                _viewModel.CheckPermissionLabal = "";
                await Task.Delay(1000);
                _viewModel.CheckPermissionLabal = "Databese Error ! .";
            }
        }//End
    }
}