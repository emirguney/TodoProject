using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Todo.Services.Model.Dto;
using Todo.Services.Model.Model;

namespace Todo.Services.Model.Mapper
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper()
        {
            CreateMap<TodoDto, TodoModel>().ReverseMap();
            CreateMap<CreateTodoModel, TodoModel>().ReverseMap();
        }
    }
}
