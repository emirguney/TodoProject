﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDo.Shared.Response;

namespace ToDo.Shared.Dtos
{
    public class Response<T>
    {

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        [JsonProperty(PropertyName = "statusCode")]
        public ResponseStatus StatusCode { get; set; }

        [JsonProperty(PropertyName = "isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty(PropertyName = "error")]
        public List<string> Errors { get; set; }


        public static Response<T> Success(T data, ResponseStatus statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccess = true };
        }

        public static Response<T> Success(ResponseStatus statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccess = true };
        }

        public static Response<T> Fail(List<string> errors, ResponseStatus statusCode)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, IsSuccess = false };
        }

        public static Response<T> Fail(string error, ResponseStatus statusCode)
        {

            return new Response<T> { Errors = new List<string>() { (error) }, StatusCode = statusCode, IsSuccess = false };
        }
    }
}

