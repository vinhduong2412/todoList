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
        public async Task<TodoTaskResponseDTO> AddTodoTaskAsync(TodoTaskRequestDTO model)
        {
            var newTask = _mapper.Map<TodoTask>(model);
            _context.TodoTasks.Add(newTask);
            var response = _mapper.Map<TodoTaskResponseDTO>(newTask);
            await _context.SaveChangesAsync();

            return response;
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
            var deleteTask = await _context.TodoTasks.FindAsync(id);
            if(deleteTask != null)
            {
                _context.TodoTasks.Remove(deleteTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoTaskResponseDTO>> GetAllTodoTasksAsync()
        {
            var task = await _context.TodoTasks.ToListAsync();
            return _mapper.Map<List<TodoTaskResponseDTO>>(task);
        }

        public async Task<List<TodoTaskResponseDTO>> GetTasksByDateAsync(DateTime Date)
        {
            var Task = await _context.TodoTasks.Where(t => t.Date == Date).ToListAsync();
            var response = _mapper.Map<List<TodoTaskResponseDTO>>(Task);
            if (Task == null)
            {
                return null;
            }
            return response;
        }


        public async Task<List<TodoTaskResponseDTO>> GetTasksByStatusAsync(bool Status)
        {
            var Task = await _context.TodoTasks.Where(t 
                => t.Status == Status).ToListAsync();
            var response = _mapper.Map<List<TodoTaskResponseDTO>>(Task);
            if (Task == null)
            {
                return null;
            }
            return response;
        }

        public async Task<TodoTaskResponseDTO> GetTodoTasksAsync(int id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            return _mapper.Map<TodoTaskResponseDTO>(task);
        }

        public async Task<TodoTaskResponseDTO> UpdateTodoTaskAsync(int id, TodoTaskRequestByIdDTO model)
        {
            if(id == model.TaskId)
            {
                var updateTask = _mapper.Map<TodoTask>(model);
                _context.TodoTasks.Update(updateTask);
                var response = _mapper.Map<TodoTaskResponseDTO>(updateTask);
                await _context.SaveChangesAsync();
                return response;  
            }
            else
            {
                return null;
            }
        }
    }
}
