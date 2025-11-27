using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public override void Execute(object parameter)
        {
            if (parameter is Users user)
            {
                MessageBox.Show($"{user.ID}");
                //_navigationStore.CurrentViewModel = new TaskViewModel(task, _navigationStore);
            }
        }
    }
}
