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
        public async Task<TodoTaskDTO> AddTodoTaskAsync(TodoTaskDTO model)
        {
            var newTask = _mapper.Map<TodoTask>(model);
            _context.TodoTasks!.Add(newTask);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task CompleteTaskAsync(List<int> id)
        {
            var task = await _context.TodoTasks.Where(c 
                => id.Contains(c.TaskId)).ToListAsync();
            foreach (var x in task)
            {
                x.Status = Done;
            }
            _context.UpdateRange(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoTaskAsync(int id)
        {
            var deleteTask = await _context.TodoTasks!.FindAsync(id);
            if(deleteTask != null)
            {
                _context.TodoTasks!.Remove(deleteTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoTaskDTO>> GetAllTodoTasksAsync()
        {
            var task = await _context.TodoTasks!.ToListAsync();
            return _mapper.Map<List<TodoTaskDTO>>(task);
        }

        public async Task<List<TodoTask>> GetTasksByDateAsync(DateTime Date)
        {
            var Task = await _context.TodoTasks.Where(t => t.Date == Date).ToListAsync();
            if (Task == null)
            {
                return null;
            }
            return Task;
        }


        public async Task<List<TodoTask>> GetTasksByStatusAsync(bool Status)
        {
            var Task = await _context.TodoTasks.Where(t 
                => t.Status == Status).ToListAsync();
            if (Task == null)
            {
                return null;
            }
            return Task;
        }

        public async Task<TodoTaskDTO> GetTodoTasksAsync(int id)
        {
            var task = await _context.TodoTasks!.FindAsync(id);
            return _mapper.Map<TodoTaskDTO>(task);
        }

        public async Task<TodoTaskDTO> UpdateTodoTaskAsync(int id, TodoTask model)
        {
            if(id == model.TaskId)
            {
                var updateTask = _mapper.Map<TodoTaskDTO>(model);
                _context.TodoTasks!.Update(model);
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
