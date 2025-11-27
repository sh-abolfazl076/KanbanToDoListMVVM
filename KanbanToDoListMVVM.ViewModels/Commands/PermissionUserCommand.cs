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
        private PermissionUserViewModel _viewModel;
        private int _userId;
        private NavigationStore _navigationStore;

        public PermissionUserCommand(PermissionUserViewModel viewModel, int userId, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _userId = userId;
            _navigationStore = navigationStore;
        }

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

            
        }
    }
}
