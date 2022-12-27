using Todo.DTOs;
using Todo.Models;

namespace Todo.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetCategory();
    }
}
