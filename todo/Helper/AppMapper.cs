using AutoMapper;
using Todo.Models;
using Todo.DTOs;

namespace Todo.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<todoTask, todoTaskDTO>().ReverseMap();
            CreateMap<User, SignUpDTO>();
            CreateMap<User, SignInDTO>();
        }
    }
}
