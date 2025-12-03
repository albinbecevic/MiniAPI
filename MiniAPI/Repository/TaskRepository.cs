using MiniAPI.Models;

namespace MiniAPI.Repository
{
    public static class TaskRepository {

        private static readonly List<TaskModel> TaskManagementDB = new();
        private static int NextId = 1;

        public static IEnumerable<TaskModel> GetAllTasks() => TaskManagementDB;

        public static TaskModel? GetTask(int id) {
            return TaskManagementDB.FirstOrDefault(t => t.Id == id);
        }

        public static TaskModel CreateTask(TaskModel task) {
            task.Id = NextId++;
            TaskManagementDB.Add(task);
            return task;
        }

        public static TaskModel? UpdateTask(int id, TaskModel updatedTask) {

            var task = GetTask(id);

            if (task is null) {
                return null;
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;

            return task;
        }

        public static bool DeleteTask(int id) {
            var task = GetTask(id);

            if (task is null) {
                return false;
            }

            TaskManagementDB.Remove(task);
            return true;
        }

        // Used for unit testing.
        public static void Clear() {
            TaskManagementDB.Clear();
            NextId = 1;
        }
    }
}
