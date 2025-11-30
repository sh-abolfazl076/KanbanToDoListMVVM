// System
using System.Threading.Tasks;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.Utilities;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class LoginCommand<TViewModle> : CommandBase where TViewModle : ViewModelBase
    {
        private LoginViewModel _viewModel;
        private readonly NavigationService<TViewModle> _navigationService;

        /// <summary>
        /// This creates the LoginCommand and saves the view model and navigation service.
        /// </summary>
        /// <param name="viewModel">The login screen data</param>
        /// <param name="navigationService">change pages in the app</param>
        public LoginCommand(LoginViewModel viewModel, NavigationService<TViewModle> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }//End


        /// <summary>
        /// This runs when the user clicks the Login button.
        /// It checks the username and password.
        /// If the user exists, it logs in and goes to the next page.
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object parameter)
        {
            bool isUsernameAndPasswordValid = Validation.IsUsernameAndPasswordValid(_viewModel.Username, _viewModel.Password);
            if (isUsernameAndPasswordValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var existingUser = db.UsersRepository.GetUserByUsernameAndPassword(_viewModel.Username, _viewModel.Password);

                        if (existingUser == null)
                        {
                            _viewModel.CheckPermissionLabal = "";
                            await Task.Delay(1000);
                            _viewModel.CheckPermissionLabal = "User is not existion.";
                        }
                        else
                        {
                            ApplicationStore.Instance.Username = existingUser.UserName;
                            ApplicationStore.Instance.UserId = existingUser.ID;

                            _navigationService.Navigate();

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
