// System
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.ViewModels.Commands;
using KanbanToDoListMVVM.ViewModels.Services;

// Internal
using KanbanToDoListMVVM.ViewModels.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;



namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class PermissionUserViewModel : ViewModelBase
    {

        private string _titlePermission;
        public string TitlePermission
        {
            get
            {
                return _titlePermission = "User Permission";
            }
            set
            {
                _titlePermission = value;
                OnPropertyChanged(nameof(TitlePermission));
            }
        }
        ////
        
        private bool _addTask;
        public bool AddTask
        {
            get
            {
                return _addTask;
            }
            set
            {
                _addTask = value;
                OnPropertyChanged(nameof(AddTask));
            }
        }
        ////

        private bool _deleteTask;
        public bool DeleteTask
        {
            get
            {
                return _deleteTask;
            }
            set
            {
                _deleteTask = value;
                OnPropertyChanged(nameof(DeleteTask));
            }
        }
        ////

        private bool _manageUserAccess;
        public bool ManageUserAccess
        {
            get
            {
                return _manageUserAccess;
            }
            set
            {
                _manageUserAccess = value;
                OnPropertyChanged(nameof(ManageUserAccess));
            }
        }
        ////

        private bool _updateTask;
        public bool UpdateTask
        {
            get
            {
                return _updateTask;
            }
            set
            {
                _updateTask = value;
                OnPropertyChanged(nameof(UpdateTask));
            }
        }

        private int _userId;

        ////

        
        public ICommand SubmitPermssionUser { get; }
        public ICommand BackToUserListButtom { get; }

        public PermissionUserViewModel(int userId ,NavigationStore navigationStore)
        {
            _userId = userId;
            SubmitPermssionUser = new PermissionUserCommand(this,userId,navigationStore);
            BackToUserListButtom = new NavigateCommand<UsersListViewModel>(new NavigationService<UsersListViewModel>(navigationStore, () => new UsersListViewModel(navigationStore)));
            LoadUserPermissions();
        }



        /// <summary>
        /// Reads Permissions of User from Database and Sets CheckBox Values
        /// </summary>
        private void LoadUserPermissions()
        {
            var permissionsMap = new Dictionary<string, Action<bool>>
            {
                { "AddTask",v => AddTask = v },
                { "RemoveTask",v => DeleteTask = v },
                { "ModifyTask",v => UpdateTask = v },
                { "AccessUsers",v => ManageUserAccess = v }
            };
            
            try
            {
                using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                {
                    foreach (var permission in permissionsMap)
                    {
                        int permId = db.PermissionsRepository.GetPermissionIdByTitle(permission.Key);
                        var existing = db.UserPermissionsRepository.CheckPermission(_userId, permId);

                        permission.Value(existing != null); 
                    }
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Database Error!");
            }
        }

    }
}
