using todo.Data;
using todo.Models;

namespace todo.Repositories
{
    public interface ITaskRepo
    {
        public Task<List<todoTaskModel>> GetAlltodoTasksAsync();
        public Task<todoTaskModel> GettodoTasksAsync(int id);
        public Task<int> AddtodoTaskAsync(todoTaskModel model);
        public Task UpdatetodoTaskAsync(int id, todoTaskModel model);
        public Task DeletetodoTaskAsync(int id);
    }
}
