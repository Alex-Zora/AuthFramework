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
    }
}
