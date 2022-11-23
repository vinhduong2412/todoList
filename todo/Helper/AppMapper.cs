using AutoMapper;
using todo.Models;
using todo.Data;

namespace todo.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<todoTask, todoTaskModel>().ReverseMap();
        }
    }
}
