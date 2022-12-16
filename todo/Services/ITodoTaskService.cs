using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoTaskService
    {
        public Task<List<TodoTaskResponseDTO>> GetAllTodoTasksAsync();
        public Task<TodoTaskResponseDTO> GetTodoTasksAsync(int id);
        public Task<TodoTaskResponseDTO> AddTodoTaskAsync(TodoTaskRequestDTO model);
        public Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(int id,TodoTaskRequestByIdDTO model);
        public Task DeleteTodoTaskAsync(int id);
        public Task<List<TodoTaskResponseDTO>> GetTasksByStatusAsync(bool Status);
        public Task<List<TodoTaskResponseDTO>> GetTasksByDateAsync(DateTime Date);
        public Task CompleteTaskAsync(List<int> id);
    }
}
