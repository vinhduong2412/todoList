using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoTaskService
    {
        public Task<List<TodoTaskDTO>> GetAllTodoTasksAsync();
        public Task<TodoTaskDTO> GetTodoTasksAsync(int id);
        public Task<TodoTaskDTO> AddTodoTaskAsync(TodoTaskDTO model);
        public Task<TodoTaskDTO> UpdateTodoTaskAsync(int id,TodoTask model);
        public Task DeleteTodoTaskAsync(int id);
        public Task<List<TodoTask>> GetTasksByStatusAsync(bool Status);
        public Task<List<TodoTask>> GetTasksByDateAsync(DateTime Date);
        public Task CompleteTaskAsync(List<int> id);
    }
}
