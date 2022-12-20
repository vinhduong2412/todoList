using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Todo.DTOs;
using Microsoft.EntityFrameworkCore.Storage;

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
        public async Task<TodoTaskResponseDTO> AddTodoTaskAsync(int UserId, TodoTaskRequestDTO model)
        {
            var newTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
                => c.Id == UserId);
            newTask = _mapper.Map<TodoTask>(model);
            _context.TodoTasks.Add(newTask);
            await _context.SaveChangesAsync();

            return _mapper.Map<TodoTaskResponseDTO>(newTask); ;
        }

        public async Task CompleteTaskAsync(int UserId, List<int> id)
        {
            var task = await _context.TodoTasks.Where(c 
                => id.Contains(c.TaskId) && c.Id == UserId).ToListAsync();
            foreach (var x in task)
            {
                x.Status = Done;
            }
            _context.UpdateRange(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoTaskAsync(int UserId, int id)
        {
            var deleteTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
                => c.Id == UserId && c.TaskId == id);
            if(deleteTask != null)
            {
                _context.TodoTasks.Remove(deleteTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoTask>> GetTodoTasksAsync(int UserId, FilterRequestDTO model)
        {
            var querry = _context.TodoTasks.Where(c => c.Id == UserId);
            
            if (model.Status != null)
            {
                querry = querry.Where(t => t.Status == model.Status);
            }

            if (model.Date != null)
            {
                querry = querry.Where(c => c.Date == model.Date);
            }
            return await querry.ToListAsync();
        }
        public async Task<TodoTaskResponseDTO> GetTodoTasksAsync(int UserId, int id)
        {
            var task = await _context.TodoTasks.FirstOrDefaultAsync(c => c.Id == UserId && c.Id == id);
            if (task == null)
            {
                return null;
            }
            return _mapper.Map<TodoTaskResponseDTO>(task);
        }

        public async Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(int UserId, int id, TodoTaskRequestByIdDTO model)
        {
            if(id == model.TaskId)
            {
                var updateTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
                    => c.Id == UserId && c.TaskId == id);
                _context.TodoTasks.Update(updateTask);
                await _context.SaveChangesAsync();
                return _mapper.Map<TodoTaskResponseDTO>(updateTask);  
            }
            else
            {
                return null;
            }
        }
    }
}
