using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ResponseResult<T>
    {
        public int code { get; set; } = 200;
        public string message { get; set; } = "操作失败";
        public T? response { get; set; }

        public ResponseResult(T response)
        {
            this.response = response;
        }

        public ResponseResult() { }

        public static ResponseResult<T> Success(T response, string message = "")
        {
            return new ResponseResult<T>
            {
                response = response,
                message = message
            };
        }

        public static ResponseResult<T> Failed(int code = 400, string message = "操作失败")
        {
            return new ResponseResult<T>
            {
                code = code,
                message = message
            };
        }
    }

    /// <summary>
    /// 泛型推断类
    /// </summary>
    public class ResponseResult
    {
        public static ResponseResult<T> Success<T>(T response, string message = "") => ResponseResult<T>.Success(response, message);

        public static ResponseResult<T> Failed<T>(int code = 400, string message = "操作失败") => ResponseResult<T>.Failed(code, message);
    }
}
