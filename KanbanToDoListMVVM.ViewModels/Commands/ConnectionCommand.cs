// System
using System.Windows;

// Internal
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;





namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class ConnectionCommand<TViewModle> : CommandBase where TViewModle : ViewModelBase
    {
        private ConnectionViewModel _ViewModel;
        private readonly NavigationService<TViewModle> _navigationService;

        public ConnectionCommand(ConnectionViewModel viewModel, NavigationService<TViewModle> navigationService)
        {
            _ViewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string server = _ViewModel.ServerNameDatabase;
            string db = _ViewModel.DatabaseName;
            string user = _ViewModel.UsernameDatabase;
            string password = _ViewModel.PasswordDatabase;

            
            ApplicationStore.Instance.SetConnectionInfo(server, db, user, password);


            if (ApplicationStore.Instance.TestConnection())
            {
                _navigationService.Navigate();          
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }

        }

    }
}
