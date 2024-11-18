using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string? IsMessage { get; set; }
        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            IsMessage = message;
        }
    }
}
