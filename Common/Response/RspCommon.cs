using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Response
{
    public class RspCommon<T>
    {
        public string? respCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public RespSts resp { get; set; }

        public bool? isSuccess { get; set; }
        public bool isValidationError { get { return resp == RespSts.ValidationError; } }
        public bool isNotFound { get { return resp == RespSts.NotFound; } }
        public bool isDataNotExist { get { return resp == RespSts.DataNotExist; } }
        public bool isSystemError { get { return resp == RespSts.SystemError; } }

        public static RspCommon<T> Success(string data = "200", string message = "Success", T? dataBody = default(T))
        {
            return new RspCommon<T>
            {
                respCode = data,
                Message = message,
                isSuccess = true,
                resp = RespSts.Success,
                Data = dataBody
            };
        }

        public static RspCommon<T> ValidationError(string data = "400", string message = "Validation Error")
        {
            return new RspCommon<T>
            {
                respCode = data,
                Message = message,
                isSuccess = false,
                resp = RespSts.ValidationError
            };
        }
        public static RspCommon<T> NotFound(string data = "404", string message = "Not Found")
        {
            return new RspCommon<T>
            {
                respCode = data,
                Message = message,
                isSuccess = false,
                resp = RespSts.NotFound
            };
        }
        public static RspCommon<T> DataNotExist(string data = "404", string message = "Data Not Exist")
        {
            return new RspCommon<T>
            {
                respCode = data,
                Message = message,
                isSuccess = false,
                resp = RespSts.DataNotExist
            };
        }
        public static RspCommon<T> SystemError(string data = "500", string message = "System Error")
        {
            return new RspCommon<T>
            {
                respCode = data,
                Message = message,
                isSuccess = false,
                resp = RespSts.SystemError
            };
        }
        public static RspCommon<T> BadRequest(string data = "400", string message = "Bad Request")
        {
            return new RspCommon<T>
            {
                respCode = data,
                Message = message,
                isSuccess = false,
                resp = RespSts.None,
            };
        }
    }

    public enum RespSts
    {
        None,
        Success,
        ValidationError,
        NotFound,
        DataNotExist,
        SystemError
    }
}
