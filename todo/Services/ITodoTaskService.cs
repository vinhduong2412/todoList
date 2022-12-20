using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoTaskService
    {
        public Task<List<TodoTask>> GetTodoTasksAsync(int UserId, FilterRequestDTO model);
        public Task<TodoTaskResponseDTO> GetTodoTasksAsync(int UserId, int id);
        public Task<TodoTaskResponseDTO> AddTodoTaskAsync(int UserId, TodoTaskRequestDTO model);
        public Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(int UserId, int id, TodoTaskRequestByIdDTO model);
        public Task DeleteTodoTaskAsync(int UserId, int id);
        public Task CompleteTaskAsync(int UserId, List<int> id);
    }    
}
