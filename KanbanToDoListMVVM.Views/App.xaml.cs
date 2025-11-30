// System
using System.Windows;


// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


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

            var store = ApplicationStore.Instance;
            store.LoadFromFile(); 


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

        }//End
    }
}
