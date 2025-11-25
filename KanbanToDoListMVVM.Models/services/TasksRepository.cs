// System
using System.Collections.Generic;
using System.Linq;

// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.Models.Repository;



namespace KanbanToDoListMVVM.Models.Services
{
    public class TasksRepository : ITasksRepository
    {
        private KanbanToDoListMVVMEntities db;

        public TasksRepository(KanbanToDoListMVVMEntities contect)
        {
            db = contect;
        }

        public bool AddTask(Tasks task)
        {
            try
            {
                db.Tasks.Add(task);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<Tasks> GetAllTasksByUserIdAndStageId(int userId, int stageId)
        {
            return db.Tasks.Where(t => t.UserId == userId && t.StageId == stageId);
        }

        public Tasks GetTaskById(int taskId)
        {
            return db.Tasks.Find(taskId);
        }

        public bool RemoveTaskById(int taskId)
        {
            var task = db.Tasks.Find(taskId);
            try
            {
                db.Tasks.Remove(task);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateTask(Tasks task)
        {
            try
            {
                db.Entry(task).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
