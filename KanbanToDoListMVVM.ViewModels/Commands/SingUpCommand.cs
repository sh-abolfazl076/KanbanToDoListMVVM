// System
using System;
using System.Windows;

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
        private SingUpViewModel _ViewModel;
        private NavigationStore _navigationStore;

        public SingUpCommand(SingUpViewModel viewModel , NavigationStore navigationStore)
        {
            _ViewModel = viewModel;
            _navigationStore = navigationStore;

        }

        /// <summary>
        /// Handles the Add/Edit button click:
        /// Validates input and confirms password
        /// If in edit mode, updates the user
        /// If in add mode, creates a new user
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            bool isUsernameAndPasswordValid = Validation.IsUsernameAndPasswordValid(_ViewModel.Username, _ViewModel.Password);
            bool isPasswordConfirmed = Validation.IsPasswordConfirmed(_ViewModel.Password, _ViewModel.PasswordChek);
            if (isUsernameAndPasswordValid && isPasswordConfirmed)
            { 
            
                try
                {
 
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var existingUser = db.UsersRepository.GetUserByUsername(_ViewModel.Username);

                        if (existingUser != null)
                        {
                            MessageBox.Show("A User with this name exists, please choose another.");
                        }
                        else
                        {
                            Users user = new Users()
                            {
                                UserName = _ViewModel.Username,
                                PassWord = _ViewModel.Password,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };

                            db.UsersRepository.AddUser(user);
                            db.Save();

                            //MessageBox.Show("User added successfully.");

                            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);

                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Databse Error");
                }
            }

        }
    }
}
