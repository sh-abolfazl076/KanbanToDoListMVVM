// System
using Autofac;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


// Internal



namespace KanbanToDoListMVVM.ViewModels.Configuration
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NavigationStore>().As<INavigationStore>().SingleInstance();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();
            builder.RegisterType<ConnectionViewModel>().As<IConnectionViewModel>();
            builder.RegisterType<PermissionUserViewModel>().As<IPermissionUserViewModel>();
            builder.RegisterType<EditUserViewModel>().As<IEditUserViewModel>();
            builder.RegisterType<SingUpViewModel>().As<ISingUpViewModel>();
            builder.RegisterType<TaskViewModel>().As<ITaskViewModel>();


            return builder.Build();
        }
    }
}
