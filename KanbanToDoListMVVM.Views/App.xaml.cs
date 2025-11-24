// System
using System.Windows;


// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;
using KanbanToDoListMVVM.Views.Properties;
//using KanbanToDoListMVVM.ViewModels.Properties;





namespace KanbanToDoListMVVM.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            

            ApplicationStore.Instance.SetConnectionInfo(
                Settings.Default.ServerNameDatabase,
                Settings.Default.DatabaseName,
                Settings.Default.UsernameDatabase,
                Settings.Default.PasswordDatabase
            );

          

            if (ApplicationStore.Instance.TestConnection())
            {
                navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
                MainWindow = new MainWindow()
                {
                    DataContext = new MainViewModel(navigationStore)
                };
                MainWindow.Show();
                base.OnStartup(e);
            }
            else
            {
                navigationStore.CurrentViewModel = new ConnectionViewModel(navigationStore);
                MainWindow = new MainWindow()
                {
                    DataContext = new MainViewModel(navigationStore)
                };
                MainWindow.Show();
                base.OnStartup(e);
            }

            MessageBox.Show(
                $"Server: '{Settings.Default.ServerNameDatabase}'\n" +
                $"DB: '{Settings.Default.DatabaseName}'\n" +
                $"User: '{Settings.Default.UsernameDatabase}'\n" +
                $"Pass: '{Settings.Default.PasswordDatabase}'"
            );


        }
    }
}
