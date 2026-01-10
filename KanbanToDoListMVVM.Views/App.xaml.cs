// System
using Autofac;
using System.Windows;


// Internal
using KanbanToDoListMVVM.ViewModels.Configuration;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.Views
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IContainer _container;

        /// <summary>
        /// Constructor for the App class.
        /// Initializes the Autofac container and resolves necessary dependencies.
        /// </summary>
        public App()
        {
            _container = ContainerConfig.Configure();
        }//End

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var store = ApplicationStore.Instance;
            store.LoadFromFile();

            var navigationStore = _container.Resolve<INavigationStore>();
            var mainViewModel = _container.Resolve<IMainViewModel>();

            if (ApplicationStore.Instance.TestConnection())
            {

                navigationStore.CurrentViewModel = (ViewModelBase)_container.Resolve<ILoginViewModel>();
                MainWindow = new MainWindow()
                {
                    DataContext = mainViewModel
                };
                MainWindow.Show();
                base.OnStartup(e);
            }
            else
            {
                navigationStore.CurrentViewModel = (ViewModelBase)_container.Resolve<ConnectionViewModel>();
                MainWindow = new MainWindow()
                {
                    DataContext = mainViewModel
                };
                MainWindow.Show();
                base.OnStartup(e);
            }

        }//End
    }
}
