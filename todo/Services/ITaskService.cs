using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITaskService
    {
        public Task<List<todoTaskDTO>> GetAllTodoTasksAsync();
        public Task<todoTaskDTO> GetTodoTasksAsync(int id);
        public Task<int> AddTodoTaskAsync(todoTask model);
        public Task UpdateTodoTaskAsync(int id, todoTask model);
        public Task DeleteTodoTaskAsync(int id);
    }
}
