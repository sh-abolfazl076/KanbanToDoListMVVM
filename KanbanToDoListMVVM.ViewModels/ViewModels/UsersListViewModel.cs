// System
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Stores;



namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class UsersListViewModel : ViewModelBase
    {  

        public ObservableCollection<Users> UsersList { get; set; } = new ObservableCollection<Users>();
        public ObservableCollection<Users> PermissionsUserList { get; set; } = new ObservableCollection<Users>();
        public ObservableCollection<Users> EditUserList { get; set; } = new ObservableCollection<Users>();
        public ObservableCollection<Users> RemoveUserList { get; set; } = new ObservableCollection<Users>();



        public ICommand SubmitAddUser { get; }
        public ICommand UserRemove { get; }
        public ICommand UserEdit{ get; }

        public UsersListViewModel(NavigationStore navigationStore)
        {
            LoadData();
            UserRemove = new UserRemoveCommand(this,navigationStore);
            UserEdit = new UserCommand(this, navigationStore);



        }


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
        }

    }
}
