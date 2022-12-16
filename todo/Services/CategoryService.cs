using Microsoft.EntityFrameworkCore;
using Todo.DTOs;
using Todo.Helper;
using Todo.Models;
using AutoMapper;

namespace Todo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataAccessContext _context;
        private readonly IMapper _mapper;
        public CategoryService(DataAccessContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CategoryRequestDTO>> GetCategory()
        {
            var task = await _context.Categories!.ToListAsync();
            return _mapper.Map<List<CategoryRequestDTO>>(task);
        }
    }
}
