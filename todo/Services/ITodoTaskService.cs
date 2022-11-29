using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoTaskService
    {
        public Task<List<todoTaskDTO>> GetAllTodoTasksAsync();
        public Task<todoTaskDTO> GetTodoTasksAsync(int id);
        public Task<todoTaskDTO> AddTodoTaskAsync(todoTask model);
        public Task<todoTaskDTO> UpdateTodoTaskAsync(int id,todoTask model);
        public Task DeleteTodoTaskAsync(int id);
    }
}
