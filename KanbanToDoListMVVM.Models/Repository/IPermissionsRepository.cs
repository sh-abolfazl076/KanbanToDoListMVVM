// System


// Internal

namespace KanbanToDoListMVVM.Models.Repository
{
    public interface IPermissionsRepository
    {
        int GetPermissionIdByTitle(string title);
    }
}
