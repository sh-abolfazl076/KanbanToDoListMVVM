// System



// Internal
using KanbanToDoListMVVM.Models.Models;



namespace KanbanToDoListMVVM.Models.Repository
{
    public interface IUserPermissionsRepository
    {
        bool AddUserPermission(UserPermissions userPermission);
        UserPermissions CheckPermission(int userId, int permissionId);
        UserPermissions GetUserPermissionById(int permissionId);
        bool RemoveUserPermission(int permissionId);
        bool RemoveUserPermissionByUserId(int userId);
    }
}
