using HW13.Entity;
using HW13.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract.IService
{
    public  interface IServiceAuthentication
    {
        public Result Login(string userName, string password);
        public Result Register(User user);
       
    }
}
