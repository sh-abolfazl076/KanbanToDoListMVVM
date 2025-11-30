// System
using System;
using System.Collections.Generic;

// Internal
using KanbanToDoListMVVM.Models.Context;
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.ViewModels.Stores;
using KanbanToDoListMVVM.ViewModels.ViewModels;


namespace KanbanToDoListMVVM.ViewModels.Commands
{
    public class PermissionUserCommand : CommandBase
    {
        private int _userId;
        private PermissionUserViewModel _viewModel;
        private NavigationStore _navigationStore;

        public PermissionUserCommand(PermissionUserViewModel viewModel, int userId, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _userId = userId;
            _navigationStore = navigationStore;
        }//End


        /// <summary>
        /// This runs when the user clicks the Save Permissions button
        /// It checks every permission (Add, Delete, Update, Manage Users)
        /// If a permission is checked and not in the database, it adds it
        /// If a permission is unchecked and exists in the database, it removes it.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            var permissions = new List<(bool IsChecked, string Permission)>
            {
                (_viewModel.AddTask, "AddTask"),
                (_viewModel.DeleteTask, "RemoveTask"),
                (_viewModel.ManageUserAccess, "AccessUsers"),
                (_viewModel.UpdateTask, "ModifyTask"),
            };

            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                foreach (var (isChecked, permissionName) in permissions)
                {
                    int permissionId = db.PermissionsRepository.GetPermissionIdByTitle(permissionName);
                    var existing = db.UserPermissionsRepository.CheckPermission(_userId, permissionId);

                    if (isChecked)
                    {
                        if (existing == null)
                        {
                            UserPermissions access = new UserPermissions
                            {
                                UserId = _userId,
                                PermissionId = permissionId,
                                CreatedAt = DateTime.Now
                            };

                            db.UserPermissionsRepository.AddUserPermission(access);
                            db.Save();

                        }
                    }
                    else 
                    {
                        if (existing != null)
                        {
                            db.UserPermissionsRepository.RemoveUserPermission(existing.ID);
                            db.Save();
                        }
                    }
                    _navigationStore.CurrentViewModel = new UsersListViewModel(_navigationStore);

                }
            }
    
        }//End
    }
}
