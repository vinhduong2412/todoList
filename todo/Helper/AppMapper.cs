using AutoMapper;
using Todo.Models;
using Todo.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Todo.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<TodoTask, TodoTaskRequestDTO>().ReverseMap();
            CreateMap<User, SignUpRequestDTO>();
            CreateMap<User, SignInRequestDTO>();
            CreateMap<Category, CategoryRequestDTO>();
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<User, UserResponse>();
            CreateMap<SignInRequestDTO, UserResponse>();
            CreateMap<TodoTask, TodoTaskResponseDTO>().ReverseMap();
            CreateMap<TodoTask, TodoTaskRequestByIdDTO>().ReverseMap();
            CreateMap<TodoTask, FilterRequestDTO>().ReverseMap();
            CreateMap<SignUpRequestDTO, UserResponse>().ReverseMap();
        }
    }
}
