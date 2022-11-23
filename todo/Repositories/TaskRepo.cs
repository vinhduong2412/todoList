using AutoMapper;
using Microsoft.EntityFrameworkCore;
using todo.Data;
using todo.Models;

namespace todo.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly DataAccessContext _context;
        private readonly IMapper _mapper;
        public TaskRepo(DataAccessContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddtodoTaskAsync(todoTaskModel model)
        {
            var newTask = _mapper.Map<todoTask>(model);
            _context.todoTasks!.Add(newTask);
            await _context.SaveChangesAsync();
            return newTask.Id;
        }

        public async Task DeletetodoTaskAsync(int id)
        {
            var deleteTask = _context.todoTasks!.SingleOrDefault(t => t.Id == id);
            if(deleteTask != null)
            {
                _context.todoTasks!.Remove(deleteTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<todoTaskModel>> GetAlltodoTasksAsync()
        {
            var task = await _context.todoTasks!.ToListAsync();
            return _mapper.Map<List<todoTaskModel>>(task);
        }

        public async Task<todoTaskModel> GettodoTasksAsync(int id)
        {
            var task = await _context.todoTasks!.FindAsync(id);
            return _mapper.Map<todoTaskModel>(task);
        }

        public async Task UpdatetodoTaskAsync(int id, todoTaskModel model)
        {
            if(id == model.Id)
            {
                var updateTask = _mapper.Map<todoTask>(model);
                _context.todoTasks!.Update(updateTask);
                await _context.SaveChangesAsync();
            }
        }
    }
}
