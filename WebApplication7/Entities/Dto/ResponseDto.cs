﻿namespace WebApplication7.Entities.Dto
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}