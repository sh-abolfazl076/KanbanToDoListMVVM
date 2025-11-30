// System
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;
using KanbanToDoListMVVM.ViewModels.Stores;



namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class UsersListViewModel : ViewModelBase
    {
        
        private string _removeUserLabal;
        public string RemoveUserLabal
        {
            get => _removeUserLabal;
            set
            {
                _removeUserLabal = value;
                OnPropertyChanged(nameof(RemoveUserLabal));
            }
        }
        ////
        public ObservableCollection<Users> UsersList { get; set; } = new ObservableCollection<Users>();
        public ObservableCollection<Users> PermissionsUserList { get; set; } = new ObservableCollection<Users>();
        public ObservableCollection<Users> EditUserList { get; set; } = new ObservableCollection<Users>();
        public ObservableCollection<Users> RemoveUserList { get; set; } = new ObservableCollection<Users>();


        public ICommand BackToMainPanleCommand { get; }
        public ICommand UserEditCommand { get; }
        public ICommand PermissionCommand { get; }
        public ICommand UserRemoveCommand { get; }


        /// <summary>
        /// This creates the UsersListViewModel and sets the buttons for remove, edit, permissions, and back.
        /// </summary>
        /// <param name="navigationStore">change pages in the app</param>
        public UsersListViewModel(NavigationStore navigationStore)
        {
            LoadData();
            UserRemoveCommand = new UserRemoveCommand(this,navigationStore);
            UserEditCommand = new GetUserIdForEditUserCommand(this, navigationStore);
            PermissionCommand = new GetUserIdForPermissionCommand(this, navigationStore);
            BackToMainPanleCommand = new NavigateCommand<MainPanleViewModel>(new NavigationService<MainPanleViewModel>(navigationStore, () => new MainPanleViewModel(navigationStore)));


        }//End

        /// <summary>
        /// This loads all users from the database
        /// </summary>
        private void LoadData()
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                var getUsers = db.UsersRepository.GetAllUsers().ToList();

                UsersList.Clear();
                PermissionsUserList.Clear();
                EditUserList.Clear();
                RemoveUserList.Clear();

                foreach (var user in getUsers)
                {
                    
                    UsersList.Add(new Users
                    {
                        ID = user.ID,
                        Title = user.UserName
                    });

                    PermissionsUserList.Add(new Users
                    {
                        ID = user.ID,
                        UserName = user.UserName,
                        Title = "Permissions"
                    });

                    EditUserList.Add(new Users
                    {
                        ID = user.ID,
                        UserName = user.UserName,
                        Title = "Edit"
                    });


                    RemoveUserList.Add(new Users
                    {
                        ID = user.ID,
                        UserName = user.UserName,
                        Title = "Remove"
                    });
                }
            }
        }//End

    }
}
