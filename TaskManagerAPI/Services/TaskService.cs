using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetTasksAsync(string username, string role)
        {
            var tasks = await _repository.GetAllAsync();
            return role == "Admin" ? tasks : tasks.Where(t => t.AssignedTo == username).ToList();
        }

        public Task<TaskItem?> GetTaskAsync(int id) => _repository.GetByIdAsync(id);
        public Task CreateTaskAsync(TaskItem task) => _repository.AddAsync(task);
        public Task UpdateTaskAsync(TaskItem task) => _repository.UpdateAsync(task);
        public Task DeleteTaskAsync(int id) => _repository.DeleteAsync(id);
    }
}