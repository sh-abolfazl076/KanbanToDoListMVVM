// System
using System.Linq;

// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.Models.Repository;

namespace KanbanToDoListMVVM.Models.Services
{
    public class UserPermissionsRepository : IUserPermissionsRepository
    {
        private KanbanToDoListMVVMEntities db;
        public UserPermissionsRepository(KanbanToDoListMVVMEntities context)
        {
            db = context;
        }
        public bool AddUserPermission(UserPermissions userPermission)
        {
            try
            {
                db.UserPermissions.Add(userPermission);
                return true;
            }
            catch
            {

                return false;
            }
        }
        public UserPermissions CheckPermission(int userId, int permissionId)
        {
            return db.UserPermissions.FirstOrDefault(p => p.UserId == userId && p.PermissionId == permissionId);
        }
        public UserPermissions GetUserPermissionById(int permissionId)
        {
            return db.UserPermissions.Find(permissionId);
        }
        public bool RemoveUserPermission(int permissionId)
        {
            try
            {
                var permission = GetUserPermissionById(permissionId);
                if (permission != null)
                {
                    db.UserPermissions.Remove(permission);
                    return true;
                }
                return false;
            }
            catch
            {

                return false;
            }
        }
        public bool RemoveUserPermissionByUserId(int userId)
        {
            try
            {
                var permission = db.UserPermissions.Where(p => p.UserId == userId).ToList();

                if (permission.Any())
                {
                    db.UserPermissions.RemoveRange(permission);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
