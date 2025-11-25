// System
using KanbanToDoListMVVM.Models.Models;
using System.Collections.Generic;


// Internal
using Task = KanbanToDoListMVVM.Models.Models.Tasks;

namespace KanbanToDoListMVVM.Models.Repository
{
    public interface ITasksRepository
    {
        bool AddTask(Tasks task);
        IEnumerable<Tasks> GetAllTasksByUserIdAndStageId(int userId, int stageId);
        Tasks GetTaskById(int taskId);
        bool UpdateTask(Tasks task);
        bool RemoveTaskById(int taskId);
    }
}
