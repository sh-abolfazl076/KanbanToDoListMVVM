// System
using System;
using System.Windows;

// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class SingUpCommand: CommandBase
    {
        private SingUpViewModel _ViewModel;

        public SingUpCommand(SingUpViewModel viewModel)
        {
            _ViewModel = viewModel;
            
        }

        public override void Execute(object parameter)
        {
            
            try
            {
                
                using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                {
                    var existingUser = db.UsersRepository.GetUserByUsername(_ViewModel.TxtUsernameSingUp);

                    if (existingUser != null)
                    {
                        MessageBox.Show("A User with this name exists, please choose another.");
                    }
                    else
                    {
                        Users user = new Users()
                        {
                            UserName = _ViewModel.TxtUsernameSingUp,
                            PassWord = _ViewModel.TxtPasswordSingUp,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        };

                        db.UsersRepository.AddUser(user);
                        db.Save();

                        MessageBox.Show("User added successfully.");

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
