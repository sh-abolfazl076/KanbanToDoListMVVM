// System
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.Utilities;
using KanbanToDoListMVVM.ViewModels.ViewModels;
using System;
using System.Runtime.Remoting.Contexts;
using System.Windows;


// Internal

namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class LoginCommand<TViewModle> : CommandBase where TViewModle : ViewModelBase
    {
        private LoginViewModel _ViewModel;
        private readonly NavigationService<TViewModle> _navigationService;

        public LoginCommand(LoginViewModel viewModel, NavigationService<TViewModle> navigationService)
        {
            _ViewModel = viewModel;
            _navigationService = navigationService;
        }


        public override void Execute(object parameter)
        {
            bool isUsernameAndPasswordValid = Validation.IsUsernameAndPasswordValid(_ViewModel.TxtUsername, _ViewModel.TxtPassword);
            if (isUsernameAndPasswordValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var existingUser = db.UsersRepository.GetUserByUsernameAndPassword(_ViewModel.TxtUsername, _ViewModel.TxtPassword);

                        if (existingUser == null)
                        {
                            MessageBox.Show("User is not existion");
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
                    MessageBox.Show("ِDatabes Error");
                }
            }
        }
    }
}
