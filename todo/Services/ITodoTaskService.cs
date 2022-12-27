using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoTaskService
    {
        Task<List<TodoTaskResponseDTO>> GetTodoTasksAsync(Guid userId, FilterRequestDTO queryParams);
        Task<TodoTaskResponseDTO> GetTodoTasksAsync(Guid userId, int id);
        Task<TodoTaskResponseDTO> AddTodoTaskAsync(Guid userId, TodoTaskRequestDTO model);
        Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(Guid userId, int id, TodoTaskRequestByIdDTO model);
        Task<TodoTaskResponseDTO> DeleteTodoTaskAsync(Guid userId, int id);
        Task CompleteTaskAsync(Guid userId, List<int> id);
    }    
}
