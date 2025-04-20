using TaskManager.Api.Models;

namespace TaskManager.Api.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetTasksAsync(string username, string role);
        Task<TaskItem?> GetTaskAsync(int id);
        Task CreateTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
    }
}