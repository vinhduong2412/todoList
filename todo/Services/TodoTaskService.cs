using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Todo.DTOs;

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

        public async Task<todoTaskDTO> AddTodoTaskAsync(todoTask model)
        {
            var newTask = _mapper.Map<todoTaskDTO>(model);
            _context.todoTasks!.Add(model);
            await _context.SaveChangesAsync();

            return newTask;
        }

        public async Task DeleteTodoTaskAsync(int id)
        {
            var deleteTask = await _context.todoTasks!.FindAsync(id);
            if(deleteTask != null)
            {
                _context.todoTasks!.Remove(deleteTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<todoTaskDTO>> GetAllTodoTasksAsync()
        {
            var task = await _context.todoTasks!.ToListAsync();
            return _mapper.Map<List<todoTaskDTO>>(task);
        }

        public async Task<todoTaskDTO> GetTodoTasksAsync(int id)
        {
            var task = await _context.todoTasks!.FindAsync(id);
            return _mapper.Map<todoTaskDTO>(task);
        }

        public async Task<todoTaskDTO> UpdateTodoTaskAsync(int id, todoTask model)
        {
            if(id == model.Id)
            {
                var updateTask = _mapper.Map<todoTaskDTO>(model);
                _context.todoTasks!.Update(model);
                await _context.SaveChangesAsync();
                return updateTask;
            }
            else
            {
                return null;
            }
        }
    }
}
