using AutoMapper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services.Model.Dto;
using Todo.Services.Model.Model;
using Todo.Services.Service.Core;
using Todo.Services.Service.Interface;
using ToDo.Shared.Dtos;
using ToDo.Shared;
using Todo.Shared.Dtos;
using MongoDB.Bson;
using System.Security.Cryptography;

namespace Todo.Services.Service.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public TodoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _client = new RestClient();
        }
        public async Task<Response<string>> InsertTodo(CreateTodoModel todoModel)
        {
            Result myTodo = new Result();
            if (todoModel.Body != null)
            {
                todoModel.CreateTime = DateTime.Now;
                myTodo = _unitOfWork.Todo.Insert(_mapper.Map<TodoModel>(todoModel));
            }
            return await Task.FromResult(Response<string>.Success(myTodo.Data, Response.ResponseStatus.Success));
        }
        public async Task<Response<NoContent>> DeleteTodo(string Id)
        {
            List<TodoModel> myTodoList = _mapper.Map<List<TodoModel>>(_unitOfWork.Todo.GetListByExpression(x => x.Id == Id).Data);
            var myTodo = myTodoList.FirstOrDefault();

            myTodo.IsDelete = true;
            var response = _unitOfWork.Todo.Update(myTodo);
            if (response.IsSuccess == true)
            {
                return await Task.FromResult(Response<NoContent>.Success(new NoContent(), Response.ResponseStatus.Success));
            }
            else
            {
                return await Task.FromResult(Response<NoContent>.Fail("Bir hata ile karşılaşıldı.", Response.ResponseStatus.InitialError));
            }

        }
        public async Task<Response<TodoDto>> GetByTodoId(string Id)
        {
            var myTodo = _unitOfWork.Todo.GetById(Id).Data;
            if(myTodo != null)
            {
                return await Task.FromResult(Response<TodoDto>.Success(_mapper.Map<TodoDto>(myTodo), Response.ResponseStatus.Success));
            }
            else
            {
                return await Task.FromResult(Response<TodoDto>.Fail("Bir hata ile karşılaşıldı.", Response.ResponseStatus.InitialError));
            }
        }
        public async Task<Response<List<TodoDto>>> GetAllTodo()
        {
            var myTodoList = _unitOfWork.Todo.GetAll().Data;
            if (myTodoList != null)
            {
                return await Task.FromResult(Response<List<TodoDto>>.Success(_mapper.Map<List<TodoDto>>(myTodoList), Response.ResponseStatus.Success));
            }
            else
            {
                return await Task.FromResult(Response<List<TodoDto>>.Fail("Bir hata ile karşılaşıldı.", Response.ResponseStatus.InitialError));
            }
        }
    }
}
