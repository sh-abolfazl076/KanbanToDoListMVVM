// System
using System;
using System.Threading.Tasks;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.Utilities;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class SingUpCommand: CommandBase 
    {
        private SingUpViewModel _viewModel;
        private NavigationStore _navigationStore;

        /// <summary>
        /// This creates the SignUp command and saves the view model and navigation store.
        /// </summary>
        /// <param name="viewModel">The SignUp screen data</param>
        /// <param name="navigationStore">change pages in the app</param>
        public SingUpCommand(SingUpViewModel viewModel , NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;

        }//End

        /// <summary>
        /// This runs when the user clicks the Sign Up button.
        /// It checks the username and password.
        /// If everything is OK, it creates a new user.
        /// If something is wrong, it shows a message.
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object parameter)
        {
            bool isUsernameAndPasswordValid = Validation.IsUsernameAndPasswordValid(_viewModel.Username, _viewModel.Password);
            bool isPasswordConfirmed = Validation.IsPasswordConfirmed(_viewModel.Password, _viewModel.PasswordChek);

            if (isUsernameAndPasswordValid && isPasswordConfirmed)
            {           
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var existingUser = db.UsersRepository.GetUserByUsername(_viewModel.Username);

                        if (existingUser != null)
                        {
                            _viewModel.CheckPermissionLabal = "";
                            await Task.Delay(1000);
                            _viewModel.CheckPermissionLabal = "A User with this name exists, please choose another.";
                        }
                        else
                        {
                            Users user = new Users()
                            {
                                UserName = _viewModel.Username,
                                PassWord = _viewModel.Password,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };

                            db.UsersRepository.AddUser(user);
                            db.Save();

                            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);

                        }
                    }
                }
                catch
                {
                    _viewModel.CheckPermissionLabal = "";
                    await Task.Delay(1000);
                    _viewModel.CheckPermissionLabal = "Databes Error !.";
                }
            }
            else
            {
                _viewModel.CheckPermissionLabal = "";
                await Task.Delay(1000);
                _viewModel.CheckPermissionLabal = "This field is invalid";
            }

        }//End

    }
}
