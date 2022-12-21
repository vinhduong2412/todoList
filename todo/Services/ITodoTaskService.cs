using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoTaskService
    {
        public Task<List<TodoTask>> GetTodoTasksAsync(string UserId, FilterRequestDTO model);
        public Task<TodoTaskResponseDTO> GetTodoTasksAsync(string UserId, int id);
        public Task<TodoTaskResponseDTO> AddTodoTaskAsync(string UserId, TodoTaskRequestDTO model);
        public Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(string UserId, int id, TodoTaskRequestByIdDTO model);
        public Task DeleteTodoTaskAsync(string UserId, int id);
        public Task CompleteTaskAsync(string UserId, List<int> id);
    }    
}
