using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Todo.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Services
{
    public class todoTaskService : ITodoTaskService
    {
        private readonly DataAccessContext _context;
        private readonly IMapper _mapper;
        public todoTaskService(DataAccessContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        const bool Done = false;
        public async Task<TodoTaskResponseDTO> AddTodoTaskAsync(Guid userId, TodoTaskRequestDTO model)
        {
            //var newTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
            //    => c.Id == userId);
            var newTask = _mapper.Map<TodoTaskRequestDTO,TodoTask>(model);
            newTask.Id = userId;
            _context.TodoTasks.Add(newTask);
            await _context.SaveChangesAsync();

            return _mapper.Map<TodoTaskResponseDTO>(newTask); ;
        }

        public async Task CompleteTaskAsync(Guid userId, List<int> id)
        {
            var task = await _context.TodoTasks.Where(c 
                => id.Contains(c.TaskId) && c.Id == userId).ToListAsync();
            foreach (var x in task)
            {
                x.Status = Done;
            }
            _context.UpdateRange(task);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoTaskResponseDTO> DeleteTodoTaskAsync(Guid userId, int id)
        {
            var deleteTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
                => c.Id == userId && c.TaskId == id);
            if(deleteTask == null)
            {
                return null; 
            }
            _context.TodoTasks.Remove(deleteTask);
            await _context.SaveChangesAsync();
            return _mapper.Map<TodoTaskResponseDTO>(deleteTask);
        }

        public async Task<List<TodoTask>> GetTodoTasksAsync(Guid userId, FilterRequestDTO queryParams)
        {
            var query = _context.TodoTasks.Where(c => c.Id == userId);
            
            if (queryParams.Status != null)
            {
                query = query.Where(t => t.Status == queryParams.Status);
            }
            if (queryParams.Date != null)
            {
                query = query.Where(c => c.Date == queryParams.Date);
            }
            return await query.ToListAsync();
        }
        public async Task<TodoTaskResponseDTO> GetTodoTasksAsync(Guid userId, int id)
        {
            var task = await _context.TodoTasks.FirstOrDefaultAsync(c => c.Id == userId && c.TaskId == id);
            if (task == null)
            {
                return null;
            }
            return _mapper.Map<TodoTaskResponseDTO>(task);
        }

        public async Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(Guid userId, int id, TodoTaskRequestByIdDTO model)
        {
             var updateTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
                 => c.Id == userId && c.TaskId == id);
             if (updateTask == null)
             {
                    return null;
             }
             _context.TodoTasks.Update(updateTask);
             await _context.SaveChangesAsync();
             return _mapper.Map<TodoTaskResponseDTO>(updateTask);  
        }
    }
}
