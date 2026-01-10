// System
using System.Threading.Tasks;

// Internal
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class ConnectionCommand<TViewModle> : CommandBase where TViewModle : ViewModelBase
    {
        private ConnectionViewModel _viewModel;
        private readonly INavigationService<LoginViewModel> _navigationService;

        /// <summary>
        /// This creates the ConnectionCommand and saves the view model and navigation service.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="navigationService"></param>
        public ConnectionCommand(ConnectionViewModel viewModel, INavigationService<LoginViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }//End


        /// <summary>
        /// This runs when the user clicks the Connect button.
        /// It tests the database connection.
        /// If the connection works, it goes to the next page.
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object parameter)
        {
            string server = _viewModel.ServerName;
            string db = _viewModel.DatabaseName;
            string user = _viewModel.UsernameDatabase;
            string password = _viewModel.PasswordDatabase;
            
            ApplicationStore.Instance.SetConnectionInfo(server, db, user, password);

            if (ApplicationStore.Instance.TestConnection())
            {
                _navigationService.Navigate();          
            }
            else
            {
                _viewModel.CheckConnectionLabal = "";
                await Task.Delay(1000);
                _viewModel.CheckConnectionLabal = "Connection Error !.";
            }

        }//End

    }
}
