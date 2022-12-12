using AutoMapper;
using Todo.Models;
using Todo.DTOs;

namespace Todo.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<TodoTask, TodoTaskDTO>().ReverseMap();
            CreateMap<User, SignUpDTO>();
            CreateMap<User, SignInDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<TodoTask, todoTaskStatusDTO>().ReverseMap();
        }
    }
}
