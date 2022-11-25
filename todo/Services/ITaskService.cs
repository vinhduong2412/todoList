using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITaskService
    {
        public Task<List<todoTaskDTO>> GetAllTodoTasksAsync();
        public Task<todoTaskDTO> GetTodoTasksAsync(int id);
        public Task<int> AddTodoTaskAsync(todoTaskDTO model);
        public Task UpdateTodoTaskAsync(int id, todoTaskDTO model);
        public Task DeleteTodoTaskAsync(int id);
    }
}
