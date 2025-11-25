// System
using System.Linq;


// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.Models.Repository;


namespace KanbanToDoListMVVM.Models.Services
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private KanbanToDoListMVVMEntities db;
        public PermissionsRepository(KanbanToDoListMVVMEntities context)
        {
            db = context;
        }
        public int GetPermissionIdByTitle(string title)
        {
            return db.Permissions.Where(t => t.Title == title).Select(t => t.ID).FirstOrDefault();
        }
    }
}
