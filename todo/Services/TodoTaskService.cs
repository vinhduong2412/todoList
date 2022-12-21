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
        public async Task<TodoTaskResponseDTO> AddTodoTaskAsync(string UserId, TodoTaskRequestDTO model)
        {
            //var newTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
            //    => c.Id == UserId);
            var newTask = _mapper.Map<TodoTaskRequestDTO,TodoTask>(model);
            newTask.Id = UserId;
            _context.TodoTasks.Add(newTask);
            await _context.SaveChangesAsync();

            return _mapper.Map<TodoTaskResponseDTO>(newTask); ;
        }

        public async Task CompleteTaskAsync(string UserId, List<int> id)
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

        public async Task DeleteTodoTaskAsync(string UserId, int id)
        {
            var deleteTask = await _context.TodoTasks.FirstOrDefaultAsync(c 
                => c.Id == UserId && c.TaskId == id);
            if(deleteTask != null)
            {
                _context.TodoTasks.Remove(deleteTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoTask>> GetTodoTasksAsync(string UserId, FilterRequestDTO model)
        {
            var query = _context.TodoTasks.Where(c => c.Id == UserId);
            
            if (model.Status != null)
            {
                query = query.Where(t => t.Status == model.Status);
                return await query.ToListAsync();
            }

            if (model.Date != null)
            {
                query = query.Where(c => c.Date == model.Date);
                return await query.ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async Task<TodoTaskResponseDTO> GetTodoTasksAsync(string UserId, int id)
        {
            var task = await _context.TodoTasks.FirstOrDefaultAsync(c => c.Id == UserId && c.TaskId == id);
            if (task == null)
            {
                return null;
            }
            return _mapper.Map<TodoTaskResponseDTO>(task);
        }

        public async Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(string UserId, int id, TodoTaskRequestByIdDTO model)
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
